
namespace task3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_draw = new System.Windows.Forms.Button();
            this.button_fill = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button_fill_pic = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button_take_border = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(-5, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(979, 626);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button_draw
            // 
            this.button_draw.Enabled = false;
            this.button_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_draw.Location = new System.Drawing.Point(996, 57);
            this.button_draw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_draw.Name = "button_draw";
            this.button_draw.Size = new System.Drawing.Size(195, 46);
            this.button_draw.TabIndex = 1;
            this.button_draw.Text = "Рисование";
            this.button_draw.UseVisualStyleBackColor = true;
            this.button_draw.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_fill
            // 
            this.button_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_fill.Location = new System.Drawing.Point(996, 130);
            this.button_fill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_fill.Name = "button_fill";
            this.button_fill.Size = new System.Drawing.Size(195, 70);
            this.button_fill.TabIndex = 2;
            this.button_fill.Text = "Заливка цветом";
            this.button_fill.UseVisualStyleBackColor = true;
            this.button_fill.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(996, 206);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбор цвета";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_fill_pic
            // 
            this.button_fill_pic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_fill_pic.Location = new System.Drawing.Point(996, 272);
            this.button_fill_pic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_fill_pic.Name = "button_fill_pic";
            this.button_fill_pic.Size = new System.Drawing.Size(195, 70);
            this.button_fill_pic.TabIndex = 4;
            this.button_fill_pic.Text = "Заливка картинкой";
            this.button_fill_pic.UseVisualStyleBackColor = true;
            this.button_fill_pic.Click += new System.EventHandler(this.button_fill_pic_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(996, 347);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 69);
            this.button3.TabIndex = 5;
            this.button3.Text = "Выбор картинки";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_take_border
            // 
            this.button_take_border.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_take_border.Location = new System.Drawing.Point(996, 448);
            this.button_take_border.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_take_border.Name = "button_take_border";
            this.button_take_border.Size = new System.Drawing.Size(191, 78);
            this.button_take_border.TabIndex = 7;
            this.button_take_border.Text = "Выбрать границу ";
            this.button_take_border.UseVisualStyleBackColor = true;
            this.button_take_border.Click += new System.EventHandler(this.button_take_border_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(996, 561);
            this.button_clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(191, 53);
            this.button_clear.TabIndex = 8;
            this.button_clear.Text = "Очистить";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1057, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 9;
            this.button2.Text = "save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 629);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_take_border);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_fill_pic);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_fill);
            this.Controls.Add(this.button_draw);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_draw;
        private System.Windows.Forms.Button button_fill;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_fill_pic;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_take_border;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button2;
    }
}

