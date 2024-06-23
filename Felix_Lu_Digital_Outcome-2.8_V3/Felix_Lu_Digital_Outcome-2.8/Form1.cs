using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Felix_Lu_Digital_Outcome_2._8
{
    public partial class Form1 : Form
    {
        //Declare Constants
        const int HOLECARDS = 2;
        const int MONEY = 2000;
        const int MINBET = 100;
        //Declare RNG
        Random rand = new Random();
        //Declare Lists
        List<int> cards = new List<int>();
        List<int> playerHand = new List<int>();
        List<int> communityCards = new List<int>();
        List<int> opponentHand = new List<int>();

        List<string> imageLocation = new List<string>();
        List<Card> card = new List<Card>();
        //Declare Varaibles
        bool oPlaying = false;
        bool pPlaying = false;
        string line;
        string[] data;
        int cardValue;
        int playerBank = MONEY;
        int opBank = MONEY;
        int pot;
        int call = MINBET / 2;
        bool prebet = false;
        int play;
        bool skip = false;
        int xPos = 5;


        public Form1()
        {
            InitializeComponent();
            SetupApp();
            buttonPlay.Enabled = true;
            buttonCall.Enabled = false;
            buttonRaise.Enabled = false;
            buttonFold.Enabled = false;
            buttonAllIn.Enabled = false;

        }
        private void SetupApp()
        {
            imageLocation = Directory.GetFiles("Sprites", "*png").ToList();
        }
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            prebet = true;
            call = MINBET / 2;
            pot = 0;
            skip = false;
            textBoxBank.Text = $"{playerBank}";
            textBoxBet.Text = $"{call}";
            //Clear listboxes and lists of data.
            pPlaying = false;
            playerHand.Clear();
            communityCards.Clear();
            opponentHand.Clear();
            cards.Clear();
            listBoxPlayer.Items.Clear();
            listBoxCommunityCards.Items.Clear();
            listBoxOpponent.Items.Clear();
            listBoxTesting.Items.Clear();
            //Enabling/Disabling buttons
            buttonPlay.Enabled = false;
            buttonCall.Enabled = true;
            buttonRaise.Enabled = true;
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            //play = 1;
            if (prebet == true)
            {
                if (call == MINBET / 2)
                {
                    call = MINBET / 2;
                    playerBank -= call;
                    pot += call;
                    textBoxBank.Text = $"{playerBank}";
                    textBoxPot.Text = $"{pot}";
                    OpponentBet();
                }
                else
                {
                    playerBank -= call;
                    pot += call;
                    textBoxBank.Text = $"{playerBank}";
                    textBoxPot.Text = $"{pot}";
                    OpponentBet();
                }
            }
            else
            {
                playerBank -= call;
                pot += call;
                textBoxBank.Text = $"{playerBank}";
                textBoxPot.Text = $"{pot}";
                OpponentBet();
            }
        }
        private void buttonRaise_Click(object sender, EventArgs e)
        {
            int bet;
            play = 1;
            if (prebet == true)
            {
                if (int.TryParse(textBoxBet.Text, out bet) == true)
                {
                    if (bet <= call)
                    {
                        MessageBox.Show($"Please place a bet which is greater than {call}.");
                    }
                    else
                    {
                        call = bet;
                        playerBank -= bet;
                        pot += call;
                        textBoxBank.Text = $"{playerBank}";
                        textBoxPot.Text = $"{pot}";
                        OpponentBet();
                    }
                }
                else
                {
                    MessageBox.Show($"Please place a bet which is an int. E.g {call}.");
                }
            }
            else
            {
                if (int.TryParse(textBoxBet.Text, out bet) == true)
                {
                    if (bet <= call)
                    {
                        MessageBox.Show($"Please place a bet which is greater than {call}.");
                    }
                    else
                    {
                        call = bet;
                        playerBank -= bet;
                        pot += call;
                        textBoxBank.Text = $"{playerBank}";
                        textBoxPot.Text = $"{pot}";
                        OpponentBet();
                    }
                }
                else
                {
                    MessageBox.Show($"Please place a bet which is an int. E.g {call}.");
                }
            }
        }
        private void OpponentBet()
        {
            int action;
            int raise;
            action = rand.Next(0, 4);
            raise = rand.Next(0, 11);
            if (prebet == true)
            {
                if (action < 3)
                {
                    opBank -= call;
                    pot += call;
                    textBoxPot.Text = $"{pot}";
                    prebet = false;
                    Cards();
                }
                else
                {
                    call += raise * 5;
                    opBank -= call;
                    pot += call;
                    textBoxPot.Text = $"{pot}";
                    prebet = false;
                    Cards();
                }
            }
            else
            {
                if (oPlaying == true)
                {
                    if (skip == true)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            opBank -= call;
                            pot += call;
                            textBoxPot.Text = $"{pot}";
                        }
                    }
                    else
                    {
                        call += raise * 10;
                        opBank -= call;
                        pot += call;
                        textBoxPot.Text = $"{pot}";
                    }
                    Action();
                }
                else if (oPlaying == false)
                {
                    Action();
                }
            }
        }
        private void buttonFold_Click(object sender, EventArgs e)
        {
            pPlaying = false;
            skip = true;
            OpponentBet();
        }

        private void buttonAllIn_Click(object sender, EventArgs e)
        {
            call = playerBank;
            playerBank = 0;
            pot += call;
            textBoxBank.Text = $"{playerBank}";
            textBoxPot.Text = $"{pot}";
            skip = true;
            OpponentBet();
        }

        private void Cards()
        {
            textBoxBet.Clear();
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
                using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                {
                    cardValue = rand.Next(0, (cards.Count()));
                    playerHand.Add(cards[cardValue]);
                    cards.RemoveAt(cardValue);
                    cardValue = rand.Next(0, (cards.Count()));
                    opponentHand.Add(cards[cardValue]);
                    cards.RemoveAt(cardValue);
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        if (playerHand[i] == Convert.ToInt32(data[0]))
                        {
                            listBoxPlayer.Items.Add(data[1] + " of " + data[2]);
                        }
                        if (opponentHand[i] == Convert.ToInt32(data[0]))
                        {
                            listBoxOpponent.Items.Add(data[1] + " of " + data[2]);
                        }
                    }
                }
            }
            for (int j = 0; j < HOLECARDS + 1; j++)
            {
                using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                {
                    cardValue = rand.Next(0, (cards.Count()));
                    communityCards.Add(cards[cardValue]);
                    cards.RemoveAt(cardValue);
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        if (communityCards[j] == Convert.ToInt32(data[0]))
                        {
                            listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                        }
                    }
                }
            }
            pPlaying = true;
            oPlaying = true;
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
                        using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                        {
                            while ((line = reader.ReadLine()) != null)
                            {
                                data = line.Split(',');
                                if (communityCards[i] == Convert.ToInt32(data[0]))
                                {
                                    listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                                    cards.RemoveAt(cardValue);
                                }
                            }
                        }
                    }
                }
                else
                {
                    cardValue = rand.Next(0, (cards.Count()));
                    communityCards.Add(cards[cardValue]);
                    using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            data = line.Split(',');
                            if (communityCards[communityCards.Count() - 1] == Convert.ToInt32(data[0]))
                            {
                                listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                            }
                        }
                    }
                    cards.RemoveAt(cardValue);
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

            pMax = playerHand.Max() % 13;
            if (playerHand.Max() == 0)
            {
                pMax = 13;
            }
            oMax = opponentHand.Max() % 13;
            if (opponentHand.Max() == 0)
            {
                oMax = 13;
            }
            foreach (int i in hand)
            {
                if(i % 13 == 0)
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
            for(int i = 0; i < communityCards.Count(); i++)
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
            if (pPlaying == true || oPlaying == true)
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
                if (hand[0]%13 == hand[1]%13)
                {
                    kindp += 2;
                    foreach (int i in communityCards)
                    {
                        //Checking for like Cards
                        if (i % 13 == hand[0]%13)
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
                                    if(straight.Max()-straight.Min() == 12)
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
                                            if(consecutives.Max() - consecutives.Min() == 12)
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
                if (oPlaying == false)
                {
                    ranking = 0;
                }
            }
            return ranking;
        }
        private string FiveCardHand(int hand)
        {
            string ranking = "";
            if(hand == 10)
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
            int opponentRank = 0;
            int playerRank = 0;
            string hand;
            if (communityCards.Count() == 5)
            {
                buttonCall.Enabled = false;
                buttonRaise.Enabled = false;
                buttonFold.Enabled = false;
                buttonAllIn.Enabled = false;
                if (pPlaying == true)
                {
                    playerRank = Showdown(playerHand);
                    opponentRank = Showdown(opponentHand);
                    if (playerRank > opponentRank)
                    {
                        hand = FiveCardHand(playerRank);
                        MessageBox.Show($"You win with a " + hand + '.');
                        playerBank += pot;
                    }
                    else if (playerRank == opponentRank)
                    {
                        hand = FiveCardHand(playerRank);
                        MessageBox.Show($"It's a draw, " + hand +".");
                        playerBank += pot/2;
                        opBank += pot / 2;
                    }
                    else
                    {
                        hand = FiveCardHand(opponentRank);
                        MessageBox.Show($"You Lost to a " + hand + '.');
                        opBank += pot;
                    }
                }
                else
                {
                    opponentRank = Showdown(opponentHand);
                    hand = FiveCardHand(opponentRank);
                    MessageBox.Show("You have discarded your hand.\n" + "The opponent has a " + hand);
                    textBoxBank.Text = $"{playerBank}";
                }
                textBoxBank.Text = $"{playerBank}";
                textBoxPot.Clear();
                textBoxBet.Clear();
                buttonPlay.Enabled = true;
            }
        }
    }
}
