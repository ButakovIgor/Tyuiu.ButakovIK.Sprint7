
namespace Tyuiu.ButakovIK.Sprint7.Project.V11
{
    partial class FormTip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTip));
            this.labelTip_BIK = new System.Windows.Forms.Label();
            this.buttonOk_BIK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTip_BIK
            // 
            this.labelTip_BIK.AutoSize = true;
            this.labelTip_BIK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTip_BIK.Location = new System.Drawing.Point(13, 13);
            this.labelTip_BIK.Name = "labelTip_BIK";
            this.labelTip_BIK.Size = new System.Drawing.Size(921, 144);
            this.labelTip_BIK.TabIndex = 0;
            this.labelTip_BIK.Text = resources.GetString("labelTip_BIK.Text");
            // 
            // buttonOk_BIK
            // 
            this.buttonOk_BIK.Location = new System.Drawing.Point(858, 221);
            this.buttonOk_BIK.Name = "buttonOk_BIK";
            this.buttonOk_BIK.Size = new System.Drawing.Size(75, 23);
            this.buttonOk_BIK.TabIndex = 1;
            this.buttonOk_BIK.Text = "Ок";
            this.buttonOk_BIK.UseVisualStyleBackColor = true;
            this.buttonOk_BIK.Click += new System.EventHandler(this.buttonOk_BIK_Click);
            // 
            // FormTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 256);
            this.Controls.Add(this.buttonOk_BIK);
            this.Controls.Add(this.labelTip_BIK);
            this.Name = "FormTip";
            this.Text = "Подсказка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTip_BIK;
        private System.Windows.Forms.Button buttonOk_BIK;
    }
}