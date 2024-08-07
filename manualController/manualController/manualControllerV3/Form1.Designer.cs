namespace manualControllerV3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.blackBox = new System.Windows.Forms.Label();
            this.redBox = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.error = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.xValueLabel = new System.Windows.Forms.Label();
            this.yValueLabel = new System.Windows.Forms.Label();
            this.error2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // blackBox
            // 
            this.blackBox.BackColor = System.Drawing.Color.Black;
            this.blackBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.blackBox.Location = new System.Drawing.Point(47, 27);
            this.blackBox.MaximumSize = new System.Drawing.Size(200, 200);
            this.blackBox.MinimumSize = new System.Drawing.Size(200, 200);
            this.blackBox.Name = "blackBox";
            this.blackBox.Size = new System.Drawing.Size(200, 200);
            this.blackBox.TabIndex = 0;
            // 
            // redBox
            // 
            this.redBox.BackColor = System.Drawing.Color.Red;
            this.redBox.Location = new System.Drawing.Point(136, 117);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(22, 22);
            this.redBox.TabIndex = 3;
            this.redBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(12, 259);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(129, 23);
            this.status.TabIndex = 5;
            this.status.Text = "Status";
            // 
            // port
            // 
            this.port.PortName = "COM3";
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Location = new System.Drawing.Point(12, 308);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(36, 16);
            this.error.TabIndex = 6;
            this.error.Text = "Error";
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // xValueLabel
            // 
            this.xValueLabel.Location = new System.Drawing.Point(156, 258);
            this.xValueLabel.Name = "xValueLabel";
            this.xValueLabel.Size = new System.Drawing.Size(62, 40);
            this.xValueLabel.TabIndex = 7;
            this.xValueLabel.Text = "\r\nxValue";
            // 
            // yValueLabel
            // 
            this.yValueLabel.Location = new System.Drawing.Point(214, 258);
            this.yValueLabel.Name = "yValueLabel";
            this.yValueLabel.Size = new System.Drawing.Size(62, 40);
            this.yValueLabel.TabIndex = 9;
            this.yValueLabel.Text = "\r\nyValue";
            // 
            // error2
            // 
            this.error2.AutoSize = true;
            this.error2.Location = new System.Drawing.Point(12, 282);
            this.error2.Name = "error2";
            this.error2.Size = new System.Drawing.Size(36, 16);
            this.error2.TabIndex = 10;
            this.error2.Text = "Error";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 333);
            this.Controls.Add(this.error2);
            this.Controls.Add(this.yValueLabel);
            this.Controls.Add(this.xValueLabel);
            this.Controls.Add(this.error);
            this.Controls.Add(this.status);
            this.Controls.Add(this.redBox);
            this.Controls.Add(this.blackBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label blackBox;
        private System.Windows.Forms.Label redBox;
        private System.Windows.Forms.Label status;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label xValueLabel;
        private System.Windows.Forms.Label yValueLabel;
        private System.Windows.Forms.Label error2;
    }
}

