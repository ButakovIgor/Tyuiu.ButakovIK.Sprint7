
namespace Tyuiu.ButakovIK.Sprint7.Project.V11
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBoxAutor_BIK = new System.Windows.Forms.PictureBox();
            this.labelAbout_BIK = new System.Windows.Forms.Label();
            this.buttonOk_BIK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAutor_BIK)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxAutor_BIK
            // 
            this.pictureBoxAutor_BIK.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAutor_BIK.Image")));
            this.pictureBoxAutor_BIK.Location = new System.Drawing.Point(13, 13);
            this.pictureBoxAutor_BIK.Name = "pictureBoxAutor_BIK";
            this.pictureBoxAutor_BIK.Size = new System.Drawing.Size(119, 174);
            this.pictureBoxAutor_BIK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAutor_BIK.TabIndex = 0;
            this.pictureBoxAutor_BIK.TabStop = false;
            // 
            // labelAbout_BIK
            // 
            this.labelAbout_BIK.AutoSize = true;
            this.labelAbout_BIK.Location = new System.Drawing.Point(138, 13);
            this.labelAbout_BIK.Name = "labelAbout_BIK";
            this.labelAbout_BIK.Size = new System.Drawing.Size(268, 169);
            this.labelAbout_BIK.TabIndex = 1;
            this.labelAbout_BIK.Text = resources.GetString("labelAbout_BIK.Text");
            // 
            // buttonOk_BIK
            // 
            this.buttonOk_BIK.Location = new System.Drawing.Point(331, 159);
            this.buttonOk_BIK.Name = "buttonOk_BIK";
            this.buttonOk_BIK.Size = new System.Drawing.Size(75, 23);
            this.buttonOk_BIK.TabIndex = 2;
            this.buttonOk_BIK.Text = "Ок";
            this.buttonOk_BIK.UseVisualStyleBackColor = true;
            this.buttonOk_BIK.Click += new System.EventHandler(this.buttonOk_BIK_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 199);
            this.Controls.Add(this.buttonOk_BIK);
            this.Controls.Add(this.labelAbout_BIK);
            this.Controls.Add(this.pictureBoxAutor_BIK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(446, 238);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(446, 238);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAutor_BIK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAutor_BIK;
        private System.Windows.Forms.Label labelAbout_BIK;
        private System.Windows.Forms.Button buttonOk_BIK;
    }
}