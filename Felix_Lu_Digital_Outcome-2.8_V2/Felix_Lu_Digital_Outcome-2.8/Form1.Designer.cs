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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBank = new System.Windows.Forms.TextBox();
            this.textBoxBet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPot = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCall
            // 
            this.buttonCall.Location = new System.Drawing.Point(16, 263);
            this.buttonCall.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCall.Name = "buttonCall";
            this.buttonCall.Size = new System.Drawing.Size(100, 28);
            this.buttonCall.TabIndex = 0;
            this.buttonCall.Text = "&Call";
            this.buttonCall.UseVisualStyleBackColor = true;
            this.buttonCall.Click += new System.EventHandler(this.buttonCall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player:";
            // 
            // listBoxPlayer
            // 
            this.listBoxPlayer.FormattingEnabled = true;
            this.listBoxPlayer.ItemHeight = 16;
            this.listBoxPlayer.Location = new System.Drawing.Point(16, 50);
            this.listBoxPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxPlayer.Name = "listBoxPlayer";
            this.listBoxPlayer.Size = new System.Drawing.Size(159, 116);
            this.listBoxPlayer.TabIndex = 2;
            // 
            // listBoxCommunityCards
            // 
            this.listBoxCommunityCards.FormattingEnabled = true;
            this.listBoxCommunityCards.ItemHeight = 16;
            this.listBoxCommunityCards.Location = new System.Drawing.Point(457, 50);
            this.listBoxCommunityCards.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxCommunityCards.Name = "listBoxCommunityCards";
            this.listBoxCommunityCards.Size = new System.Drawing.Size(159, 116);
            this.listBoxCommunityCards.TabIndex = 3;
            // 
            // listBoxOpponent
            // 
            this.listBoxOpponent.FormattingEnabled = true;
            this.listBoxOpponent.ItemHeight = 16;
            this.listBoxOpponent.Location = new System.Drawing.Point(891, 50);
            this.listBoxOpponent.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxOpponent.Name = "listBoxOpponent";
            this.listBoxOpponent.Size = new System.Drawing.Size(159, 116);
            this.listBoxOpponent.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(453, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Community Cards:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(887, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Opponent:";
            // 
            // buttonRaise
            // 
            this.buttonRaise.Location = new System.Drawing.Point(16, 299);
            this.buttonRaise.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRaise.Name = "buttonRaise";
            this.buttonRaise.Size = new System.Drawing.Size(100, 28);
            this.buttonRaise.TabIndex = 7;
            this.buttonRaise.Text = "&Raise";
            this.buttonRaise.UseVisualStyleBackColor = true;
            this.buttonRaise.Click += new System.EventHandler(this.buttonRaise_Click);
            // 
            // buttonFold
            // 
            this.buttonFold.Location = new System.Drawing.Point(16, 341);
            this.buttonFold.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(100, 28);
            this.buttonFold.TabIndex = 8;
            this.buttonFold.Text = "&Fold";
            this.buttonFold.UseVisualStyleBackColor = true;
            this.buttonFold.Click += new System.EventHandler(this.buttonFold_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(16, 227);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(100, 28);
            this.buttonPlay.TabIndex = 9;
            this.buttonPlay.Text = "&Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonAllIn
            // 
            this.buttonAllIn.Location = new System.Drawing.Point(16, 377);
            this.buttonAllIn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAllIn.Name = "buttonAllIn";
            this.buttonAllIn.Size = new System.Drawing.Size(100, 28);
            this.buttonAllIn.TabIndex = 10;
            this.buttonAllIn.Text = "&All In";
            this.buttonAllIn.UseVisualStyleBackColor = true;
            this.buttonAllIn.Click += new System.EventHandler(this.buttonAllIn_Click);
            // 
            // listBoxTesting
            // 
            this.listBoxTesting.FormattingEnabled = true;
            this.listBoxTesting.ItemHeight = 16;
            this.listBoxTesting.Location = new System.Drawing.Point(670, 227);
            this.listBoxTesting.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxTesting.Name = "listBoxTesting";
            this.listBoxTesting.Size = new System.Drawing.Size(380, 404);
            this.listBoxTesting.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Bank:";
            // 
            // textBoxBank
            // 
            this.textBoxBank.Location = new System.Drawing.Point(287, 230);
            this.textBoxBank.Name = "textBoxBank";
            this.textBoxBank.ReadOnly = true;
            this.textBoxBank.Size = new System.Drawing.Size(100, 22);
            this.textBoxBank.TabIndex = 13;
            // 
            // textBoxBet
            // 
            this.textBoxBet.Location = new System.Drawing.Point(287, 258);
            this.textBoxBet.Name = "textBoxBet";
            this.textBoxBet.Size = new System.Drawing.Size(100, 22);
            this.textBoxBet.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bet:";
            // 
            // textBoxPot
            // 
            this.textBoxPot.Location = new System.Drawing.Point(287, 286);
            this.textBoxPot.Name = "textBoxPot";
            this.textBoxPot.ReadOnly = true;
            this.textBoxPot.Size = new System.Drawing.Size(100, 22);
            this.textBoxPot.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Pot:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.textBoxPot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxBank);
            this.Controls.Add(this.label4);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxBank;
        private System.Windows.Forms.TextBox textBoxBet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPot;
        private System.Windows.Forms.Label label6;
    }
}

