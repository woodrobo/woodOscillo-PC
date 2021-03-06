using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//UART
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace OscilloKun
{
    public partial class Form1 : Form
    {
        //mode
        bool is_disp_oscillo = false;

        //serial
        const int measurement_num = 4000;
        byte[] serial_buf = new byte[4 * measurement_num * 2];
        int serial_buf_counter = 0;
        bool serial_buf_enable = true;
        double sampling_us = 0.5;

        //time
        double[] interval_us = { 10, 20, 50, 100, 200, 500, 1000, 2000, 5000, 10000, 20000, 50000 };   //us
        String[] interval_str = { "10us", "20us", "50us", "100us", "200us", "500us", "1ms", "2ms", "5ms", "10ms", "20ms", "50ms" };
        int time_position_us = 0;

        //CH
        String[] CH_str = { "CH1", "CH1+CH2", "CH1+CH2+CH3", "CH1+CH2+CH3+CH4" };


        public byte[] cobs_encode(byte[] data)
        {
            if (data.Length > 254)
            {
                Console.WriteLine("[error]data length must be less than 255");
                byte[] tmp = new byte[0];
                return tmp;
            }
            int len = data.Length + 2;
            byte[] packet = new byte[len];

            int zero_index = len - 1;
            packet[len - 1] = 0;
            for (int i = len - 2; i > 0; i--)
            {
                if (data[i - 1] == 0)
                {
                    packet[i] = (byte)(zero_index - i);
                    zero_index = i;
                }
                else
                {
                    packet[i] = data[i - 1];
                }
            }
            packet[0] = (byte)zero_index;

            return packet;
        }

        public Form1()
        {
            InitializeComponent();

            //各種コンボボックスの初期化
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                PortComboBox.Items.Add(port);
            }
            if (PortComboBox.Items.Count > 0)
            {
                PortComboBox.SelectedIndex = 0;
            }

            foreach (string str in interval_str)
            {
                TimeComboBox.Items.Add(str+"/div");
            }
            TimeComboBox.SelectedIndex = 0;

            foreach (string str in CH_str)
            {
                CHComboBox.Items.Add(str);
            }
            CHComboBox.SelectedIndex = 0;

            TriggercomboBox.SelectedIndex = 0;

            //チャートをクリアして適当な画面を作る
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            string chart_area1 = "Area1";
            chart1.ChartAreas.Add(new ChartArea(chart_area1));

            //適当なデータを表示
            string legend1 = "CH1";
            chart1.Series.Add(legend1);
            chart1.Series[legend1].ChartType = SeriesChartType.Line;

            double[] y_values = new double[1000];
            for (int i = 0; i < y_values.Length; i++)
            {
                y_values[i] = Math.Sin((double)i / 100.0 * 2.0 * Math.PI);
            }
            for (int i = 0; i < y_values.Length; i++)
            {
                chart1.Series[legend1].Points.AddY(y_values[i]);
            }
        }

        private void ConnectionButton_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = 115200;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.PortName = PortComboBox.SelectedItem.ToString();
                serialPort1.Open();
                MyTextBox.Text = serialPort1.PortName + "に接続しました。";
            }
            catch(System.UnauthorizedAccessException)
            {
                MyTextBox.Text = "[エラー]" + serialPort1.PortName + "に接続できません。他のソフトで開いていませんか？";
            }
            catch(System.IO.IOException)
            {
                MyTextBox.Text = "[エラー]" + serialPort1.PortName + "は存在しません。";
            }
            catch (System.InvalidOperationException)
            {
                MyTextBox.Text = "[エラー]" + "ポートが開いている間にポートを開くことはできません。";
            }
        }

        private void SingleButton_Click(object sender, EventArgs e)
        {
            //設定読み込み
            string trig_mode = TriggercomboBox.SelectedItem.ToString();
            double trig_level = (double)TrigLevelNumericUpDown.Value;

            //オシロに送るコマンドはCOBS形式で
            //1byte:7bit目START + 6bit目Trigger RorF + 0-5bit目Trigger Level
            //2byte:サンプリング間隔100ns単位(上位8bit)
            //3byte:サンプリング間隔100ns単位(下位8bit)
            byte[] command = new byte[3] { 0x80, 0x00, 0x00 };

            if (trig_mode == "RISE")
            {
                MyTextBox.Text = "Trigger:RISE\r\nWait";
                command[0] |= 0x00;
            }
            else if(trig_mode == "FALL")
            {
                MyTextBox.Text = "Trigger:FALL\r\nWait";
                command[0] |= 0x40;
            }
            else
            {
                MyTextBox.Text = "Select Trigger";
            }

            command[0] |= (byte)(trig_level * 10);

            //sampling timeは100ns単位の時間
            uint sampling_time = (uint)interval_us[TimeComboBox.SelectedIndex] / 10;  // /100 * 10
            if(sampling_time < 5)
            {
                sampling_time = 5;
            }
            command[1] = (byte)((sampling_time >> 8) & 0xff);
            command[2] = (byte)((sampling_time >> 0) & 0xff);

            byte[] packet = cobs_encode(command);

            if(packet.Length == 5)
            {
                try
                {
                    serialPort1.Write(packet, 0, 5);
                    serial_buf_counter = 0;
                    serial_buf_enable = true;
                    sampling_us = (double)sampling_time / 10;

                    is_disp_oscillo = false;
                    //チャートをクリアして空のオシロ画面を作る
                    chart1.Series.Clear();
                    chart1.ChartAreas.Clear();
                    if(sampling_us <= 1.0)
                    {
                        SamplingRateLabel.Text = 1 / sampling_us + "Msps";
                    }
                    else
                    {
                        SamplingRateLabel.Text = 1 / sampling_us * 1000 + "ksps";
                    }
                    
                }
                catch(System.InvalidOperationException)
                {
                    MyTextBox.Text = "[エラー]" + "ポートを開いてください。";
                }
            }
            else
            {
                Console.WriteLine("[error]cobs_encode failed");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buf = new byte[serialPort1.BytesToRead];
            serialPort1.Read(buf, 0, buf.Length);
            if (serial_buf_enable)
            {
                for (int i = 0; i < buf.Length; i++)
                {
                    serial_buf[serial_buf_counter] = buf[i];
                    serial_buf_counter++;
                }

                Console.WriteLine("counter:{0}", serial_buf_counter);

                if (serial_buf_counter >= 4 * measurement_num)
                {
                    //予定されているデータが揃ったら表示する
                    serial_buf_enable = false;
                    Invoke(new DrawGraphDelegate(DrawGraph));
                }
            }

        }

       delegate void DrawGraphDelegate();
       void DrawGraph()
        {
            is_disp_oscillo = true;

            MyTextBox.Text = DateTime.Now.ToString() + "\r\nDrawGraph\r\n";
            MyTextBox.Text += "buf[0]:"+serial_buf[0].ToString();

            //データを作成
            double interval = interval_us[TimeComboBox.SelectedIndex];
            double min = time_position_us;
            double max = interval * 10 + time_position_us;

            int data_length = measurement_num;
            
            bool is_ms_disp = false;
            if (interval >= 1000)
            {
                interval = interval / 1000.0;
                min = min / 1000.0;
                max = max / 1000.0;
                is_ms_disp = true;
            }

            double[] time = new double[data_length];
            double[] ch1_vol = new double[data_length];
            double[] ch2_vol = new double[data_length];
            double[] ch3_vol = new double[data_length];
            double[] ch4_vol = new double[data_length];
            for (int i = 0; i < data_length; i++)
            {
                ch1_vol[i] = (double)serial_buf[i] / 256.0 * 3.3;
                ch2_vol[i] = (double)serial_buf[i + 1 * measurement_num] / 256.0 * 3.3;
                ch3_vol[i] = (double)serial_buf[i + 2 * measurement_num] / 256.0 * 3.3;
                ch4_vol[i] = (double)serial_buf[i + 3 * measurement_num] / 256.0 * 3.3;
                if (is_ms_disp)
                {
                    time[i] = sampling_us * i / 1000.0;
                }
                else
                {
                    time[i] = sampling_us * i;
                }
            }

            //チャートをクリアしてオシロ画面を作る
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            string chart_area = "OscilloArea";
            chart1.ChartAreas.Add(new ChartArea(chart_area));
            if (is_ms_disp)
            {
                chart1.ChartAreas[0].AxisX.Title = "Time(ms)";
            }
            else
            {
                chart1.ChartAreas[0].AxisX.Title = "Time(us)";
            }
            chart1.ChartAreas[0].AxisY.Title = "Voltage(V)";
            chart1.ChartAreas[0].AxisX.Minimum = min;
            chart1.ChartAreas[0].AxisX.Maximum = max;
            chart1.ChartAreas[0].AxisX.Interval = interval;

            //チャートに波形データを入力
            int ch_num = CHComboBox.SelectedIndex + 1;
            string legend1 = "CH1";
            string legend2 = "CH2";
            string legend3 = "CH3";
            string legend4 = "CH4";
            if (ch_num >= 1)
            {
                chart1.Series.Add(legend1);
                chart1.Series[legend1].ChartType = SeriesChartType.Line;
                for (int i = 0; i < data_length; i++)
                {
                    chart1.Series[legend1].Points.AddXY(time[i], ch1_vol[i]);
                }
            }
            if (ch_num >= 2)
            {
                chart1.Series.Add(legend2);
                chart1.Series[legend2].ChartType = SeriesChartType.Line;
                for (int i = 0; i < data_length; i++)
                {
                    chart1.Series[legend2].Points.AddXY(time[i], ch2_vol[i]);
                }
            }
            if (ch_num >= 3)
            {
                chart1.Series.Add(legend3);
                chart1.Series[legend3].ChartType = SeriesChartType.Line;
                for (int i = 0; i < data_length; i++)
                {
                    chart1.Series[legend3].Points.AddXY(time[i], ch3_vol[i]);
                }
            }
            if (ch_num >= 4)
            {
                chart1.Series.Add(legend4);
                chart1.Series[legend4].ChartType = SeriesChartType.Line;
                for (int i = 0; i < data_length; i++)
                {
                    chart1.Series[legend4].Points.AddXY(time[i], ch4_vol[i]);
                }
            }
        }

        private void TimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimePosMoveInterval(false, 0);
            if (is_disp_oscillo)
            {
                DrawGraph();
            }
        }

        private void TimePosZeroButton_Click(object sender, EventArgs e)
        {
            TimePosMoveInterval(true, 0);
            if (is_disp_oscillo)
            {
                DrawGraph();
            }
        }

        private void TimePosLeftButton_Click(object sender, EventArgs e)
        {
            TimePosMoveInterval(false, -1);
            if (is_disp_oscillo)
            {
                DrawGraph();
            }
        }

        private void TimePosRightButton_Click(object sender, EventArgs e)
        {
            TimePosMoveInterval(false, 1);
            if (is_disp_oscillo)
            {
                DrawGraph();
            }
        }

        //interval基準でTimePosを更新する関数
        private void TimePosMoveInterval(bool absolute, int value)
        {
            //現在のinterval上での位置を取得
            double interval = interval_us[TimeComboBox.SelectedIndex];
            int interval_count = (int)Math.Round(time_position_us / interval);
            if (absolute)
            {
                interval_count = 0;
            }

            //更新する
            interval_count += value;
            time_position_us = (int)(interval_count * interval);
            if(Math.Abs(time_position_us) < 1000) {
                TimePosTextBox.Text = time_position_us + "us";
            }
            else
            {
                TimePosTextBox.Text = time_position_us / 1000.0 + "ms";
            }
            
        }
    }
}