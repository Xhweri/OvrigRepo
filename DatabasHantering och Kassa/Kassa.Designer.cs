namespace Labb4
{
    partial class Kassa
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
            this.SokTxt = new System.Windows.Forms.TextBox();
            this.sokBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AddVara = new System.Windows.Forms.Button();
            this.RaderaVara = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kundkorg = new System.Windows.Forms.TextBox();
            this.kopvara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SokTxt
            // 
            this.SokTxt.BackColor = System.Drawing.Color.Bisque;
            this.SokTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SokTxt.Location = new System.Drawing.Point(12, 12);
            this.SokTxt.Multiline = true;
            this.SokTxt.Name = "SokTxt";
            this.SokTxt.Size = new System.Drawing.Size(319, 37);
            this.SokTxt.TabIndex = 0;
            this.SokTxt.Text = "Sök mellan kategorierna";
            // 
            // sokBtn
            // 
            this.sokBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sokBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sokBtn.Location = new System.Drawing.Point(12, 55);
            this.sokBtn.Name = "sokBtn";
            this.sokBtn.Size = new System.Drawing.Size(136, 31);
            this.sokBtn.TabIndex = 1;
            this.sokBtn.Text = "Sök";
            this.sokBtn.UseVisualStyleBackColor = true;
            this.sokBtn.Click += new System.EventHandler(this.sokBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Labb4.Properties.Resources.shopping_cart;
            this.pictureBox1.Location = new System.Drawing.Point(615, 241);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 150);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // AddVara
            // 
            this.AddVara.BackColor = System.Drawing.Color.Lime;
            this.AddVara.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddVara.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddVara.Location = new System.Drawing.Point(436, 241);
            this.AddVara.Name = "AddVara";
            this.AddVara.Size = new System.Drawing.Size(136, 41);
            this.AddVara.TabIndex = 1;
            this.AddVara.Text = "Varukorg";
            this.AddVara.UseVisualStyleBackColor = false;
            this.AddVara.Click += new System.EventHandler(this.AddVara_Click);
            // 
            // RaderaVara
            // 
            this.RaderaVara.BackColor = System.Drawing.Color.Red;
            this.RaderaVara.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaderaVara.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RaderaVara.Location = new System.Drawing.Point(625, 397);
            this.RaderaVara.Name = "RaderaVara";
            this.RaderaVara.Size = new System.Drawing.Size(136, 31);
            this.RaderaVara.TabIndex = 1;
            this.RaderaVara.Text = "Ta bort";
            this.RaderaVara.UseVisualStyleBackColor = false;
            this.RaderaVara.Click += new System.EventHandler(this.RaderaVara_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(418, 326);
            this.dataGridView1.TabIndex = 3;
            // 
            // kundkorg
            // 
            this.kundkorg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kundkorg.Location = new System.Drawing.Point(495, 12);
            this.kundkorg.Multiline = true;
            this.kundkorg.Name = "kundkorg";
            this.kundkorg.Size = new System.Drawing.Size(293, 174);
            this.kundkorg.TabIndex = 4;
            // 
            // kopvara
            // 
            this.kopvara.BackColor = System.Drawing.Color.Lime;
            this.kopvara.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kopvara.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kopvara.Location = new System.Drawing.Point(436, 349);
            this.kopvara.Name = "kopvara";
            this.kopvara.Size = new System.Drawing.Size(173, 79);
            this.kopvara.TabIndex = 1;
            this.kopvara.Text = "Bekräfta köp";
            this.kopvara.UseVisualStyleBackColor = false;
            this.kopvara.Click += new System.EventHandler(this.bekraftakop_Click);
            // 
            // Kassa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kundkorg);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RaderaVara);
            this.Controls.Add(this.kopvara);
            this.Controls.Add(this.AddVara);
            this.Controls.Add(this.sokBtn);
            this.Controls.Add(this.SokTxt);
            this.Name = "Kassa";
            this.Text = "Kassa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SokTxt;
        private System.Windows.Forms.Button sokBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddVara;
        private System.Windows.Forms.Button RaderaVara;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox kundkorg;
        private System.Windows.Forms.Button kopvara;
    }
}