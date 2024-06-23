namespace Felix_Lu_Digital_Outcome_2._8
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
            this.buttonCall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxPlayer = new System.Windows.Forms.ListBox();
            this.listBoxCommunityCards = new System.Windows.Forms.ListBox();
            this.listBoxOpponent = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRaise = new System.Windows.Forms.Button();
            this.buttonFold = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonAllIn = new System.Windows.Forms.Button();
            this.listBoxTesting = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonCall
            // 
            this.buttonCall.Location = new System.Drawing.Point(12, 214);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(75, 23);
            this.buttonCall.TabIndex = 0;
            this.buttonCall.Text = "&Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.buttonCall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player:";
            // 
            // listBoxPlayer
            // 
            this.listBoxPlayer.FormattingEnabled = true;
            this.listBoxPlayer.Location = new System.Drawing.Point(12, 41);
            this.listBoxPlayer.Name = "listBoxPlayer";
            this.listBoxPlayer.Size = new System.Drawing.Size(120, 95);
            this.listBoxPlayer.TabIndex = 2;
            // 
            // listBoxCommunityCards
            // 
            this.listBoxCommunityCards.FormattingEnabled = true;
            this.listBoxCommunityCards.Location = new System.Drawing.Point(343, 41);
            this.listBoxCommunityCards.Name = "listBoxCommunityCards";
            this.listBoxCommunityCards.Size = new System.Drawing.Size(120, 95);
            this.listBoxCommunityCards.TabIndex = 3;
            // 
            // listBoxOpponent
            // 
            this.listBoxOpponent.FormattingEnabled = true;
            this.listBoxOpponent.Location = new System.Drawing.Point(668, 41);
            this.listBoxOpponent.Name = "listBoxOpponent";
            this.listBoxOpponent.Size = new System.Drawing.Size(120, 95);
            this.listBoxOpponent.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Community Cards:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(665, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Opponent:";
            // 
            // buttonRaise
            // 
            this.buttonRaise.Location = new System.Drawing.Point(343, 214);
            this.buttonRaise.Name = "buttonRaise";
            this.buttonRaise.Size = new System.Drawing.Size(75, 23);
            this.buttonRaise.TabIndex = 7;
            this.buttonRaise.Text = "&Raise";
            this.buttonRaise.UseVisualStyleBackColor = true;
            this.buttonRaise.Click += new System.EventHandler(this.buttonRaise_Click);
            // 
            // buttonFold
            // 
            this.buttonFold.Location = new System.Drawing.Point(668, 214);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(75, 23);
            this.buttonFold.TabIndex = 8;
            this.buttonFold.Text = "&Fold";
            this.buttonFold.UseVisualStyleBackColor = true;
            this.buttonFold.Click += new System.EventHandler(this.buttonFold_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(363, 415);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(75, 23);
            this.buttonPlay.TabIndex = 9;
            this.buttonPlay.Text = "&Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonAllIn
            // 
            this.buttonAllIn.Location = new System.Drawing.Point(12, 306);
            this.buttonAllIn.Name = "buttonAllIn";
            this.buttonAllIn.Size = new System.Drawing.Size(75, 23);
            this.buttonAllIn.TabIndex = 10;
            this.buttonAllIn.Text = "&All In";
            this.buttonAllIn.UseVisualStyleBackColor = true;
            this.buttonAllIn.Click += new System.EventHandler(this.buttonAllIn_Click);
            // 
            // listBoxTesting
            // 
            this.listBoxTesting.FormattingEnabled = true;
            this.listBoxTesting.Location = new System.Drawing.Point(502, 306);
            this.listBoxTesting.Name = "listBoxTesting";
            this.listBoxTesting.Size = new System.Drawing.Size(286, 95);
            this.listBoxTesting.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxTesting);
            this.Controls.Add(this.buttonAllIn);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonFold);
            this.Controls.Add(this.buttonRaise);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxOpponent);
            this.Controls.Add(this.listBoxCommunityCards);
            this.Controls.Add(this.listBoxPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPlayer;
        private System.Windows.Forms.ListBox listBoxCommunityCards;
        private System.Windows.Forms.ListBox listBoxOpponent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRaise;
        private System.Windows.Forms.Button buttonFold;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonAllIn;
        private System.Windows.Forms.ListBox listBoxTesting;
    }
}

