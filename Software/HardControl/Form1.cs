using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using HardControl.Helpers;
using HardControl.Info;

namespace HardControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Lcd.Instance.SetSurface(this);
            System.Timers.Timer a = new System.Timers.Timer(200);
            a.Elapsed += Lcd.Instance.Update;
            a.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SerialPortsHelper.UpdateSerialList(SerialPortsList);
            InfoController.Instance.UpdateInfosList(infosList);
            InfoEnumerator.MakeMenu(LcdContextMenu);
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);
            }
            catch { };
            if(m.Msg == WinApiHelper.WM_DEVICECHANGE)
                SerialPortsHelper.UpdateSerialList(SerialPortsList);
        }

        private void SerialPortsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SerialPort.PortName = (string)SerialPortsList.SelectedItem;
            var arduino = Arduino.Arduino.SetInstance(SerialPort);
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Lcd.Instance.onPaint(LcdPanel.CreateGraphics());
        }

        private void infosList_SelectedIndexChanged(object sender, EventArgs e)
        {
            infoProperty.SelectedObject = infosList.SelectedItem;
        }


        private void LcdContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void serializationBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using(var stream = saveFileDialog1.OpenFile())
                {
                    bf.Serialize(stream, InfoController.Instance.Infos);
                }
            }
        }

        private void deserializationBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var stream = openFileDialog1.OpenFile())
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    List<IInfoProvider> list = (List<IInfoProvider>)bf.Deserialize(stream);
                    InfoController.Instance.Infos.Clear();
                    foreach(var item in list)
                        InfoController.Instance.Infos.Add(item);
                    InfoController.Instance.UpdateInfosList(infosList);
                }
            }
        }
    }
}
