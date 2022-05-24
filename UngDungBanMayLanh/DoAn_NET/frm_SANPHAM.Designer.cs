namespace DoAn_NET
{
    partial class frm_SANPHAM
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
            this.pnTop = new System.Windows.Forms.FlowLayoutPanel();
            this.pnSP = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1026, 67);
            this.pnTop.TabIndex = 1;
            // 
            // pnSP
            // 
            this.pnSP.AutoScroll = true;
            this.pnSP.BackColor = System.Drawing.Color.White;
            this.pnSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSP.Location = new System.Drawing.Point(0, 67);
            this.pnSP.Name = "pnSP";
            this.pnSP.Size = new System.Drawing.Size(1026, 618);
            this.pnSP.TabIndex = 2;
            // 
            // frm_SANPHAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 685);
            this.Controls.Add(this.pnSP);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_SANPHAM";
            this.Text = "frm_SANPHAM";
            this.Load += new System.EventHandler(this.frm_SANPHAM_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnTop;
        private System.Windows.Forms.FlowLayoutPanel pnSP;

    }
}