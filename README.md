# woodOscillo-PC
「お手軽DIPマイコンのPIC32MXを始めよう(仮称)」の第4章「オシロスコープを作ろう」に対応したPC側のソフトウェアです。mainである自作オシロwoodOscilloのPC側プログラムにチャンネル数やサンプリングレートの切り替え(NORMAL or OVER CLOCK)等の変更を施しました。

500ksps1chのUSBオシロで現状はシングルのみで本当に簡易的なソフトです。(マイコン側のADCをオーバークロックすると1Msps)

<img src="./add_info/woodOscillo.png" alt="オシロ画面" width="400"/>  

# 使い方 
OscilloKun.exeを実行するか自分でコンパイルする。  

ソフトウェア  
- ポートを選択し接続ボタンを押す
- PIC32MXに書き込んだプログラムに応じてFirmwareをNORMALかOVER CLOCKを選択する
- オシロ的いろいろを設定
- Singleボタンを押す
- トリガーが掛かれば表示されるはず

# 開発情報  
IDEはVisual Studio2019でwindowsフォームアプリケーションで開発してます。