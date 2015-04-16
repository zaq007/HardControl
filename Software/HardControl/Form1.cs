﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SerialPortsHelper.UpdateSerialList(SerialPortsList);            
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
    }
}
