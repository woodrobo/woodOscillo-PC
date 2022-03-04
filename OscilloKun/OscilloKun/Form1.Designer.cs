namespace OscilloKun
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ConnectionButton = new System.Windows.Forms.Button();
            this.MyTextBox = new System.Windows.Forms.TextBox();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TriggercomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TrigLevelNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SingleButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CHComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TimePosTextBox = new System.Windows.Forms.TextBox();
            this.TimePosLeftButton = new System.Windows.Forms.Button();
            this.TimePosRightButton = new System.Windows.Forms.Button();
            this.TimePosZeroButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrigLevelNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionButton
            // 
            this.ConnectionButton.Location = new System.Drawing.Point(171, 12);
            this.ConnectionButton.Name = "ConnectionButton";
            this.ConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectionButton.TabIndex = 0;
            this.ConnectionButton.Text = "接続";
            this.ConnectionButton.UseVisualStyleBackColor = true;
            this.ConnectionButton.Click += new System.EventHandler(this.ConnectionButton_Click);
            // 
            // MyTextBox
            // 
            this.MyTextBox.Location = new System.Drawing.Point(12, 38);
            this.MyTextBox.Multiline = true;
            this.MyTextBox.Name = "MyTextBox";
            this.MyTextBox.Size = new System.Drawing.Size(234, 56);
            this.MyTextBox.TabIndex = 1;
            // 
            // PortComboBox
            // 
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(12, 12);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(121, 20);
            this.PortComboBox.TabIndex = 2;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(71, 103);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(814, 335);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // TriggercomboBox
            // 
            this.TriggercomboBox.FormattingEnabled = true;
            this.TriggercomboBox.Items.AddRange(new object[] {
            "RISE",
            "FALL"});
            this.TriggercomboBox.Location = new System.Drawing.Point(346, 20);
            this.TriggercomboBox.Name = "TriggercomboBox";
            this.TriggercomboBox.Size = new System.Drawing.Size(121, 20);
            this.TriggercomboBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Trigger";
            // 
            // TrigLevelNumericUpDown
            // 
            this.TrigLevelNumericUpDown.DecimalPlaces = 1;
            this.TrigLevelNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TrigLevelNumericUpDown.Location = new System.Drawing.Point(346, 46);
            this.TrigLevelNumericUpDown.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            65536});
            this.TrigLevelNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TrigLevelNumericUpDown.Name = "TrigLevelNumericUpDown";
            this.TrigLevelNumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.TrigLevelNumericUpDown.TabIndex = 7;
            this.TrigLevelNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Level";
            // 
            // SingleButton
            // 
            this.SingleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SingleButton.Location = new System.Drawing.Point(811, 71);
            this.SingleButton.Name = "SingleButton";
            this.SingleButton.Size = new System.Drawing.Size(75, 23);
            this.SingleButton.TabIndex = 9;
            this.SingleButton.Text = "SINGLE";
            this.SingleButton.UseVisualStyleBackColor = true;
            this.SingleButton.Click += new System.EventHandler(this.SingleButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Time";
            // 
            // TimeComboBox
            // 
            this.TimeComboBox.FormattingEnabled = true;
            this.TimeComboBox.Location = new System.Drawing.Point(524, 21);
            this.TimeComboBox.Name = "TimeComboBox";
            this.TimeComboBox.Size = new System.Drawing.Size(121, 20);
            this.TimeComboBox.TabIndex = 10;
            this.TimeComboBox.SelectedIndexChanged += new System.EventHandler(this.TimeComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(661, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "CH";
            // 
            // CHComboBox
            // 
            this.CHComboBox.FormattingEnabled = true;
            this.CHComboBox.Location = new System.Drawing.Point(707, 20);
            this.CHComboBox.Name = "CHComboBox";
            this.CHComboBox.Size = new System.Drawing.Size(121, 20);
            this.CHComboBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(478, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Position";
            // 
            // TimePosTextBox
            // 
            this.TimePosTextBox.Location = new System.Drawing.Point(524, 46);
            this.TimePosTextBox.Name = "TimePosTextBox";
            this.TimePosTextBox.Size = new System.Drawing.Size(63, 19);
            this.TimePosTextBox.TabIndex = 15;
            // 
            // TimePosLeftButton
            // 
            this.TimePosLeftButton.Location = new System.Drawing.Point(524, 71);
            this.TimePosLeftButton.Name = "TimePosLeftButton";
            this.TimePosLeftButton.Size = new System.Drawing.Size(24, 23);
            this.TimePosLeftButton.TabIndex = 16;
            this.TimePosLeftButton.Text = "←";
            this.TimePosLeftButton.UseVisualStyleBackColor = true;
            this.TimePosLeftButton.Click += new System.EventHandler(this.TimePosLeftButton_Click);
            // 
            // TimePosRightButton
            // 
            this.TimePosRightButton.Location = new System.Drawing.Point(563, 71);
            this.TimePosRightButton.Name = "TimePosRightButton";
            this.TimePosRightButton.Size = new System.Drawing.Size(24, 23);
            this.TimePosRightButton.TabIndex = 17;
            this.TimePosRightButton.Text = "→";
            this.TimePosRightButton.UseVisualStyleBackColor = true;
            this.TimePosRightButton.Click += new System.EventHandler(this.TimePosRightButton_Click);
            // 
            // TimePosZeroButton
            // 
            this.TimePosZeroButton.Location = new System.Drawing.Point(601, 44);
            this.TimePosZeroButton.Name = "TimePosZeroButton";
            this.TimePosZeroButton.Size = new System.Drawing.Size(44, 23);
            this.TimePosZeroButton.TabIndex = 18;
            this.TimePosZeroButton.Text = "ZERO";
            this.TimePosZeroButton.UseVisualStyleBackColor = true;
            this.TimePosZeroButton.Click += new System.EventHandler(this.TimePosZeroButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 450);
            this.Controls.Add(this.TimePosZeroButton);
            this.Controls.Add(this.TimePosRightButton);
            this.Controls.Add(this.TimePosLeftButton);
            this.Controls.Add(this.TimePosTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CHComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeComboBox);
            this.Controls.Add(this.SingleButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TrigLevelNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TriggercomboBox);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.MyTextBox);
            this.Controls.Add(this.ConnectionButton);
            this.Name = "Form1";
            this.Text = "woodOscillo";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrigLevelNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectionButton;
        private System.Windows.Forms.TextBox MyTextBox;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox TriggercomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown TrigLevelNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SingleButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TimeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CHComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TimePosTextBox;
        private System.Windows.Forms.Button TimePosLeftButton;
        private System.Windows.Forms.Button TimePosRightButton;
        private System.Windows.Forms.Button TimePosZeroButton;
    }
}

