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
                SerializationHelper s = new SerializationHelper();
                s.Actions = Action.ActionController.Instance.Actions;
                s.Infos = InfoController.Instance.Infos;
                using(var stream = saveFileDialog1.OpenFile())
                {
                    bf.Serialize(stream, s);
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
                    SerializationHelper helper = (SerializationHelper)bf.Deserialize(stream);
                    InfoController.Instance.Infos.Clear();
                    foreach(var item in helper.Infos)
                        InfoController.Instance.Infos.Add(item);
                    InfoController.Instance.UpdateInfosList(infosList);

                    Action.ActionController.Instance.Actions.Clear();
                    foreach (var item in helper.Actions)
                        Action.ActionController.Instance.Actions.Add(item.Key, item.Value);
                }
            }
        }

        private void actionBtn1_Click(object sender, EventArgs e)
        {
            if (Action.ActionController.Instance.Actions[0x01] != null)
                actionProperty.SelectedObject = Action.ActionController.Instance.Actions[0x01];
            var actions = Action.ActionEnumerator.GetActions();
            foreach (var a in actions)
                actionsList.Items.Add(a);
        }

        private void actionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action.ActionController.Instance.Actions[0x01] = Action.ActionEnumerator.CreateAction(actionsList.SelectedItem as string);
            actionProperty.SelectedObject = Action.ActionController.Instance.Actions[0x01];
        }
    }
}
