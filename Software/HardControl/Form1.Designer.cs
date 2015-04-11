namespace HardControl
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SerialPort = new System.IO.Ports.SerialPort(this.components);
            this.SerialPortsList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SerialPortsList
            // 
            this.SerialPortsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortsList.Location = new System.Drawing.Point(12, 229);
            this.SerialPortsList.Name = "SerialPortsList";
            this.SerialPortsList.Size = new System.Drawing.Size(121, 21);
            this.SerialPortsList.TabIndex = 0;
            this.SerialPortsList.SelectedIndexChanged += new System.EventHandler(this.SerialPortsList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SerialPortsList);
            this.Name = "MainForm";
            this.Text = "HardControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.ComboBox SerialPortsList;
    }
}

