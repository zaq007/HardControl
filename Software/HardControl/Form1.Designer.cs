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
            this.LcdPanel = new System.Windows.Forms.Panel();
            this.LcdContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.infosList = new System.Windows.Forms.ComboBox();
            this.infoProperty = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // SerialPortsList
            // 
            this.SerialPortsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SerialPortsList.Location = new System.Drawing.Point(12, 288);
            this.SerialPortsList.Name = "SerialPortsList";
            this.SerialPortsList.Size = new System.Drawing.Size(121, 21);
            this.SerialPortsList.TabIndex = 0;
            this.SerialPortsList.SelectedIndexChanged += new System.EventHandler(this.SerialPortsList_SelectedIndexChanged);
            // 
            // LcdPanel
            // 
            this.LcdPanel.ContextMenuStrip = this.LcdContextMenu;
            this.LcdPanel.Location = new System.Drawing.Point(12, 25);
            this.LcdPanel.Name = "LcdPanel";
            this.LcdPanel.Size = new System.Drawing.Size(219, 65);
            this.LcdPanel.TabIndex = 1;
            // 
            // LcdContextMenu
            // 
            this.LcdContextMenu.Name = "LcdContextMenu";
            this.LcdContextMenu.Size = new System.Drawing.Size(61, 4);
            this.LcdContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.LcdContextMenu_Opening);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lcd status:";
            // 
            // infosList
            // 
            this.infosList.FormattingEnabled = true;
            this.infosList.Location = new System.Drawing.Point(12, 96);
            this.infosList.Name = "infosList";
            this.infosList.Size = new System.Drawing.Size(219, 21);
            this.infosList.TabIndex = 3;
            this.infosList.SelectedIndexChanged += new System.EventHandler(this.infosList_SelectedIndexChanged);
            // 
            // infoProperty
            // 
            this.infoProperty.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.infoProperty.Location = new System.Drawing.Point(12, 120);
            this.infoProperty.Name = "infoProperty";
            this.infoProperty.Size = new System.Drawing.Size(219, 162);
            this.infoProperty.TabIndex = 4;
            this.infoProperty.ToolbarVisible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 321);
            this.Controls.Add(this.infoProperty);
            this.Controls.Add(this.infosList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LcdPanel);
            this.Controls.Add(this.SerialPortsList);
            this.Name = "MainForm";
            this.Text = "HardControl";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SerialPort;
        private System.Windows.Forms.ComboBox SerialPortsList;
        private System.Windows.Forms.Panel LcdPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox infosList;
        private System.Windows.Forms.PropertyGrid infoProperty;
        private System.Windows.Forms.ContextMenuStrip LcdContextMenu;
    }
}

