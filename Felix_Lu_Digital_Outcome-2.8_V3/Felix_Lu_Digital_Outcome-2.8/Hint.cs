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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Felix_Lu_Digital_Outcome_2._8
{
    public partial class Hint : Form
    {
        List<Card> card = new List<Card>();
        List<string> imageLocation = new List<string>();
        List<int> suit = new List<int>();
        int x;
        int y1 = 153;
        int y2 = 506;
        int cardNumber = 0;
        int full;
        int house;
        int straight;
        int flush;
        int fiveCardHand = 5;
        int show;
        int height;
        int width;
        Random rand = new Random();
        public Hint()
        {
            InitializeComponent();
            GettingSizes();
            SetupApp();
        }
        private void GettingSizes()
        {
            height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
            width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width;
            buttonClose.Location = new Point(width - 65, height-10);
            for (int i = 0; i < 13;i++)
            {
                suit.Add(i);
            }
        }

        private void SetupApp()
        {
            pictureBoxRF1.Hide();
            pictureBoxS1.Hide();
            imageLocation = Directory.GetFiles("Sprites", "*png").ToList();
            show = rand.Next(0, fiveCardHand - 1);
            cardNumber = 9 + (13 * show);
            x = 0;
            for (int i = 0; i < fiveCardHand; i++)
            {
                RoyalFlush();
            }
            labelRF.Location = new Point(30, y1+225);
            labelRF.Text = "1. Royal Flush";
            show = rand.Next(0, fiveCardHand - 1);
            cardNumber = rand.Next(0, 9);
            cardNumber = cardNumber + (13 * show);
            x = (width / 5) /*-148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                StraightFlush();
            }
            labelSF.Location = new Point(width/5 + 30, y1 + 225);
            labelSF.Text = "2. Straight Flush";
            show = rand.Next(0, fiveCardHand - 1);
            cardNumber = rand.Next(0, 13);
            cardNumber = cardNumber + (13 * show);
            x = (width / 5 * 2) /*- 148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                if (i == 0)
                {
                    Back(y1);
                }
                else
                {
                    FourOfAKind();
                }
            }
            labelFOAK.Location = new Point(width / 5 * 2 + 30, y1 + 225);
            labelFOAK.Text = "3. Four of a Kind";
            show = rand.Next(0, fiveCardHand - 1);
            full = rand.Next(0, 13);
            full = full + (13 * show);
            house = rand.Next(0, 13);
            house = house + (13 * show);
            x = (width / 5 * 3) /*- 148*/;
            if (house != full)
            {
                for (int i = 0; i < fiveCardHand; i++)
                {
                    FullHouse(i);
                }
            }
            else
            {
                while (house == full)
                {
                    house = rand.Next(0, 13);
                    house = house + (13 * show);
                }
                for (int i = 0; i < fiveCardHand; i++)
                {
                    FullHouse(i);
                }
            }
            labelFH.Location = new Point(width / 5 * 3 + 30, y1 + 225);
            labelFH.Text = "4. Full House";
            show = rand.Next(0, fiveCardHand - 1);
            x = (width / 5 * 4) /*- 148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                cardNumber = rand.Next(0, suit.Count()-1);
                flush = suit[cardNumber] + (13 * show);
                Flush();
                suit.RemoveAt(cardNumber);
            }
            labelF.Location = new Point(width / 5 * 4 + 30, y1 + 225);
            labelF.Text = "5. Flush";
            show = rand.Next(0, fiveCardHand - 1);
            cardNumber = rand.Next(0, 9);
            straight = cardNumber;
            x = 0 /*-148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                show = rand.Next(0, fiveCardHand - 1);
                straight += (13 * show);
                Straight();
            }
            labelS.Location = new Point(30, y2 + 225);
            labelS.Text = "6. Straight";
            show = rand.Next(0, fiveCardHand - 1);
            full = rand.Next(0, 9);
            full = full + (13 * show);
            x = (width / 5) /*-148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                if (i < 2)
                {
                    Back(y2);
                }
                else
                {
                    ThreeOfAKind();
                }
            }
            labelTOAK.Location = new Point(width / 5 + 30, y2 + 225);
            labelTOAK.Text = "7. Three of a Kind";
            full = rand.Next(0, 13);
            house = rand.Next(0, 13);
            x = (width / 5 * 2) /*- 148*/;
            if (house != full)
            {
                show = rand.Next(0, fiveCardHand - 1);
                full += (13 * show);
                show = rand.Next(0, fiveCardHand - 1);
                house += (13 * show);
                for (int i = 0; i < fiveCardHand; i++)
                {
                    if (i == 0)
                    {
                        Back(y2);
                    }
                    else if (i > 0 && i < 3)
                    {
                        TwoPair(full);
                        full += 13;
                    }
                    else
                    {
                        TwoPair(house);
                        house += 13;
                    }
                }
            }
            else
            {
                while (house == full)
                {
                    house = rand.Next(0, 13);
                }
                show = rand.Next(0, fiveCardHand - 1);
                house += (13 * show);
                for (int i = 0; i < fiveCardHand; i++)
                {
                    if (i == 0)
                    {
                        Back(y2);
                    }
                    else if (i > 0 && i < 3)
                    {
                        TwoPair(full);
                        full += 13;
                    }
                    else
                    {
                        TwoPair(house);
                        house += 13;
                    }
                }
            }
            labelTP.Location = new Point(width / 5 * 2 + 30, y2 + 225);
            labelTP.Text = "8. Two Pair";
            show = rand.Next(0, fiveCardHand - 1);
            house = rand.Next(0, 9);
            house = full + (13 * show);
            x = (width / 5 * 3) /*-148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                if (i < 3)
                {
                    Back(y2);
                }
                else
                {
                    Pair();
                }
            }
            labelP.Location = new Point(width / 5 * 3 + 30, y2 + 225);
            labelP.Text = "9. One Pair";
            show = rand.Next(0, fiveCardHand - 1);
            cardNumber = rand.Next(9, 13);
            cardNumber = cardNumber + (13 * show);
            x = (width / 5 * 4) /*- 148*/;
            for (int i = 0; i < fiveCardHand; i++)
            {
                if (i < 4)
                {
                    Back(y2);
                }
                else
                {
                    HighCard();
                }
            }
            labelHC.Location = new Point(width / 5 * 4 + 30, y2 + 225);
            labelHC.Text = "10. High Card";
        }
        private void Back(int y)
        {
            Card newCard = new Card(imageLocation[52]);
            newCard.position.X = x;
            newCard.position.Y = y;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            card.Add(newCard);
        }
        private void RoyalFlush()
        {
            Card newCard = new Card(imageLocation[cardNumber]);
            newCard.position.X = x;
            newCard.position.Y = y1;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            cardNumber++;
            if (cardNumber % 13 == 0)
            {
                cardNumber -= 13;
            }
            card.Add(newCard);
        }
        private void StraightFlush()
        {
            Card newCard = new Card(imageLocation[cardNumber]);
            newCard.position.X = x;
            newCard.position.Y = y1;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            cardNumber++;
            card.Add(newCard);
        }
        private void FourOfAKind()
        {
            if(cardNumber > 51)
            {
                cardNumber -= 52;
            }
            Card newCard = new Card(imageLocation[cardNumber]);
            newCard.position.X = x;
            newCard.position.Y = y1;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            cardNumber += 13;
            x += 24;
            card.Add(newCard);
        }
        private void FullHouse(int counter)
        {
            if (counter < 3)
            {
                if (full > 51)
                {
                    full -= 52;
                }
                Card newCard = new Card(imageLocation[full]);
                newCard.position.X = x;
                newCard.position.Y = y1;
                newCard.rect.X = newCard.position.X;
                newCard.rect.Y = newCard.position.Y;
                x += 24;
                full += 13;
                card.Add(newCard);
            }
            else
            {
                if (house > 51)
                {
                    house -= 52;
                }
                Card newCard = new Card(imageLocation[house]);
                newCard.position.X = x;
                newCard.position.Y = y1;
                newCard.rect.X = newCard.position.X;
                newCard.rect.Y = newCard.position.Y;
                x += 24;
                house += 13;
                card.Add(newCard);
            }
        }
        private void Flush()
        {
            if (flush > 51)
            {
                flush -= 52;
            }
            Card newCard = new Card(imageLocation[flush]);
            newCard.position.X = x;
            newCard.position.Y = y1;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            card.Add(newCard);
        }
        private void Straight()
        {
            if (straight > 51)
            {
                straight -= 52;
            }
            Card newCard = new Card(imageLocation[straight]);
            newCard.position.X = x;
            newCard.position.Y = y2;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            straight++;
            card.Add(newCard);
        }
        private void ThreeOfAKind()
        {
            if (full > 51)
            {
                full -= 52;
            }
            Card newCard = new Card(imageLocation[full]);
            newCard.position.X = x;
            newCard.position.Y = y2;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            full += 13;
            card.Add(newCard);
        }
        private void TwoPair(int pair)
        {
            if (pair > 51)
            {
                pair -= 52;
            }
            Card newCard = new Card(imageLocation[pair]);
            newCard.position.X = x;
            newCard.position.Y = y2;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            card.Add(newCard);
        }
        private void Pair()
        {
            if (house > 51)
            {
                house -= 52;
            }
            Card newCard = new Card(imageLocation[house]);
            newCard.position.X = x;
            newCard.position.Y = y2;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            x += 24;
            house += 13;
            card.Add(newCard);
        }
        private void HighCard()
        {
            if (cardNumber > 51)
            {
                cardNumber -= 52;
            }
            Card newCard = new Card(imageLocation[cardNumber]);
            newCard.position.X = x;
            newCard.position.Y = y2;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            cardNumber += 13;
            x += 24;
            card.Add(newCard);
        }
        private void EventPaint(object sender, PaintEventArgs e)
        {
            foreach (Card card in card)
            {
                e.Graphics.DrawImage(card.cardPic, card.position.X, card.position.Y, card.width, card.height);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
