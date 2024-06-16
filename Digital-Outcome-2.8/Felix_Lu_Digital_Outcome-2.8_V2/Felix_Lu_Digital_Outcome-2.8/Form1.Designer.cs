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
            this.buttonCall.Location = new System.Drawing.Point(16, 263);
            this.buttonCall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.listBoxPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxPlayer.Name = "listBoxPlayer";
            this.listBoxPlayer.Size = new System.Drawing.Size(159, 116);
            this.listBoxPlayer.TabIndex = 2;
            // 
            // listBoxCommunityCards
            // 
            this.listBoxCommunityCards.FormattingEnabled = true;
            this.listBoxCommunityCards.ItemHeight = 16;
            this.listBoxCommunityCards.Location = new System.Drawing.Point(457, 50);
            this.listBoxCommunityCards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxCommunityCards.Name = "listBoxCommunityCards";
            this.listBoxCommunityCards.Size = new System.Drawing.Size(159, 116);
            this.listBoxCommunityCards.TabIndex = 3;
            // 
            // listBoxOpponent
            // 
            this.listBoxOpponent.FormattingEnabled = true;
            this.listBoxOpponent.ItemHeight = 16;
            this.listBoxOpponent.Location = new System.Drawing.Point(891, 50);
            this.listBoxOpponent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.buttonRaise.Location = new System.Drawing.Point(457, 263);
            this.buttonRaise.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRaise.Name = "buttonRaise";
            this.buttonRaise.Size = new System.Drawing.Size(100, 28);
            this.buttonRaise.TabIndex = 7;
            this.buttonRaise.Text = "&Raise";
            this.buttonRaise.UseVisualStyleBackColor = true;
            this.buttonRaise.Click += new System.EventHandler(this.buttonRaise_Click);
            // 
            // buttonFold
            // 
            this.buttonFold.Location = new System.Drawing.Point(891, 263);
            this.buttonFold.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFold.Name = "buttonFold";
            this.buttonFold.Size = new System.Drawing.Size(100, 28);
            this.buttonFold.TabIndex = 8;
            this.buttonFold.Text = "&Fold";
            this.buttonFold.UseVisualStyleBackColor = true;
            this.buttonFold.Click += new System.EventHandler(this.buttonFold_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(484, 511);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.buttonAllIn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.listBoxTesting.Location = new System.Drawing.Point(670, 299);
            this.listBoxTesting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxTesting.Name = "listBoxTesting";
            this.listBoxTesting.Size = new System.Drawing.Size(380, 404);
            this.listBoxTesting.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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

