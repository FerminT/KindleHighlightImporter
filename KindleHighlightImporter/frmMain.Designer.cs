namespace KindleHighlightImporter
{
    partial class FrmMain
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
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtEpubDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(302, 40);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(554, 26);
            this.txtFrom.TabIndex = 0;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(302, 88);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(554, 26);
            this.txtTo.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(39, 45);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(254, 20);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "File to import highlights from (TXT):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output file (ENEX):";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(744, 183);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(112, 35);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Start Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // txtEpubDir
            // 
            this.txtEpubDir.Location = new System.Drawing.Point(302, 132);
            this.txtEpubDir.Name = "txtEpubDir";
            this.txtEpubDir.Size = new System.Drawing.Size(554, 26);
            this.txtEpubDir.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "EPUB directory:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 235);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEpubDir);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "Import Kindle highlights ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox txtEpubDir;
        private System.Windows.Forms.Label label1;
    }
}

