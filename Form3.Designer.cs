
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
            this.button_get_triang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(847, 539);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(875, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "Растеризовать случайный треугольник";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_cl1
            // 
            this.button_cl1.Location = new System.Drawing.Point(875, 106);
            this.button_cl1.Margin = new System.Windows.Forms.Padding(4);
            this.button_cl1.Name = "button_cl1";
            this.button_cl1.Size = new System.Drawing.Size(144, 30);
            this.button_cl1.TabIndex = 2;
            this.button_cl1.Text = "Выбрать цвет 1";
            this.button_cl1.UseVisualStyleBackColor = true;
            this.button_cl1.Click += new System.EventHandler(this.button_cl1_Click);
            // 
            // button_cl2
            // 
            this.button_cl2.Location = new System.Drawing.Point(875, 143);
            this.button_cl2.Margin = new System.Windows.Forms.Padding(4);
            this.button_cl2.Name = "button_cl2";
            this.button_cl2.Size = new System.Drawing.Size(144, 30);
            this.button_cl2.TabIndex = 3;
            this.button_cl2.Text = "Выбрать цвет 2";
            this.button_cl2.UseVisualStyleBackColor = true;
            this.button_cl2.Click += new System.EventHandler(this.button_cl2_Click);
            // 
            // button_cl3
            // 
            this.button_cl3.Location = new System.Drawing.Point(875, 180);
            this.button_cl3.Margin = new System.Windows.Forms.Padding(4);
            this.button_cl3.Name = "button_cl3";
            this.button_cl3.Size = new System.Drawing.Size(144, 30);
            this.button_cl3.TabIndex = 4;
            this.button_cl3.Text = "Выбрать цвет 3";
            this.button_cl3.UseVisualStyleBackColor = true;
            this.button_cl3.Click += new System.EventHandler(this.button_cl3_Click);
            // 
            // button_get_triang
            // 
            this.button_get_triang.Location = new System.Drawing.Point(875, 237);
            this.button_get_triang.Margin = new System.Windows.Forms.Padding(4);
            this.button_get_triang.Name = "button_get_triang";
            this.button_get_triang.Size = new System.Drawing.Size(176, 69);
            this.button_get_triang.TabIndex = 5;
            this.button_get_triang.Text = "Задать треугольник";
            this.button_get_triang.UseVisualStyleBackColor = true;
            this.button_get_triang.Click += new System.EventHandler(this.button_get_triang_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button_get_triang);
            this.Controls.Add(this.button_cl3);
            this.Controls.Add(this.button_cl2);
            this.Controls.Add(this.button_cl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button_get_triang;
    }
}