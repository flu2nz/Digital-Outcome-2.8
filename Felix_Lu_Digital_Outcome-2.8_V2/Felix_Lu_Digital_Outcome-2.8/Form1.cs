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
        const int MIN = 1;
        const int HOLECARDS = 2;
        //Declare RNG
        Random rand = new Random();
        //Declare Lists
        List<int> cards = new List<int>();
        List<int> playerHand = new List<int>();
        List<int> communityCards = new List<int>();
        List<int> distinctCards = new List<int>();
        List<int> opponentHand = new List<int>();
        //Declare Varaibles
        bool playing = false;
        string line;
        string[] data;

        public Form1()
        {
            InitializeComponent();
            //Enabling/Disabling buttons
            buttonPlay.Enabled = true;
            buttonCall.Enabled = false;
            buttonRaise.Enabled = false;
            buttonFold.Enabled = false;
            buttonAllIn.Enabled = false;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //Declare variables
            int cardValue;
            //Clear listboxes and lists of data.
            playing = false;
            playerHand.Clear();
            communityCards.Clear();
            opponentHand.Clear();
            cards.Clear();
            listBoxPlayer.Items.Clear();
            listBoxCommunityCards.Items.Clear();
            listBoxOpponent.Items.Clear();
            listBoxTesting.Items.Clear();
            using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split(',');
                    cards.Add(Convert.ToInt32(data[0]));
                }
                foreach (int i in cards)
                {
                    listBoxTesting.Items.Add(i);
                }
            }
            for (int i = 0; i < HOLECARDS; i++)
            {
                cardValue = rand.Next(MIN, cards.Count() + 1);
                playerHand.Add(cardValue-1);
                cards.RemoveAt(cardValue-1);
                cardValue = rand.Next(MIN, cards.Count() + 1);
                communityCards.Add(cardValue-1);
                cards.RemoveAt(cardValue-1);
                cardValue = rand.Next(MIN, cards.Count() + 1);
                opponentHand.Add(cardValue-1);
                cards.RemoveAt(cardValue-1);

            }
            using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split(',');
                    if (playerHand[0] == Convert.ToInt32(data[0]))
                    {
                        listBoxPlayer.Items.Add(data[1] + " of " + data[2]);
                    }
                    if (playerHand[1] == Convert.ToInt32(data[0]))
                    {
                        listBoxPlayer.Items.Add(data[1] + " of " + data[2]);
                    }
                    if (opponentHand[0] == Convert.ToInt32(data[0]))
                    {
                        listBoxOpponent.Items.Add(data[1] + " of " + data[2]);
                    }
                    if (opponentHand[1] == Convert.ToInt32(data[0]))
                    {
                        listBoxOpponent.Items.Add(data[1] + " of " + data[2]);
                    }
                    if (communityCards[0] == Convert.ToInt32(data[0]))
                    {
                        listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                    }
                    if (communityCards[1] == Convert.ToInt32(data[0]))
                    {
                        listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                    }
                }
            }
            playing = true;
            //Enabling/Disabling buttons
            buttonPlay.Enabled = false;
            buttonCall.Enabled = true;
            buttonRaise.Enabled = true;
            buttonFold.Enabled = true;
            buttonAllIn.Enabled = true;
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            int cardValue;
            listBoxTesting.Items.Clear();
            if (communityCards.Count() != 5)
            {
                cardValue = rand.Next(MIN, cards.Count() + 1);
                communityCards.Add(cardValue);
                cards.RemoveAt(cardValue);
                using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        for (int i = 2; i < communityCards.Count(); i++)
                        {
                            if (communityCards[i] == Convert.ToInt32(data[0]))
                            {
                                listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                                listBoxTesting.Items.Add(communityCards[i]);
                            }
                        }
                    }
                }
            }
            playing = true;
            EndRound();
        }

        private void buttonRaise_Click(object sender, EventArgs e)
        {
            int cardValue;
            listBoxCommunityCards.Items.Clear();
            if (communityCards.Count() != 5)
            {
                cardValue = rand.Next(MIN, cards.Count() + 1);
                communityCards.Add(cardValue);
                cards.RemoveAt(cardValue);
            }
            using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    data = line.Split(',');
                    for (int i = 0; i < communityCards.Count(); i++)
                    {
                        if (communityCards[i] == Convert.ToInt32(data[0]))
                        {
                            listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                        }
                    }
                }
            }
            playing = true;
            EndRound();
        }

        private void buttonFold_Click(object sender, EventArgs e)
        {
            int cardValue;
            listBoxCommunityCards.Items.Clear();
            while (communityCards.Count() != 5)
            {
                listBoxCommunityCards.Items.Clear();
                if (communityCards.Count() != 5)
                {
                    cardValue = rand.Next(MIN, cards.Count() + 1);
                    communityCards.Add(cardValue);
                    cards.RemoveAt(cardValue);
                }
                using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        for (int i = 0; i < communityCards.Count(); i++)
                        {
                            if (communityCards[i] == Convert.ToInt32(data[0]))
                            {
                                listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                            }
                        }
                    }
                }
            }
            playing = false;
            //Enabling/Disabling buttons
            buttonCall.Enabled = false;
            buttonRaise.Enabled = false;
            buttonFold.Enabled = false;
            buttonAllIn.Enabled = false;
            EndRound();
        }

        private void buttonAllIn_Click(object sender, EventArgs e)
        {
            int cardValue;
            listBoxCommunityCards.Items.Clear();
            while (communityCards.Count() != 5)
            {
                listBoxCommunityCards.Items.Clear();
                if (communityCards.Count() != 5)
                {
                    cardValue = rand.Next(MIN, cards.Count() + 1);
                    communityCards.Add(cardValue);
                    cards.RemoveAt(cardValue);
                }
                using (StreamReader reader = new StreamReader("2.8_Card_Data.csv"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        data = line.Split(',');
                        for (int i = 0; i < communityCards.Count(); i++)
                        {
                            if (communityCards[i] == Convert.ToInt32(data[0]))
                            {
                                listBoxCommunityCards.Items.Add(data[1] + " of " + data[2]);
                            }
                        }
                    }
                }
            }
            playing = true;
            //Enabling/Disabling buttons
            buttonPlay.Enabled = false;
            buttonCall.Enabled = false;
            buttonRaise.Enabled = false;
            buttonFold.Enabled = false;
            buttonAllIn.Enabled = false;
            EndRound();
        }
        private int Showdown(List<int> hand)
        {
            int communityCard;
            int ranking = 0;
            int aKindx = 0;
            int aKindy = 0;
            int straight = 0;
            int straightPOne = 0;
            int straightPTwo = 0;
            int straightPThree = 0;
            int straightPFour = 0;
            int straightPFive = 0;
            int sxOne = 0;
            int sxTwo = 0;
            int sxThree = 0;
            int sxFour = 0;
            int sxFive = 0;
            int syOne = 0;
            int syTwo = 0;
            int syThree = 0;
            int syFour = 0;
            int syFive = 0;
            int difference = (hand.Max()%13 - hand.Min()%13);
            foreach(int i in communityCards)
            {
                distinctCards.Add(i % 13);
            }
            if (playing == true)
            {
                if (hand[0]%13 == hand[1]%13)
                {
                    aKindx += 1;
                    foreach (int i in communityCards)
                    {
                        communityCard = i%13;
                        //Checking for like Cards
                        if (communityCard == hand[0]%13)
                        {
                            aKindx += 1;
                        }
                        
                    }
                    foreach (int j in distinctCards.Distinct())
                    {
                        //x _ _ _ _
                        if (j > hand[0] % 13 && j < hand[0] % 13 + 5)
                        {
                            straightPOne += 1;
                        }
                        //_ x _ _ _
                        if (j > hand[0] % 13 - 2 && j < hand[0] % 13 + 4 && j != hand[0] % 13)
                        {
                            straightPTwo += 1;
                        }
                        //_ _ x _ _
                        if (j > hand[0] % 13 - 3 && j < hand[0] % 13 + 3 && j != hand[0] % 13)
                        {
                            straightPThree += 1;
                        }
                        //_ _ _ x _
                        if (j > hand[0] % 13 - 4 && j < hand[0] % 13 + 2 && j != hand[0] % 13)
                        {
                            straightPFour += 1;
                        }
                        //_ _ _ _ x
                        if (j > hand[0] % 13 - 5 && j < hand[0] % 13)
                        {
                            straightPFive += 1;
                        }
                    }
                }
                else
                {
                    foreach (int i in communityCards)
                    {
                        //Checking for like Cards
                        if (i % 13 == hand[0] % 13)
                        {
                            aKindx += 1;
                        }
                        else if (i % 13 == hand[1] % 13)
                        {
                            aKindy += 1;
                        }
                    }
                }
                //Checking for consecutive Cards
                if (difference == 0)
                {
                    straight += 1;
                }
                else if (difference < 5 && difference != 0)
                {
                    straight += 2;
                    foreach (int i in distinctCards.Distinct())
                    {
                        //x _ _ _ _
                        if (i > (hand.Min() % 13) && i < (hand.Min()%13 + 5))
                        {
                            sxOne += 1;
                        }
                        //_ x _ _ _
                        if (i > (hand.Min() % 13 - 2) && i < (hand.Min() % 13 + 4) && i != hand.Min() % 13)
                        {
                            sxTwo += 1;
                        }
                        //_ _ x _ _
                        if (i > (hand.Min() % 13 - 3) && i < (hand.Min() % 13 + 3) && i != hand.Min() % 13)
                        {
                            sxThree += 1;
                        }
                        //_ _ _ x _
                        if (i > (hand.Min() % 13 - 4) && i < (hand.Min() % 13 + 2) && i != hand.Min() % 13)
                        {
                            sxFour += 1;
                        }
                        //_ _ _ _ x
                        if (i > (hand.Min() % 13 - 5) && i < (hand.Min() % 13))
                        {
                            sxFive += 1;
                        }

                        //x _ _ _ _
                        if (i > hand.Max() % 13 && i < (hand.Max() % 13 + 5))
                        {
                            syOne += 1;
                        }
                        //_ x _ _ _
                        if (i > (hand.Max() % 13 - 2) && i < (hand.Max() % 13 + 4) && i != hand.Max() % 13)
                        {
                            syTwo += 1;
                        }
                        //_ _ x _ _
                        if (i > (hand.Max() % 13 - 3) && i < (hand.Max() % 13 + 3) && i != hand.Max() % 13)
                        {
                            syThree += 1;
                        }
                        //_ _ _ x _
                        if (i > hand.Max() % 13 - 4 && i < hand.Max() % 13 + 2 && i != hand.Max() % 13)
                        {
                            syFour += 1;
                        }
                        //_ _ _ _ x
                        if (i > hand.Max() % 13 - 5 && i < hand.Max() % 13)
                        {
                            syFive += 1;
                        }
                        if (difference == 1)
                        {
                            //x x _ _ _
                            if (i > hand.Max() % 13 && i < hand.Max() % 13 + 4)
                            {
                                straightPOne += 1;
                            }
                            //_ x x _ _
                            if (i > (hand.Min() % 13 - 2) && i < (hand.Max() % 13 + 3) && i != (hand.Min() % 13) && i != (hand.Max() % 13))
                            {
                                straightPTwo += 1;
                            }
                            //_ _ x x _
                            if (i > hand.Min() % 13 - 3 && i < hand.Max() % 13 + 2 && i != hand.Min() % 13 && i != hand.Max() % 13)
                            {
                                straightPThree += 1;
                            }
                            //_ _ _ x x
                            if (i > hand.Min() % 13 - 4 && i < hand.Min() % 13)
                            {
                                straightPFour += 1;
                            }
                        }
                        else if (difference == 2)
                        {
                            //x _ x _ _
                            if (i > hand.Min() % 13 && i < hand.Max() % 13 + 3 && i != hand.Max() % 13)
                            {
                                straightPOne += 1;
                            }
                            //_ x _ x _
                            if (i > hand.Min() % 13 - 2 && i < hand.Max() % 13 + 2 && i != hand.Min() % 13 && i != hand.Max() % 13)
                            {
                                straightPTwo += 1;
                            }
                            //_ _ x _ x
                            if (i > hand.Min() % 13 - 3 && i < hand.Max() % 13 && i != hand.Min() % 13)
                            {
                                straightPThree += 1;
                            }
                        }
                        else if (difference == 3)
                        {
                            //x _ _ x _
                            if (i > hand.Min() % 13 && i < hand.Max() % 13 + 2 && i != hand.Max() % 13)
                            {
                                straightPOne += 1;
                            }
                            //_ x _ _ x
                            if (i > hand.Min() % 13 - 2 && i < hand.Max() % 13 && i != hand.Min() % 13)
                            {
                                straightPTwo += 1;
                            }
                        }
                        else
                        {
                            //x _ _ _ x
                            if (i < hand.Max() % 13 && i > hand.Min() % 13)
                            {
                                straightPOne += 1;
                            }
                        }
                    }
                }
                if(aKindx == 4 || aKindy == 4)
                {
                    ranking = 8;
                }
                else if(aKindx == 3 && aKindy == 2)
                {
                    ranking = 7;
                }
                else if (aKindx == 2 && aKindy == 3)
                {
                    ranking = 7;
                }
                else if(aKindx == 3 || aKindy == 3)
                {
                    ranking = 4;
                }
                else if(aKindx ==2 || aKindy == 2)
                {
                    ranking = 3;
                }
                else if(aKindx == 1 || aKindy == 1)
                {
                    ranking = 2;
                }
                if(syOne == 4 || (straight + straightPOne >= 5) || sxOne == 4 || syTwo == 4 || (straight + straightPTwo >= 5) || sxTwo == 4 || syThree == 4 || (straight + straightPThree >= 5) || sxThree == 4 || syFour == 4 || (straight + straightPFour >= 5) || sxFour == 4 || (straight + straightPFive >= 5) || syFive == 4 || sxFive == 4)
                {
                    ranking = 5;
                }
            }
            else
            {
                MessageBox.Show("You have discarded your hand and will not participate until the next deal.");
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
                ranking = "One Pair";
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
                if (playing == true)
                {
                    playerRank = Showdown(playerHand);
                    opponentRank = Showdown(opponentHand);
                }
                else
                {
                    opponentRank = Showdown(opponentHand);
                }
                if (playerRank > opponentRank)
                {
                    hand = FiveCardHand(playerRank);
                    MessageBox.Show($"You win" + hand);
                }
                else if(playerRank == opponentRank)
                {
                    hand = FiveCardHand(playerRank);
                    MessageBox.Show($"It's a draw" + hand);
                }
                else
                {
                    hand = FiveCardHand(opponentRank);
                    MessageBox.Show($"You Lost to" + hand);
                }
                buttonPlay.Enabled = true;
            }
        }
    }
}
