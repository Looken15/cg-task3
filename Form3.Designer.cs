
namespace task3
{
    partial class Form3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button_cl1 = new System.Windows.Forms.Button();
            this.button_cl2 = new System.Windows.Forms.Button();
            this.button_cl3 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(635, 438);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(656, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 56);
            this.button1.TabIndex = 1;
            this.button1.Text = "Растеризовать случайный треугольник";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cl1
            // 
            this.button_cl1.Location = new System.Drawing.Point(656, 86);
            this.button_cl1.Name = "button_cl1";
            this.button_cl1.Size = new System.Drawing.Size(108, 24);
            this.button_cl1.TabIndex = 2;
            this.button_cl1.Text = "Выбрать цвет 1";
            this.button_cl1.UseVisualStyleBackColor = true;
            this.button_cl1.Click += new System.EventHandler(this.button_cl1_Click);
            // 
            // button_cl2
            // 
            this.button_cl2.Location = new System.Drawing.Point(656, 116);
            this.button_cl2.Name = "button_cl2";
            this.button_cl2.Size = new System.Drawing.Size(108, 24);
            this.button_cl2.TabIndex = 3;
            this.button_cl2.Text = "Выбрать цвет 2";
            this.button_cl2.UseVisualStyleBackColor = true;
            this.button_cl2.Click += new System.EventHandler(this.button_cl2_Click);
            // 
            // button_cl3
            // 
            this.button_cl3.Location = new System.Drawing.Point(656, 146);
            this.button_cl3.Name = "button_cl3";
            this.button_cl3.Size = new System.Drawing.Size(108, 24);
            this.button_cl3.TabIndex = 4;
            this.button_cl3.Text = "Выбрать цвет 3";
            this.button_cl3.UseVisualStyleBackColor = true;
            this.button_cl3.Click += new System.EventHandler(this.button_cl3_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_cl3);
            this.Controls.Add(this.button_cl2);
            this.Controls.Add(this.button_cl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_cl1;
        private System.Windows.Forms.Button button_cl2;
        private System.Windows.Forms.Button button_cl3;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}