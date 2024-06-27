using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //Declare Varaibles
        bool aPlaying = false;
        bool pPlaying = false;
        string line;
        string[] data;
        int cardValue;
        int pBank = MONEY;
        int aBank = MONEY;
        int pot;
        int call = MINBET / 2;
        bool prebet = false;
        int play;
        bool skip = false;

        List<Card> card = new List<Card>();
        List<string> imageLocation = new List<string>();
        Card SelectedCard;
        int cardNumber = -1;
        int indexValue;
        int xPos = 1185;
        int back = 52;
        bool clicked = false;
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
            prebet = true;
            buttonBlind.Show();
            buttonAnteUp.Show();
            buttonCall.Enabled = false;
            buttonRaise.Enabled = false;
            buttonFold.Enabled = false;
            buttonAllIn.Enabled = false;
            if(aBank < pBank)
            {
                aBank = pBank /95 * 100;
            }
            pH.Clear();
            aH.Clear();
            bH.Clear();
            dH.Clear();
            cards.Clear();
            communityCards.Clear();
            textBoxCall.Clear();
            textBoxBet.Clear();
            textBoxPot.Clear();
            call = MINBET / 2;
            pot = 0;
            pictureBoxP1.Image = imageListCards.Images[52];
            pictureBoxP2.Image = imageListCards.Images[52];
            pictureBoxC1.Image = imageListCards.Images[52];
            pictureBoxC2.Image = imageListCards.Images[52];
            pictureBoxC3.Image = imageListCards.Images[52];
            pictureBoxC4.Image = imageListCards.Images[52];
            pictureBoxC5.Image = imageListCards.Images[52];
            pictureBoxA1.Image = imageListCards.Images[52];
            pictureBoxA2.Image = imageListCards.Images[52];
            labelP.Text = $"{pBank}";
        }
        private void SetupApp()
        {
            imageLocation = Directory.GetFiles("Sprites", "*png").ToList();
            for (int i = 0; i < 53; i++)
            {
                MakeCards();
            }
            textBoxBet.Text = $"{call}";
        }
        private void MakeCards()
        {
            cardNumber++;
            Card newCard = new Card(imageLocation[cardNumber]);
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
            if (call == MINBET / 2)
            {
                call = MINBET / 2;
                pBank -= call;
                pot += call;
                textBoxPot.Text = $"{pot}";
                buttonBlind.Hide();
                buttonAnteUp.Hide();
                //buttonP.Show();
                //buttonP.Text = " Blind ";
                labelP.Text = $"{pBank}";
                textBoxCall.Text = $"{call}";
                BotBets();
            }
            else
            {
                pBank -= call;
                pot += call;
                textBoxPot.Text = $"{pot}";
                buttonBlind.Hide();
                buttonAnteUp.Hide();
                //buttonP.Show();
                //buttonP.Text = " Blind ";
                labelP.Text = $"{pBank}";
                textBoxCall.Text = $"{call}";
                BotBets();
            }
        }
        private void buttonAnteUp_Click(object sender, EventArgs e)
        {
            textBoxBet.Show();
            buttonBet.Show();
        }
        private void buttonBet_Click(object sender, EventArgs e)
        {
            int bet;
            if (int.TryParse(textBoxBet.Text, out bet) == true)
            {
                if (prebet == true)
                {
                    if (bet <= call)
                    {
                        MessageBox.Show($"Please make a bet which is greater than {call}");
                    }
                    else
                    {
                        call = bet;
                        pBank -= bet;
                        pot += call;
                        buttonBlind.Hide();
                        buttonAnteUp.Hide();
                        buttonP.Text = "Ante Up";
                        labelP.Text = $"{pBank}";
                        textBoxCall.Text = $"{call}";
                        BotBets();
                    }
                }
                else
                {
                    if (bet <= call)
                    {
                        MessageBox.Show($"Please make a bet which is greater than {call}");
                    }
                    else
                    {
                        call = bet;
                        pBank -= bet;
                        pot += call;
                        buttonBlind.Hide();
                        buttonAnteUp.Hide();
                        buttonP.Text = "Ante Up";
                        labelP.Text = $"{pBank}";
                        textBoxCall.Text = $"{call}";
                        BotBets();
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
            pBank -= call;
            pot += call;
            textBoxCall.Text = $"{call}";
            BotBets();
        }
        private void buttonRaise_Click(object sender, EventArgs e)
        {
            textBoxBet.Show();
            buttonBet.Show();
        }
        private void buttonFold_Click(object sender, EventArgs e)
        {
            pPlaying = false;
            skip = true;
            BotBets();
        }
        private void buttonAllIn_Click(object sender, EventArgs e)
        {
            call = pBank;
            pBank = 0;
            pot += call;
            skip = true;
            labelP.Text = $"{pBank}";
            textBoxCall.Text = $"{call}";
            BotBets();
        }
        private void BotBets()
        {
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
                    aBank -= call;
                    pot += call;
                    textBoxPot.Text = $"{pot}";
                    prebet = false;
                    labelAb.Text = $"{aBank}";
                    buttonA.Text = " Blind ";
                    textBoxCall.Text = $"{call}";
                    DealHands();
                }
                else
                {
                    call += raise * 5;
                    aBank -= call;
                    pot += call;
                    textBoxPot.Text = $"{pot}";
                    prebet = false;
                    labelAb.Text = $"{aBank}";
                    buttonA.Text = " Ante Up ";
                    textBoxCall.Text = $"{call}";
                    DealHands();
                }
            }
            else
            {
                if (aPlaying == true)
                {
                    if (skip == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            action = rand.Next(0, 4);
                            raise = rand.Next(0, 11);
                            if (action < 3)
                            {
                                aBank -= call;
                                pot += call;
                                textBoxPot.Text = $"{pot}";
                                labelAb.Text = $"{aBank}";
                                buttonA.Text = " Call ";
                                textBoxCall.Text = $"{call}";
                            }
                            else
                            {
                                call += raise * 10;
                                aBank -= call;
                                pot += call;
                                textBoxPot.Text = $"{pot}";
                                labelAb.Text = $"{aBank}";
                                buttonA.Text = " Raise ";
                                textBoxCall.Text = $"{call}";
                            }

                        }
                    }
                    else
                    {
                        if (action < 3)
                        {
                            aBank -= call;
                            pot += call;
                            textBoxPot.Text = $"{pot}";
                            labelAb.Text = $"{aBank}";
                            buttonA.Text = " Call ";
                            textBoxCall.Text = $"{call}";
                        }
                        else
                        {
                            call += raise * 10;
                            aBank -= call;
                            pot += call;
                            textBoxPot.Text = $"{pot}";
                            labelAb.Text = $"{aBank}";
                            buttonA.Text = " Raise ";
                            textBoxCall.Text = $"{call}";
                        }
                    }
                    Action();
                }
                else if (aPlaying == false)
                {
                    Action();
                }
            }
        }
        private void DealHands()
        {
            buttonCall.Enabled = true;
            buttonRaise.Enabled = true;
            buttonFold.Enabled = true;
            buttonAllIn.Enabled = true;
            prebet = false;
            if (call < MINBET)
            {
                call = MINBET;
            }
            using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split(',');
                    cards.Add(Convert.ToInt32(data[0]));
                }
            }
            for (int i = 0; i < HOLECARDS; i++)
            {
                cardValue = rand.Next(0, (cards.Count()));
                pH.Add(cards[cardValue]);
                cards.RemoveAt(cardValue);
                cardValue = rand.Next(0, (cards.Count()));
                aH.Add(cards[cardValue]);
                cards.RemoveAt(cardValue);
            }
            pictureBoxP1.Image = imageListCards.Images[pH[0]];
            pictureBoxP2.Image = imageListCards.Images[pH[1]];
            for (int j = 0; j < (HOLECARDS + 1); j++)
            {
                    cardValue = rand.Next(0, (cards.Count()));
                    communityCards.Add(cards[cardValue]);
                    cards.RemoveAt(cardValue);
            }
            pictureBoxC1.Image = imageListCards.Images[communityCards[0]];
            pictureBoxC2.Image = imageListCards.Images[communityCards[1]];
            pictureBoxC3.Image = imageListCards.Images[communityCards[2]];
            textBoxBet.Text = $"{call}";
            prebet = false;
            pPlaying = true;
            aPlaying = true;
        }
        private void Action()
        {
            if (communityCards.Count() != 5)
            {
                if (skip == true)
                {
                    for (int i = 3; i < 5; i++)
                    {
                        buttonCall.Enabled = false;
                        buttonRaise.Enabled = false;
                        buttonFold.Enabled = false;
                        buttonAllIn.Enabled = false;
                        cardValue = rand.Next(0, (cards.Count()));
                        communityCards.Add(cards[cardValue]);
                        cards.RemoveAt(cardValue);
                    }
                    BotBets();
                }
                else
                {
                    cardValue = rand.Next(0, (cards.Count()));
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
                    textBoxBet.Text = $"{call}";
                }
            }
            EndRound();
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
            int oMax = 0;
            int ranking = 1;
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

            consecutives.Clear();
            distinctCards.Clear();
            values.Clear();

            pMax = pH.Max() % 13;
            if (pH.Max() == 0)
            {
                pMax = 13;
            }
            oMax = aH.Max() % 13;
            if (aH.Max() == 0)
            {
                oMax = 13;
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
                if (i > 0 && i < 14)
                {
                    suitH.Add(1);
                }
                if (i > 13 && i < 27)
                {
                    suitH.Add(2);
                }
                if (i > 26 && i < 40)
                {
                    suitH.Add(3);
                }
                if (i > 39 && i < 53)
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
                        diffCards[i] = 100;
                    }
                }
                else
                {
                    distinctCards.Add(communityCards[i] % 13);
                    diffCards.Add(distinctCards[i]);
                    if (distinctCards[i] == values[0] || distinctCards[i] == values[1])
                    {
                        diffCards[i] = 100;
                    }
                }
            }
            if (pPlaying == true || aPlaying == true)
            {
                //Checking for suits
                foreach (int i in communityCards)
                {
                    if (i > 0 && i < 14)
                    {
                        diamond++;
                    }
                    if (i > 13 && i < 27)
                    {
                        heart++;
                    }
                    if (i > 26 && i < 40)
                    {
                        club++;
                    }
                    if (i > 39 && i < 53)
                    {
                        spade++;
                    }
                }
                if (hand[0] > 0 && hand[0] < 14 && hand[1] > 0 && hand[1] < 14)
                {
                    diamond += 2;
                }
                else if (hand[0] > 0 && hand[0] < 14 || hand[1] > 0 && hand[1] < 14)
                {
                    diamond++;
                }
                if (hand[0] > 13 && hand[0] < 27 && hand[1] > 13 && hand[1] < 27)
                {
                    heart += 2;
                }
                else if (hand[0] > 13 && hand[0] < 27 || hand[1] > 13 && hand[1] < 27)
                {
                    heart++;
                }
                if (hand[0] > 26 && hand[0] < 40 && hand[1] > 26 && hand[1] < 40)
                {
                    club += 2;
                }
                else if (hand[0] > 26 && hand[0] < 40 || hand[1] > 26 && hand[1] < 40)
                {
                    club++;
                }
                if (hand[0] > 39 && hand[0] < 53 && hand[1] > 39 && hand[1] < 53)
                {
                    spade += 2;
                }
                else if (hand[0] > 39 && hand[0] < 53 || hand[1] > 39 && hand[1] < 53)
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
                            if (communityCards[i] > 0 && communityCards[i] < 14)
                            {
                                suitC.Add(1);
                            }
                            if (communityCards[i] > 13 && communityCards[i] < 27)
                            {
                                suitC.Add(2);
                            }
                            if (communityCards[i] > 26 && communityCards[i] < 40)
                            {
                                suitC.Add(3);
                            }
                            if (communityCards[i] > 39 && communityCards[i] < 53)
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
                    ranking = 10;
                }
                else if (straightFlush != 0)
                {
                    ranking = 9;
                }
                else if (kindp == 4 || kindx == 6 || kindy == 6)
                {
                    ranking = 8;
                }
                else if ((kindx == 4 && kindy == 2) || (kindx == 2 && kindy == 4))
                {
                    ranking = 7;
                }
                else if (diamond >= 5 || heart >= 5 || club >= 5 || spade >= 5)
                {
                    ranking = 6;
                }
                else if (consecutive != 0)
                {
                    ranking = 5;
                }
                else if (kindp == 3 || kindx == 4 || kindy == 4)
                {
                    ranking = 4;
                }
                else if (kindx + kindy == 4)
                {
                    ranking = 3;
                }
                else if (kindp == 2 || kindx == 2 || kindy == 2)
                {
                    ranking = 2;
                }
                else if ((values.Max() == pMax && values.Max() > oMax) || (values.Max() > pMax && values.Max() == oMax))
                {
                    ranking = 1;
                }
                if (aPlaying == false)
                {
                    ranking = 0;
                }
            }
            return ranking;
        }
        private string FiveCardHand(int hand)
        {
            string ranking = "";
            if (hand == 10)
            {
                ranking = "Royal Flush";
            }
            else if (hand == 9)
            {
                ranking = "Straight Flush";
            }
            else if (hand == 8)
            {
                ranking = "Four of a Kind";
            }
            else if (hand == 7)
            {
                ranking = "Full House";
            }
            else if (hand == 6)
            {
                ranking = "Flush";
            }
            else if (hand == 5)
            {
                ranking = "Straight";
            }
            else if (hand == 4)
            {
                ranking = "Three of a Kind";
            }
            else if (hand == 3)
            {
                ranking = "Two Pair";
            }
            else if (hand == 2)
            {
                ranking = "Pair";
            }
            else if (hand == 1)
            {
                ranking = "High Card";
            }
            return ranking;
        }
        private void EndRound()
        {
            //Declare Variables
            int aRank = 0;
            //int bRank = 0;
            //int dRank = 0;
            int pRank = 0;
            string hand;
            if (communityCards.Count() == 5)
            {
                buttonCall.Enabled = false;
                buttonRaise.Enabled = false;
                buttonFold.Enabled = false;
                buttonAllIn.Enabled = false;
                if (pPlaying == true)
                {
                    pRank = Showdown(pH);
                    aRank = Showdown(aH);
                    pictureBoxA1.Image = imageListCards.Images[aH[0]];
                    pictureBoxA2.Image = imageListCards.Images[aH[1]];
                    if (pRank > aRank)
                    {
                        hand = FiveCardHand(pRank);
                        MessageBox.Show($"You win with a " + hand + '.');
                        pBank += pot;
                    }
                    else if (pRank == aRank)
                    {
                        hand = FiveCardHand(pRank);
                        MessageBox.Show($"It's a draw, " + hand + ".");
                        pBank += pot / 2;
                        aBank += pot / 2;
                    }
                    else
                    {
                        hand = FiveCardHand(aRank);
                        MessageBox.Show($"You Lost to a " + hand + '.');
                        aBank += pot;
                    }
                }
                else
                {
                    aRank = Showdown(aH);
                    hand = FiveCardHand(aRank);
                    MessageBox.Show("You have discarded your hand.\n" + "The opponent has a " + hand);
                    //textBoxBank.Text = $"{pBank}";
                }
                GameStart();
            }
        }
    }
}
