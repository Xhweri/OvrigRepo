namespace Labb4
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
            this.databasBtn = new System.Windows.Forms.Button();
            this.kassaBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // databasBtn
            // 
            this.databasBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.databasBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.databasBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasBtn.Location = new System.Drawing.Point(34, 68);
            this.databasBtn.Name = "databasBtn";
            this.databasBtn.Size = new System.Drawing.Size(308, 379);
            this.databasBtn.TabIndex = 0;
            this.databasBtn.Text = "Lager";
            this.databasBtn.UseVisualStyleBackColor = false;
            this.databasBtn.Click += new System.EventHandler(this.databasBtn_Click);
            // 
            // kassaBtn
            // 
            this.kassaBtn.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.kassaBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kassaBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.kassaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kassaBtn.Location = new System.Drawing.Point(377, 68);
            this.kassaBtn.Name = "kassaBtn";
            this.kassaBtn.Size = new System.Drawing.Size(305, 379);
            this.kassaBtn.TabIndex = 0;
            this.kassaBtn.Text = "Kassa";
            this.kassaBtn.UseVisualStyleBackColor = false;
            this.kassaBtn.Click += new System.EventHandler(this.kassaBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(714, 514);
            this.Controls.Add(this.kassaBtn);
            this.Controls.Add(this.databasBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button databasBtn;
        private System.Windows.Forms.Button kassaBtn;
    }
}

