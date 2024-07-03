namespace Felix_Lu_Digital_Outcome_2._8
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonGuide = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.imageListCards = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.timerCards = new System.Windows.Forms.Timer(this.components);
            this.MXP = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MXP)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Font = new System.Drawing.Font("Modern No. 20", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.Location = new System.Drawing.Point(12, 625);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(900, 140);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonGuide
            // 
            this.buttonGuide.Font = new System.Drawing.Font("Modern No. 20", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGuide.Location = new System.Drawing.Point(12, 771);
            this.buttonGuide.Name = "buttonGuide";
            this.buttonGuide.Size = new System.Drawing.Size(700, 140);
            this.buttonGuide.TabIndex = 1;
            this.buttonGuide.Text = "Tutorial";
            this.buttonGuide.UseVisualStyleBackColor = true;
            this.buttonGuide.Click += new System.EventHandler(this.buttonGuide_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Font = new System.Drawing.Font("Modern No. 20", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuit.Location = new System.Drawing.Point(12, 917);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(500, 140);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Maroon;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 144F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(-50, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2800, 290);
            this.label1.TabIndex = 3;
            this.label1.Text = "Texas Hold\'em";
            // 
            // imageListCards
            // 
            this.imageListCards.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListCards.ImageStream")));
            this.imageListCards.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListCards.Images.SetKeyName(0, "00.png");
            this.imageListCards.Images.SetKeyName(1, "01.png");
            this.imageListCards.Images.SetKeyName(2, "02.png");
            this.imageListCards.Images.SetKeyName(3, "03.png");
            this.imageListCards.Images.SetKeyName(4, "04.png");
            this.imageListCards.Images.SetKeyName(5, "05.png");
            this.imageListCards.Images.SetKeyName(6, "06.png");
            this.imageListCards.Images.SetKeyName(7, "07.png");
            this.imageListCards.Images.SetKeyName(8, "08.png");
            this.imageListCards.Images.SetKeyName(9, "09.png");
            this.imageListCards.Images.SetKeyName(10, "10.png");
            this.imageListCards.Images.SetKeyName(11, "11.png");
            this.imageListCards.Images.SetKeyName(12, "12.png");
            this.imageListCards.Images.SetKeyName(13, "13.png");
            this.imageListCards.Images.SetKeyName(14, "14.png");
            this.imageListCards.Images.SetKeyName(15, "15.png");
            this.imageListCards.Images.SetKeyName(16, "16.png");
            this.imageListCards.Images.SetKeyName(17, "17.png");
            this.imageListCards.Images.SetKeyName(18, "18.png");
            this.imageListCards.Images.SetKeyName(19, "19.png");
            this.imageListCards.Images.SetKeyName(20, "20.png");
            this.imageListCards.Images.SetKeyName(21, "21.png");
            this.imageListCards.Images.SetKeyName(22, "22.png");
            this.imageListCards.Images.SetKeyName(23, "23.png");
            this.imageListCards.Images.SetKeyName(24, "24.png");
            this.imageListCards.Images.SetKeyName(25, "25.png");
            this.imageListCards.Images.SetKeyName(26, "26.png");
            this.imageListCards.Images.SetKeyName(27, "27.png");
            this.imageListCards.Images.SetKeyName(28, "28.png");
            this.imageListCards.Images.SetKeyName(29, "29.png");
            this.imageListCards.Images.SetKeyName(30, "30.png");
            this.imageListCards.Images.SetKeyName(31, "31.png");
            this.imageListCards.Images.SetKeyName(32, "32.png");
            this.imageListCards.Images.SetKeyName(33, "33.png");
            this.imageListCards.Images.SetKeyName(34, "34.png");
            this.imageListCards.Images.SetKeyName(35, "35.png");
            this.imageListCards.Images.SetKeyName(36, "36.png");
            this.imageListCards.Images.SetKeyName(37, "37.png");
            this.imageListCards.Images.SetKeyName(38, "38.png");
            this.imageListCards.Images.SetKeyName(39, "39.png");
            this.imageListCards.Images.SetKeyName(40, "40.png");
            this.imageListCards.Images.SetKeyName(41, "41.png");
            this.imageListCards.Images.SetKeyName(42, "42.png");
            this.imageListCards.Images.SetKeyName(43, "43.png");
            this.imageListCards.Images.SetKeyName(44, "44.png");
            this.imageListCards.Images.SetKeyName(45, "45.png");
            this.imageListCards.Images.SetKeyName(46, "46.png");
            this.imageListCards.Images.SetKeyName(47, "47.png");
            this.imageListCards.Images.SetKeyName(48, "48.png");
            this.imageListCards.Images.SetKeyName(49, "49.png");
            this.imageListCards.Images.SetKeyName(50, "50.png");
            this.imageListCards.Images.SetKeyName(51, "51.png");
            this.imageListCards.Images.SetKeyName(52, "52.png");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox1.Location = new System.Drawing.Point(12, 300);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 280);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox2.Location = new System.Drawing.Point(295, 300);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 280);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox3.Location = new System.Drawing.Point(578, 300);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(300, 280);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox4.Location = new System.Drawing.Point(862, 300);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(300, 280);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox5.Location = new System.Drawing.Point(1145, 300);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(300, 280);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 8;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 144F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(-436, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2800, 16);
            this.label2.TabIndex = 9;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox6.Location = new System.Drawing.Point(1428, 300);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(300, 280);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Felix_Lu_Digital_Outcome_2._8.Properties.Resources._52;
            this.pictureBox7.Location = new System.Drawing.Point(1711, 300);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(300, 280);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 17;
            this.pictureBox7.TabStop = false;
            // 
            // timerCards
            // 
            this.timerCards.Enabled = true;
            this.timerCards.Interval = 1000;
            this.timerCards.Tick += new System.EventHandler(this.EventTimer);
            // 
            // MXP
            // 
            this.MXP.Enabled = true;
            this.MXP.Location = new System.Drawing.Point(1689, 12);
            this.MXP.Name = "MXP";
            this.MXP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MXP.OcxState")));
            this.MXP.Size = new System.Drawing.Size(223, 45);
            this.MXP.TabIndex = 18;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.ControlBox = false;
            this.Controls.Add(this.MXP);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonGuide);
            this.Controls.Add(this.buttonPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MXP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonGuide;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageListCards;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Timer timerCards;
        private AxWMPLib.AxWindowsMediaPlayer MXP;
    }
}