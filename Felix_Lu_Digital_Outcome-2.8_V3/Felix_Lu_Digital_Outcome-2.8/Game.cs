using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Felix_Lu_Digital_Outcome_2._8
{
    public partial class Game : Form
    {
        List<Card> cards = new List<Card>();
        List<string> imageLocation = new List<string>();
        Card SelectedCard;
        int cardNumber = -1;
        int indexValue;
        int xPos = 5;
        int back = 52;
        bool clicked = false;
        public Game()
        {
            InitializeComponent();
            SetupApp();
        }
        private void SetupApp()
        {
            imageLocation = Directory.GetFiles("Sprites", "*png").ToList();
            for (int i = 0; i < imageLocation.Count; i++)
            {
                MakeCards();
            }
        }
        private void MakeCards()
        {
            cardNumber++;
            xPos += 30;
            Card newCard = new Card(imageLocation[cardNumber]);
            newCard.position.X = xPos;
            newCard.position.Y = 300;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            cards.Add(newCard);
        }
        private void FormPaint(object sender, PaintEventArgs e)
        {
            foreach (Card card in cards)
            {
                e.Graphics.DrawImage(card.cardPic, card.position.X, card.position.Y, card.width, card.height);
            }
        }


    }
}
