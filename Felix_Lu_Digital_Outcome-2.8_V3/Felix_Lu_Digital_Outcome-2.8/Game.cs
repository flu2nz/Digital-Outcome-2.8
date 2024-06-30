using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Felix_Lu_Digital_Outcome_2._8
{
    public partial class Game : Form
    {
        //Declare Constants
        const int HOLECARDS = 2;
        const int MONEY = 2000;
        const int MINBET = 100;
        //Declare RNG
        Random rand = new Random();
        //Declare Lists
        List<int> cards = new List<int>();
        List<int> pH = new List<int>();
        List<int> communityCards = new List<int>();
        List<int> aH = new List<int>();
        List<int> bH = new List<int>();
        List<int> dH = new List<int>();
        HashSet<int> distinct = new HashSet<int>();
        HashSet<int> duplicate = new HashSet<int>();
        List<int> dupDup = new List<int>();
        //Declare Varaibles
        bool aPlaying = false;
        bool pPlaying = false;
        bool bPlaying = false;
        bool dPlaying = false;
        string line;
        string[] data;
        int cardValue;
        int pBank = MONEY;
        int aBank = MONEY;
        int bBank = MONEY;
        int dBank = MONEY;
        int pot;
        int call = MINBET / 2;
        bool prebet = false;
        bool skip = false;
        bool warned = false;
        bool hc = false;
        int cLikes = 0;
        int cOne = 0;
        int cTwo = 0;
        int tp = 0;
        int player = 0;
        string name;

        List<Card> card = new List<Card>();
        List<string> imageLocation = new List<string>();
        int xPos = 1185;
        int test = 7;
        int yPos = 50;
        public Game()
        {
            InitializeComponent();
            SetupApp();
            GameStart();
        }
        private void GameStart()
        {
            if (pBank < 50)
            {
                MessageBox.Show("You have insufficient funds to participate in another game you need a minimum of $50 to participate.\nPlease come back when you have sufficient funds.");
                this.Close();
            }
            else
            {
                buttonA.Text = null;
                buttonB.Text = null;
                buttonD.Text = null;
                buttonP.Text = null;
                hc = false;
                skip = false;
                prebet = true;
                warned = false;
                buttonBlind.Show();
                buttonAnteUp.Show();
                buttonCall.Enabled = false;
                buttonRaise.Enabled = false;
                buttonFold.Enabled = false;
                buttonAllIn.Enabled = false;
                if (aBank < pBank)
                {
                    aBank = pBank / 95 * 100;
                }
                pH.Clear();
                aH.Clear();
                bH.Clear();
                dH.Clear();
                distinct.Clear();
                duplicate.Clear();
                cards.Clear();
                communityCards.Clear();
                textBoxCall.Clear();
                textBoxBet.Clear();
                textBoxPot.Clear();
                call = MINBET / 2;
                pot = 0;
                cLikes = 0;
                cOne = 0;
                cTwo = 0;
                tp = 0;
                player = 0;
                textBoxBet.ReadOnly = false;
                pictureBoxP1.Image = imageListCards.Images[52];
                pictureBoxP2.Image = imageListCards.Images[52];
                pictureBoxC1.Image = imageListCards.Images[52];
                pictureBoxC2.Image = imageListCards.Images[52];
                pictureBoxC3.Image = imageListCards.Images[52];
                pictureBoxC4.Image = imageListCards.Images[52];
                pictureBoxC5.Image = imageListCards.Images[52];
                pictureBoxA1.Image = imageListCards.Images[52];
                pictureBoxA2.Image = imageListCards.Images[52];
                pictureBoxB1.Image = imageListCards.Images[52];
                pictureBoxB2.Image = imageListCards.Images[52];
                pictureBoxD1.Image = imageListCards.Images[52];
                pictureBoxD2.Image = imageListCards.Images[52];
                labelP.Text = $"{pBank}";
                labelAb.Text = $"{aBank}";
                using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        cards.Add(Convert.ToInt32(data[0]));
                    }
                }
                //System.Threading.Thread.Sleep(500);
            }
        }
        private void SetupApp()
        {
            imageLocation = Directory.GetFiles("Sprites", "*png").ToList();
            for (int i = 0; i < 53; i++)
            {
                MakeCards();
            }
        }
        private void buttonName_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            labelName.Text = name;
            textBoxName.Hide();
            buttonName.Hide();
            aBet();
        }
        private void EventClick(object sender, EventArgs e)
        {
            textBoxName.Clear();
        }
        private void MakeCards()
        {
            //cardNumber++;
            Card newCard = new Card(imageLocation[52]);
            newCard.position.X = xPos;
            newCard.position.Y = yPos;
            newCard.rect.X = newCard.position.X;
            newCard.rect.Y = newCard.position.Y;
            card.Add(newCard);
        }
        private void FormPaint(object sender, PaintEventArgs e)
        {
            foreach (Card card in card)
            {
                e.Graphics.DrawImage(card.cardPic, card.position.X, card.position.Y, card.width, card.height);
            }
            //System.Threading.Thread.Sleep(1000);
        }
        private void buttonHint_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonBlind_Click(object sender, EventArgs e)
        {
            pBank -= call;
            pot += call;
            textBoxPot.Text = $"{pot}";
            buttonBlind.Hide();
            buttonAnteUp.Hide();
            buttonP.Text = " Blind ";
            labelP.Text = $"{pBank}";
            textBoxCall.Text = $"{call}";
            if (pBank == 0)
            {
                skip = true;
            }
            //System.Threading.Thread.Sleep(500);
            dBet();
        }
        private void buttonAnteUp_Click(object sender, EventArgs e)
        {
            textBoxBet.Show();
            buttonBet.Show();
            if (pBank < call)
            {
                textBoxBet.Text = $"{pBank}";
                textBoxBet.ReadOnly = true;
            }
        }
        private void buttonBet_Click(object sender, EventArgs e)
        {
            int bet;
            if (int.TryParse(textBoxBet.Text, out bet) == true)
            {
                if (prebet == true)
                {
                    if (bet <= MINBET / 2)
                    {
                        MessageBox.Show($"Please make a bet which is greater than {MINBET / 2}.");
                    }
                    else if (bet > 200)
                    {
                        MessageBox.Show("The maximum bet in the Blind round is 200.");
                    }
                    else
                    {
                        if (pBank < call)
                        {
                            pot += pBank;
                            pBank = 0;
                            buttonBlind.Hide();
                            buttonAnteUp.Hide();
                            buttonP.Text = "Ante Up";
                            labelP.Text = $"{pBank}";
                            textBoxCall.Text = $"{call}";
                            skip = true;
                        }
                        else
                        {
                            //call = bet;
                            pBank -= bet;
                            pot += bet;
                            buttonBlind.Hide();
                            buttonAnteUp.Hide();
                            buttonP.Text = "Ante Up";
                            labelP.Text = $"{pBank}";
                            //textBoxCall.Text = $"{call}";
                        }
                        //System.Threading.Thread.Sleep(500);
                        dBet();
                    }
                }
                else
                {
                    if (bet <= call)
                    {
                        MessageBox.Show($"Please make a bet which is greater than {call}.");
                    }
                    else if (bet == pBank)
                    {
                        if (warned == false)
                        {
                            MessageBox.Show($"If you bet {pBank} this is an all in.\nPress bet again to confirm the all in.");
                            warned = true;
                        }
                        else
                        {
                            pBank = 0;
                            pot += bet;
                            skip = true;
                            buttonP.Text = "Raise";
                            labelP.Text = $"{pBank}";
                            textBoxCall.Text = $"{call}";
                            //System.Threading.Thread.Sleep(500);
                            dBet();
                        }
                    }
                    else if (bet > pBank)
                    {
                        MessageBox.Show($"You do not possess ${bet}, so you cannot bet that much.");
                        textBoxBet.Clear();
                        textBoxBet.Focus();
                    }
                    else
                    {
                        if (pBank < call)
                        {
                            pot += pBank;
                            pBank = 0;
                            buttonBlind.Hide();
                            buttonAnteUp.Hide();
                            buttonP.Text = "Raise";
                            labelP.Text = $"{pBank}";
                            textBoxCall.Text = $"{call}";
                            skip = true;
                        }
                        else
                        {
                            call = bet;
                            pBank -= bet;
                            pot += call;
                            buttonBlind.Hide();
                            buttonAnteUp.Hide();
                            buttonP.Text = "Raise";
                            labelP.Text = $"{pBank}";
                            textBoxCall.Text = $"{call}";
                        }
                        //System.Threading.Thread.Sleep(500);
                        dBet();
                    }
                }
            }
            else
            {
                MessageBox.Show($"Please place a bet which is an int. E.g {call}.");
            }
        }
        private void buttonCall_Click(object sender, EventArgs e)
        {
            if (pBank < call)
            {
                pot += pBank;
                pBank = 0;
                skip = true;
            }
            else
            {
                pBank -= call;
                pot += call;
            }
            textBoxCall.Text = $"{call}";
            buttonP.Text = "Call";
            labelP.Text = $"{pBank}";
            //System.Threading.Thread.Sleep(500);
            dBet();
        }
        private void buttonRaise_Click(object sender, EventArgs e)
        {
            textBoxBet.Show();
            buttonBet.Show();
            if (pBank < call)
            {
                textBoxBet.Text = $"{pBank}";
                textBoxBet.ReadOnly = true;
            }
        }
        private void buttonFold_Click(object sender, EventArgs e)
        {
            pPlaying = false;
            skip = true;
            buttonP.Text = "Fold";
            //System.Threading.Thread.Sleep(500);
            dBet();
        }
        private void buttonAllIn_Click(object sender, EventArgs e)
        {
            call = pBank;
            pBank = 0;
            pot += call;
            skip = true;
            labelP.Text = $"{pBank}";
            textBoxCall.Text = $"{call}";
            buttonP.Text = "All In";
            //System.Threading.Thread.Sleep(500);
            dBet();
        }
        private void aBet()
        {
            //buttonA.Text = null;
            //buttonB.Text = null;
            //buttonD.Text = null;
            //if (pPlaying == true)
            //{
            //    buttonP.Text = null;
            //}
            int action;
            int raise;
            action = rand.Next(0, 4);
            raise = rand.Next(0, 11);
            if (prebet == true)
            {
                if (action < 3)
                {
                    buttonA.Text = " Blind ";
                }
                else
                {
                    call += raise * 5;
                    buttonA.Text = " Ante Up ";
                }
            }
            else
            {
                if (aPlaying == true)
                {
                    if (action < 3)
                    {
                        buttonA.Text = " Call ";
                    }
                    else
                    {
                        call += raise * 10;
                        buttonA.Text = " Raise ";
                    }
                }
            }
            aBank -= call;
            pot += call;
            textBoxPot.Text = $"{pot}";
            labelAb.Text = $"{aBank}";
            textBoxCall.Text = $"{call}";
            //System.Threading.Thread.Sleep(500);
            bBet();
        }
        private void bBet()
        {
            //buttonB.Text = null;
            int action;
            int raise;
            action = rand.Next(0, 4);
            raise = rand.Next(0, 11);
            if (prebet == true)
            {
                if (action < 3)
                {
                    buttonB.Text = " Blind ";
                }
                else
                {
                    call += raise * 5;
                    buttonB.Text = " Ante Up ";
                }
                bBank -= call;
                pot += call;
                textBoxPot.Text = $"{pot}";
                labelBb.Text = $"{bBank}";
                textBoxCall.Text = $"{call}";
            }
            else
            {
                if (bPlaying == true)
                {
                    if (action < 3)
                    {
                        buttonB.Text = " Call ";
                    }
                    else
                    {
                        call += raise * 10;
                        buttonB.Text = " Raise ";
                    }
                    bBank -= call;
                    pot += call;
                    textBoxPot.Text = $"{pot}";
                    labelBb.Text = $"{bBank}";
                    textBoxCall.Text = $"{call}";
                }
            }
            //System.Threading.Thread.Sleep(500);
            buttonP.Text = null;
            buttonCall.Enabled = true;
            buttonRaise.Enabled = true;
            buttonFold.Enabled = true;
            buttonAllIn.Enabled = true;
        }
        private void dBet()
        {
            buttonCall.Enabled = false;
            buttonRaise.Enabled = false;
            buttonFold.Enabled = false;
            buttonAllIn.Enabled = false;
            warned = false;
            buttonBet.Hide();
            textBoxBet.Hide();
            int action;
            int raise;
            action = rand.Next(0, 4);
            raise = rand.Next(0, 11);
            if (prebet == true)
            {
                if (action < 3)
                {
                    buttonD.Text = " Blind ";
                }
                else
                {
                    call += raise * 5;
                    buttonD.Text = " Ante Up ";
                }
                dBank -= call;
                pot += call;
                textBoxPot.Text = $"{pot}";
                labelDb.Text = $"{dBank}";
                //System.Threading.Thread.Sleep(500);
                //buttonA.Text = null;
                //buttonB.Text = null;
                //buttonD.Text = null;
                //if (pPlaying == true)
                //{
                //    buttonP.Text = null;
                //}
                DealHands();
            }
            else
            {
                if (dPlaying == true)
                {
                    if (action < 3)
                    {
                        buttonD.Text = " Call ";
                    }
                    else
                    {
                        call += raise * 10;
                        buttonD.Text = " Raise ";
                    }
                    dBank -= call;
                    pot += call;
                    textBoxPot.Text = $"{pot}";
                    labelDb.Text = $"{dBank}";
                    textBoxCall.Text = $"{call}";
                    if (communityCards.Count() == 5)
                    {
                        EndRound();
                    }
                    else
                    {
                        //System.Threading.Thread.Sleep(500);
                        //buttonA.Text = null;
                        //buttonB.Text = null;
                        //buttonD.Text = null;
                        //if (pPlaying == true)
                        //{
                        //    buttonP.Text = null;
                        //}
                        Action();
                    }
                }
            }
        }
        private void DealHands()
        {
            prebet = false;
            call = MINBET;
            for (int i = 0; i < HOLECARDS; i++)
            {
                cardValue = rand.Next(0, cards.Count()-1);
                pH.Add(cards[cardValue]);
                cards.RemoveAt(cardValue);
                cardValue = rand.Next(0, cards.Count() - 1);
                aH.Add(cards[cardValue]);
                cards.RemoveAt(cardValue);
                cardValue = rand.Next(0, cards.Count() - 1);
                bH.Add(cards[cardValue]);
                cards.RemoveAt(cardValue);
                cardValue = rand.Next(0, cards.Count() - 1);
                dH.Add(cards[cardValue]);
                cards.RemoveAt(cardValue);
            }
            pictureBoxP1.Image = imageListCards.Images[pH[0]];
            pictureBoxP2.Image = imageListCards.Images[pH[1]];
            for (int j = 0; j < (HOLECARDS + 1); j++)
            {
                    cardValue = rand.Next(0, cards.Count() - 1);
                    communityCards.Add(cards[cardValue]);
                    cards.RemoveAt(cardValue);
            }
            pictureBoxC1.Image = imageListCards.Images[communityCards[0]];
            pictureBoxC2.Image = imageListCards.Images[communityCards[1]];
            pictureBoxC3.Image = imageListCards.Images[communityCards[2]];
            prebet = false;
            pPlaying = true;
            aPlaying = true;
            bPlaying = true;
            dPlaying = true;
            //System.Threading.Thread.Sleep(500);
            aBet();
        }
        private void Action()
        {
            if (pPlaying == true || aPlaying == true || bPlaying == true || dPlaying == true)
            {
                //System.Threading.Thread.Sleep(1000);
                if (communityCards.Count() != 5)
                {
                    if (skip == true)
                    {
                        cardValue = rand.Next(0, cards.Count() - 1);
                        communityCards.Add(cards[cardValue]);
                        cards.RemoveAt(cardValue);
                        if (communityCards.Count() == 4)
                        {
                            pictureBoxC4.Image = imageListCards.Images[communityCards[3]];
                        }
                        else
                        {
                            pictureBoxC5.Image = imageListCards.Images[communityCards[4]];
                        }
                    }
                    else
                    {
                        cardValue = rand.Next(0, cards.Count() - 1);
                        communityCards.Add(cards[cardValue]);
                        cards.RemoveAt(cardValue);
                        if (communityCards.Count() == 4)
                        {
                            pictureBoxC4.Image = imageListCards.Images[communityCards[3]];
                        }
                        else
                        {
                            pictureBoxC5.Image = imageListCards.Images[communityCards[4]];
                        }
                    }
                    aBet();
                }
                else
                {
                    aBet();
                }
            }
        }
        private int Showdown(List<int> hand)
        {
            //Declare lists
            List<int> values = new List<int>();
            List<int> distinctCards = new List<int>();
            List<int> diffCards = new List<int>();
            List<int> consecutives = new List<int>();
            List<int> straight = new List<int>();
            List<int> suitC = new List<int>();
            List<int> suitH = new List<int>();
            //Declare variables
            int pMax = 0;
            int aMax = 0;
            int cMax = 0;
            int theMax = 0;
            int ranking = 0;
            int kindp = 0;
            int kindx = 0;
            int kindy = 0;
            int consecutive = 0;
            int straightFlush = 0;
            int royalFlush = 0;
            int diamond = 0;
            int heart = 0;
            int club = 0;
            int spade = 0;
            int sim = 1;

            consecutives.Clear();
            distinctCards.Clear();
            values.Clear();

            pMax = pH.Max() % 13;
            if (pMax == 0)
            {
                pMax = 13;
            }
            aMax = aH.Max() % 13;
            if (aMax == 0)
            {
                aMax = 13;
            }
            foreach (int i in hand)
            {
                if (i % 13 == 0)
                {
                    values.Add(13);
                }
                else
                {
                    values.Add(i % 13);
                }
                if (i > 0 && i < 13)
                {
                    suitH.Add(1);
                }
                if (i > 12 && i < 26)
                {
                    suitH.Add(2);
                }
                if (i > 25 && i < 39)
                {
                    suitH.Add(3);
                }
                if (i > 38 && i < 52)
                {
                    suitH.Add(4);
                }
            }
            for (int i = 0; i < communityCards.Count(); i++)
            {
                if (communityCards[i] % 13 == 0)
                {
                    distinctCards.Add(13);
                    diffCards.Add(distinctCards[i]);
                    if (distinctCards[i] == values[0] || distinctCards[i] == values[1])
                    {
                        diffCards[i] = 130 + (sim * 13);
                        sim++;
                    }
                }
                else
                {
                    distinctCards.Add(communityCards[i] % 13);
                    diffCards.Add(distinctCards[i]);
                    if (distinctCards[i] == values[0] || distinctCards[i] == values[1])
                    {
                        diffCards[i] = 130 + (sim * 13);
                        sim++;
                    }
                }
            }
            cLikes = diffCards.Count() - diffCards.Distinct().Count();
            if (cLikes != 0)
            {
                foreach (int i in diffCards)
                {
                    if (!distinct.Add(i)) duplicate.Add(i);
                }
            }
            cMax = distinctCards.Max();
            if (pMax > aMax && pMax > cMax)
            {
                theMax = pMax;
            }
            else if (aMax > pMax && aMax > cMax)
            {
                theMax = aMax;
            }
            else
            {
                theMax = cMax;
            }
            if (pPlaying == true || aPlaying == true)
            {
                //Checking for suits
                foreach (int i in communityCards)
                {
                    if (i > 0 && i < 13)
                    {
                        diamond++;
                    }
                    if (i > 12 && i < 26)
                    {
                        heart++;
                    }
                    if (i > 25 && i < 39)
                    {
                        club++;
                    }
                    if (i > 38 && i < 52)
                    {
                        spade++;
                    }
                }
                if (hand[0] > 0 && hand[0] < 13 && hand[1] > 0 && hand[1] < 13)
                {
                    diamond += 2;
                }
                else if (hand[0] > 0 && hand[0] < 13 || hand[1] > 0 && hand[1] < 13)
                {
                    diamond++;
                }
                if (hand[0] > 12 && hand[0] < 26 && hand[1] > 12 && hand[1] < 26)
                {
                    heart += 2;
                }
                else if (hand[0] > 12 && hand[0] < 26 || hand[1] > 12 && hand[1] < 26)
                {
                    heart++;
                }
                if (hand[0] > 25 && hand[0] < 39 && hand[1] > 25 && hand[1] < 39)
                {
                    club += 2;
                }
                else if (hand[0] > 25 && hand[0] < 39 || hand[1] > 25 && hand[1] < 39)
                {
                    club++;
                }
                if (hand[0] > 38 && hand[0] < 52 && hand[1] > 38 && hand[1] < 52)
                {
                    spade += 2;
                }
                else if (hand[0] > 38 && hand[0] < 52 || hand[1] > 38 && hand[1] < 52)
                {
                    spade++;
                }
                //Starting hand are a pair
                if (hand[0] % 13 == hand[1] % 13)
                {
                    kindp += 2;
                    foreach (int i in communityCards)
                    {
                        //Checking for like Cards
                        if (i % 13 == hand[0] % 13)
                        {
                            kindp += 1;
                        }
                    }
                }
                //If the starting hand are not a pair
                else
                {
                    foreach (int i in communityCards)
                    {
                        //Checking for like Cards
                        if ((i % 13) == (hand[0] % 13))
                        {
                            kindx += 2;
                        }
                        if ((i % 13) == (hand[1] % 13))
                        {
                            kindy += 2;
                        }
                    }
                }

                for (int j = 0; j < values.Count(); j++)
                {
                    if (hand[j] % 13 == 0)
                    {
                        consecutives.Add(13);
                    }
                    else
                    {
                        consecutives.Add(hand[j] % 13);
                    }
                    straight.Add(values[j]);
                    int f = 1 - j;
                    for (int a = 0; a < communityCards.Count(); a++)
                    {
                        for (int i = 0; i < diffCards.Count(); i++)
                        {
                            if (communityCards[i] > 0 && communityCards[i] < 13)
                            {
                                suitC.Add(1);
                            }
                            if (communityCards[i] > 12 && communityCards[i] < 26)
                            {
                                suitC.Add(2);
                            }
                            if (communityCards[i] > 25 && communityCards[i] < 39)
                            {
                                suitC.Add(3);
                            }
                            if (communityCards[i] > 38 && communityCards[i] < 52)
                            {
                                suitC.Add(4);
                            }
                        }
                        if (diffCards[a] != values[j] && diffCards[a] != values[f])
                        {
                            straight.Add(diffCards[a]);
                            consecutives.Add(diffCards[a]);
                        }
                        for (int b = 0; b < diffCards.Count(); b++)
                        {
                            if (diffCards[b] != values[j] && diffCards[b] != values[f])
                            {
                                straight.Add(diffCards[b]);
                                consecutives.Add(diffCards[b]);
                            }
                            for (int c = 0; c < diffCards.Count(); c++)
                            {
                                if (diffCards[c] != values[j] && diffCards[c] != values[f])
                                {
                                    straight.Add(diffCards[c]);
                                    consecutives.Add(diffCards[c]);
                                }
                                if (straight.Distinct().Count() == 5)
                                {
                                    if (straight.Max() - straight.Min() == 4)
                                    {
                                        if (straight.Sum() % 5 == 0)
                                        {
                                            consecutive += 1;
                                            if (suitH[j] == suitC[a] && suitH[j] == suitC[b] && suitH[j] == suitC[c])
                                            {
                                                straightFlush += 1;
                                            }
                                        }
                                    }
                                    if (straight.Max() - straight.Min() == 12)
                                    {
                                        if (straight.Sum() % 13 == 8)
                                        {
                                            if (suitH[j] == suitH[f] && suitH[j] == suitC[a] && suitH[j] == suitC[b] && suitH[j] == suitC[c])
                                            {
                                                royalFlush += 1;
                                            }
                                        }
                                    }
                                }
                                for (int d = 0; d < diffCards.Count(); d++)
                                {
                                    if (diffCards[d] != values[j] && diffCards[d] != values[f])
                                    {
                                        consecutives.Add(diffCards[d]);
                                    }
                                    if (consecutives.Distinct().Count() == 5)
                                    {
                                        if (consecutives.Max() - consecutives.Min() == 4)
                                        {
                                            if (consecutives.Sum() % 5 == 0)
                                            {
                                                consecutive += 1;
                                                if (suitH[j] == suitC[a] && suitH[j] == suitC[b] && suitH[j] == suitC[c] && suitH[j] == suitC[d])
                                                {
                                                    straightFlush += 1;
                                                }
                                            }
                                        }
                                        if (consecutives.Sum() == 47)
                                        {
                                            if (consecutives.Max() - consecutives.Min() == 12)
                                            {
                                                if (suitH[j] == suitH[f] && suitH[j] == suitC[a] && suitH[j] == suitC[b] && suitH[j] == suitC[c] && suitH[j] == suitC[d])
                                                {
                                                    royalFlush += 1;
                                                }
                                            }
                                        }
                                    }
                                    straight.Remove(diffCards[d]);
                                    consecutives.Remove(diffCards[d]);
                                }
                                straight.Remove(diffCards[c]);
                                consecutives.Remove(diffCards[c]);
                            }
                            straight.Remove(diffCards[b]);
                            consecutives.Remove(diffCards[b]);
                        }
                        straight.Remove(diffCards[a]);
                        consecutives.Remove(diffCards[a]);
                        suitC.Clear();
                    }
                    consecutives.Clear();
                }
                if (royalFlush != 0)
                {
                    ranking = 11;
                }
                else if (straightFlush != 0)
                {
                    ranking = 10;
                }
                else if (kindp == 4 || kindx == 6 || kindy == 6 || cLikes == 3)
                {
                    ranking = 9;
                }
                else if ((kindx == 4 && kindy == 2) || (kindx == 2 && kindy == 4))
                {
                    ranking = 8;
                }
                else if ((kindx + cLikes == 4) || (kindy + cLikes == 4) || (kindx + cLikes == 5) || (kindy + cLikes == 5) || (kindp + cLikes == 4))
                {
                    if (duplicate.Distinct().Count() == 1)
                    {
                        foreach (int i in duplicate)
                        {
                            if (i != values[0] && i != values[1])
                            {
                                ranking = 8;
                            }
                        }
                    }
                }
                else if (cLikes == 3)
                {
                    if (duplicate.Distinct().Count() == 2)
                    {
                        ranking = 8;
                    }
                }
                else if (diamond >= 5 || heart >= 5 || club >= 5 || spade >= 5)
                {
                    ranking = 7;
                }
                else if (consecutive != 0)
                {
                    ranking = 6;
                }
                else if (kindp == 3 || kindx == 4 || kindy == 4)
                {
                    ranking = 5;
                }
                else if (cLikes == 2)
                {
                    if (duplicate.Distinct().Count() == 1)
                    {
                        ranking = 5;
                    }
                }
                else if (kindx + kindy == 4 || kindx + cLikes == 3 || kindy + cLikes == 3 || kindp + cLikes == 3)
                {
                    ranking = 4;
                }
                else if (kindp == 2 || kindx == 2 || kindy == 2 || cLikes == 1)
                {
                    ranking = 3;
                }
                else if (values.Max() > aMax && pMax > cMax || values.Max() > pMax && aMax > cMax)
                {
                    ranking = 2;
                }
                else if (theMax == cMax)
                {
                    ranking = 1;
                }
            }
            return ranking;
        }
        private string FiveCardHand(int hand)
        {
            string ranking = "";
            if (hand == 11)
            {
                ranking = "Royal Flush";
            }
            else if (hand == 10)
            {
                ranking = "Straight Flush";
            }
            else if (hand == 9)
            {
                ranking = "Four of a Kind";
            }
            else if (hand == 8)
            {
                ranking = "Full House";
            }
            else if (hand == 7)
            {
                ranking = "Flush";
            }
            else if (hand == 6)
            {
                ranking = "Straight";
            }
            else if (hand == 5)
            {
                ranking = "Three of a Kind";
            }
            else if (hand == 4)
            {
                ranking = "Two Pair";
            }
            else if (hand == 3)
            {
                ranking = "Pair";
            }
            else if (hand == 2)
            {
                ranking = "High Card";
            }
            else if (hand == 1)
            {
                ranking = "High Card";
            }
            return ranking;
        }
        private void EndRound()
        {
            //Declare lists
            List<int> players = new List<int>();
            List<int> playerTie = new List<int>();
            List<int> tied = new List<int>();
            List<string> hand = new List<string>();
            //Declare Variables
            //int aRank = 0;
            //int bRank = 0;
            //int dRank = 0;
            //int pRank = 0;
            //string aHand;
            //string bHand;
            //string dHand;
            //string pHand;
            int tie = 0;
            if (communityCards.Count() == 5)
            {
                buttonCall.Enabled = false;
                buttonRaise.Enabled = false;
                buttonFold.Enabled = false;
                buttonAllIn.Enabled = false;
                pictureBoxA1.Image = imageListCards.Images[aH[0]];
                pictureBoxA2.Image = imageListCards.Images[aH[1]];
                pictureBoxB1.Image = imageListCards.Images[bH[0]];
                pictureBoxB2.Image = imageListCards.Images[bH[1]];
                pictureBoxD1.Image = imageListCards.Images[dH[0]];
                pictureBoxD2.Image = imageListCards.Images[dH[1]];
                if (pPlaying == true)
                {
                    players.Add(Showdown(aH));
                    players.Add(Showdown(bH));
                    players.Add(Showdown(dH));
                    players.Add(Showdown(pH));
                    foreach (int i in players)
                    {
                        hand.Add(FiveCardHand(i));
                    }
                    buttonA.Text = hand[0];
                    buttonB.Text = hand[1];
                    buttonD.Text = hand[2];
                    buttonP.Text = hand[3];
                    for (int t = 0; t < players.Count(); t++)
                    {
                        if (players[t] == players.Max())
                        {
                            tie += 1;
                            tied.Add(t);
                        }
                    }
                    foreach (int i in tied)
                    {
                        if (i == 0)
                        {
                            aBank += pot / tie;
                        }
                        if (i == 1)
                        {
                            bBank += pot / tie;
                        }
                        if (i == 2)
                        {
                            dBank += pot / tie;
                        }
                        if (i == 3)
                        {
                            pBank += pot / tie;
                        }
                    }
                    if (tied.Last() != 3)
                    {
                        MessageBox.Show($"You Lost to a " + hand[tied.First()] + '.');
                    }
                    else
                    {
                        if (tied.Count() == 1)
                        {
                            MessageBox.Show($"You win with a " + hand[3] + '.');
                        }
                        else
                        {
                            MessageBox.Show($"You drew with a " + hand[3] + '.');
                        }
                    }
                    GameStart();
                }
                else
                {
                    //aRank = Showdown(aH);
                    //bRank = Showdown(bH);
                    //dRank = Showdown(dH);
                    //aHand = FiveCardHand(aRank);
                    //bHand = FiveCardHand(bRank);
                    //dHand = FiveCardHand(dRank);
                    //buttonA.Text = $"{aHand}";
                    //buttonB.Text = $"{bHand}";
                    //buttonD.Text = $"{dHand}";
                    buttonP.Text = $"Fold";
                    MessageBox.Show("You have discarded your hand.\n" + "The opponent has a " /*+ aHand*/);
                    GameStart();
                }
            }
        }
    }
}
