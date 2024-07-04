using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace Felix_Lu_Digital_Outcome_2._8
{
    public partial class Menu : Form
    {
        //Declare RNG
        Random rand = new Random();
        //Declare variables
        int card;
        int rotation = 0;
        //Declare music player
        SoundPlayer backgroundMusic;
        public Menu()
        {
            InitializeComponent();
            Playmusic();
        }
        private void Playmusic()
        {
            int song;
            song = rand.Next(0, 3);
            if (song == 0)
            {
                MXP.URL = @"allthat.mp3";
            }
            else if (song == 1) 
            {
                MXP.URL = @"badass.mp3";
            }
            else if (song == 2)
            {
                MXP.URL = @"straight.mp3";
            }
            MXP.Ctlcontrols.play();
            MXP.settings.playCount = 9999; // repeating the music when it ends
            MXP.Visible = false;
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Game gameWindow = new Game();
            gameWindow.Show();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuide_Click(object sender, EventArgs e)
        {
            Tutorial gameWindow = new Tutorial();
            gameWindow.Show();
        }

        private void EventTimer(object sender, EventArgs e)
        {
            rotation+=1;
            animation();
        }
        private void animation()
        {
            if (rotation%2 == 0)
            {
                card = rand.Next(0, 51);
                pictureBox1.Image = imageListCards.Images[card];
                pictureBox2.Image = imageListCards.Images[52];
                card = rand.Next(0, 51);
                pictureBox3.Image = imageListCards.Images[card];
                pictureBox4.Image = imageListCards.Images[52];
                card = rand.Next(0, 51);
                pictureBox5.Image = imageListCards.Images[card];
                pictureBox6.Image = imageListCards.Images[52];
                card = rand.Next(0, 51);
                pictureBox7.Image = imageListCards.Images[card];
            }
            else if (rotation%2 == 1)
            {
                pictureBox1.Image = imageListCards.Images[52];
                card = rand.Next(0, 51);
                pictureBox2.Image = imageListCards.Images[card];
                pictureBox3.Image = imageListCards.Images[52];
                card = rand.Next(0, 51);
                pictureBox4.Image = imageListCards.Images[card];
                pictureBox5.Image = imageListCards.Images[52];
                card = rand.Next(0, 51);
                pictureBox6.Image = imageListCards.Images[card];
                pictureBox7.Image = imageListCards.Images[52];
            }
        }
    }
}
