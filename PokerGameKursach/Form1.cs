using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGameKursach
{
    public partial class Form1 : Form
    {
        Form Parent;
        public Form1(Form parent)
        {
            Parent = parent;
            InitializeComponent();
#if DEBUG
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.Manual;
#endif
        }


        Random rnd = new Random();
        public int[] PHand = new int[3];   //рука игрока
        public int[] DHand = new int[3];   //рука крупье
        public int PHighestCombination = 0;
        public int DHighestCombination = 0;
        public int HighCardResult = 0;
        public int Quantity = 0;
        public string Congratulations;
        public int Chips = 1000;            //Количество фишек при запуске игры
        public int NowChips = 0;
        public int AnteBet = 0;            //размер начальной ставки (Ante)
        public int PairplusBet = 0;        //размер ставки пара плюс (Pair+)



        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown1.Maximum = (Chips / 2);
            numericUpDown2.Maximum = (Chips / 10);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)                    // КНОПКА НАЧАЛЬНОЙ СТАВКИ (ANTE)
        {
            //начальная ставка

            NowChips = Chips;
            AnteBet = Convert.ToInt32(numericUpDown1.Value);
            Chips -= AnteBet;
            label10.Text = "Chips: " + Convert.ToString(Chips);
            

            (sender as Button).Enabled = false;
            numericUpDown1.Enabled = false;
            button7.Enabled = true;
            if (AnteBet == numericUpDown1.Maximum || Chips == 0)
            {
                button6.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else
            {
                button6.Enabled = true;
                numericUpDown2.Enabled = true;
                if (((NowChips - (AnteBet * 2)) / 2) >= (Chips / 10))
                {
                    numericUpDown2.Maximum = (Chips / 10);
                }
                else
                {
                    numericUpDown2.Maximum = (NowChips - (AnteBet * 2)) / 2;
                }
            }
            pictureBox7.Image = PokerGameKursach.Resource1.newchip;
        }

        private void button2_Click(object sender, EventArgs e)                              // ОТВЕТНАЯ СТАВКА (DOUBLE)
        {
            int temp;
            int len = PHand.Length;

            Chips -= AnteBet;
            label10.Text = "Chips: " + Convert.ToString(Chips);

            GetCard(this.pictureBox4, DHand[0]);
            GetCard(this.pictureBox5, DHand[1]);
            GetCard(this.pictureBox6, DHand[2]);

            //сортировка карт в руках обоих игроков

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (PHand[i] % 100 > PHand[j] % 100)
                    {
                        temp = PHand[i];
                        PHand[i] = PHand[j];
                        PHand[j] = temp;
                    }
                }
            }

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (DHand[i] % 100 > DHand[j] % 100)
                    {
                        temp = DHand[i];
                        DHand[i] = DHand[j];
                        DHand[j] = temp;
                    }
                }
            }


            //анализ комбинаций

            Combinations combinations = new Combinations();

            PHighestCombination = combinations.Combo(PHand[0], PHand[1], PHand[2]);
            DHighestCombination = combinations.Combo(DHand[0], DHand[1], DHand[2]);


            Exceptions exceptions = new Exceptions();

            ChipsAnalys chipsAnalys = new ChipsAnalys();

            //Результат игры:

            if (PHighestCombination == DHighestCombination)
            {

                HighCardResult = exceptions.UException(PHighestCombination, PHand[0], PHand[1], PHand[2], DHand[0], DHand[1], DHand[2]);

                //1 - Игрок победил || 2 - пк победил || 3 - ничья || 0 - у крупье нет игры

                if (HighCardResult == 1)
                {
                    Quantity = chipsAnalys.HardBets(PHighestCombination, AnteBet, PairplusBet, HighCardResult);
                    label9.Text = "PLAYER wins! (Larger denomination/High card)";
                    Chips += Quantity;
                    label10.Text = "Chips: " + Convert.ToString(Chips);
                }
                else if (HighCardResult == 2)
                {
                    label9.Text = "Dealer won! (Larger denomination/High card)";
                    label10.Text = "Chips: " + Convert.ToString(Chips);
                }
                else if (HighCardResult == 3)
                {
                    label9.Text = "Draw!";
                    Chips += (AnteBet + PairplusBet);
                    label10.Text = "Chips: " + Convert.ToString(Chips);
                }
                else
                {
                    Quantity = chipsAnalys.HardBets(PHighestCombination, AnteBet, PairplusBet, HighCardResult);
                    label9.Text = "PLAYER wins! (The dealer has no game)";
                    Chips += Quantity;
                    label10.Text = "Chips: " + Convert.ToString(Chips);
                }
            }
            else
            {
                if (PHighestCombination > DHighestCombination)
                {
                    if ((DHand[0] % 100) >= 12 || (DHand[1] % 100) >= 12 || (DHand[2] % 100) >= 12)
                    {
                        HighCardResult = 1;
                    }
                    else
                    {
                        HighCardResult = 0;
                    }

                    Quantity = chipsAnalys.SimpleBets(PHighestCombination, AnteBet, PairplusBet, HighCardResult);

                    if (PHighestCombination == 2)
                    {
                        Congratulations = "PLAYER wins! (Combination: One pair)";
                        Chips += Quantity;
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else if (PHighestCombination == 3)
                    {
                        Congratulations = "PLAYER wins! (Combination: Flush)";
                        Chips += Quantity;
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else if (PHighestCombination == 4)
                    {
                        Congratulations = "PLAYER wins! (Combination: Straight)";
                        Chips += Quantity;
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else if (PHighestCombination == 5)
                    {
                        Congratulations = "PLAYER wins! (Combination: Three of a kind)";
                        Chips += Quantity;
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else
                    {
                        Congratulations = "PLAYER wins! (Combination: Straight flush)";
                        Chips += Quantity;
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                }
                else
                {
                    if (DHighestCombination == 2)
                    {
                        Congratulations = "Dealer won! (Combination: One pair)";
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else if (DHighestCombination == 3)
                    {
                        Congratulations = "Dealer won! (Combination: Flush)";
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else if (DHighestCombination == 4)
                    {
                        Congratulations = "Dealer won! (Combination: Straight)";
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else if (DHighestCombination == 5)
                    {
                        Congratulations = "Dealer won! (Combination: Three of a kind)";
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                    else
                    {
                        Congratulations = "Dealer won! (Combination: Straight flush)";
                        label10.Text = "Chips: " + Convert.ToString(Chips);
                    }
                }

                label9.Text = Congratulations;
            }
            (sender as Button).Enabled = false;
            button8.Enabled = true;
            button8.Visible = true;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)                              // КНОПКА СБРОСА (FOLD)
        {

            label10.Text = "Chips: " + Convert.ToString(Chips);

            GetCard(this.pictureBox4, DHand[0]);
            GetCard(this.pictureBox5, DHand[1]);
            GetCard(this.pictureBox6, DHand[2]);

            label9.Text = "You folded eour cards";

            (sender as Button).Enabled = false;
            button8.Visible = true;
            button8.Enabled = true;
            button2.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)                              // БЕЗ ПАРЫ ПЛЮС
        {
            PairplusBet = 0;

            Cards q = new Cards();

            int suit_index, rank_index;


            //очистка рук обоих игроков на всякий случай

            for (int i = 0; i < 3; i++)
            {
                PHand[i] = 0;
                DHand[i] = 0;
            }

            //выдача карт

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            PHand[0] = q.cards(suit_index, rank_index);
            GetCard(this.pictureBox1, PHand[0]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            PHand[1] = q.cards(suit_index, rank_index);
            while (PHand[0] == PHand[1])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                PHand[1] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox2, PHand[1]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            PHand[2] = q.cards(suit_index, rank_index);
            while (PHand[0] == PHand[2] || PHand[1] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                PHand[2] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox3, PHand[2]);
            

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            DHand[0] = q.cards(suit_index, rank_index);
            while (DHand[0] == PHand[0] || DHand[0] == PHand[1] || DHand[0] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                DHand[0] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox4, k_hand[0]);


            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            DHand[1] = q.cards(suit_index, rank_index);
            while (DHand[1] == DHand[0] || DHand[1] == PHand[0] || DHand[1] == PHand[1] || DHand[1] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                DHand[1] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox5, k_hand[1]);


            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            DHand[2] = q.cards(suit_index, rank_index);
            while (DHand[2] == DHand[1] || DHand[2] == DHand[0] || DHand[2] == PHand[0] || DHand[2] == PHand[1] || DHand[2] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                DHand[2] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox6, k_hand[2]);


            pictureBox4.Image = Resource1.back2_2;
            pictureBox5.Image = Resource1.back2_2;
            pictureBox6.Image = Resource1.back2_2;

            (sender as Button).Enabled = false;
            numericUpDown2.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)                              // С ПАРОЙ ПЛЮС (PAIR+)
        {
            pictureBox8.Image = PokerGameKursach.Resource1.newchip;

            //ставка пара плюс

            PairplusBet = Convert.ToInt32(numericUpDown2.Value);
            Chips -= PairplusBet;
            label10.Text = "Chips: " + Convert.ToString(Chips);
            

            Cards q = new Cards();

            int suit_index, rank_index;


            //очистка рук обоих игроков на всякий случай

            for (int i = 0; i < 3; i++)
            {
                PHand[i] = 0;
                DHand[i] = 0;
            }

            //выдача карт

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            PHand[0] = q.cards(suit_index, rank_index);
            GetCard(this.pictureBox1, PHand[0]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            PHand[1] = q.cards(suit_index, rank_index);
            while (PHand[0] == PHand[1])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                PHand[1] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox2, PHand[1]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            PHand[2] = q.cards(suit_index, rank_index);
            while (PHand[0] == PHand[2] || PHand[1] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                PHand[2] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox3, PHand[2]);

            

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            DHand[0] = q.cards(suit_index, rank_index);
            while (DHand[0] == PHand[0] || DHand[0] == PHand[1] || DHand[0] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                DHand[0] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox4, k_hand[0]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            DHand[1] = q.cards(suit_index, rank_index);
            while (DHand[1] == DHand[0] || DHand[1] == PHand[0] || DHand[1] == PHand[1] || DHand[1] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                DHand[1] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox5, k_hand[1]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            DHand[2] = q.cards(suit_index, rank_index);
            while (DHand[2] == DHand[1] || DHand[2] == DHand[0] || DHand[2] == PHand[0] || DHand[2] == PHand[1] || DHand[2] == PHand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                DHand[2] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox6, k_hand[2]);

            pictureBox4.Image = Resource1.back2_2;
            pictureBox5.Image = Resource1.back2_2;
            pictureBox6.Image = Resource1.back2_2;

            (sender as Button).Enabled = false;
            numericUpDown2.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)                              // КНОПКА НОВОГО РАУНдА (NEW ROUND)
        {
            GC.Collect();

            if (Chips == 0 || Chips == 1)
            {
                label9.Text = "";
                label9.Text = "You are bankrupt!";
                pictureBox1.Image = PokerGameKursach.Resource1.Empty;
                pictureBox2.Image = PokerGameKursach.Resource1.Empty;
                pictureBox3.Image = PokerGameKursach.Resource1.Empty;
                pictureBox4.Image = PokerGameKursach.Resource1.Empty;
                pictureBox5.Image = PokerGameKursach.Resource1.Empty;
                pictureBox6.Image = PokerGameKursach.Resource1.Empty;
                pictureBox7.Image = PokerGameKursach.Resource1.Empty;
                pictureBox8.Image = PokerGameKursach.Resource1.Empty;

                (sender as Button).Visible = false;
                (sender as Button).Enabled = false;
            }
            else
            {
                label9.Text = "";
                pictureBox1.Image = PokerGameKursach.Resource1.Empty;
                pictureBox2.Image = PokerGameKursach.Resource1.Empty;
                pictureBox3.Image = PokerGameKursach.Resource1.Empty;
                pictureBox4.Image = PokerGameKursach.Resource1.Empty;
                pictureBox5.Image = PokerGameKursach.Resource1.Empty;
                pictureBox6.Image = PokerGameKursach.Resource1.Empty;
                pictureBox7.Image = PokerGameKursach.Resource1.Empty;
                pictureBox8.Image = PokerGameKursach.Resource1.Empty;


                (sender as Button).Visible = false;
                (sender as Button).Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown1.Maximum = (Chips / 2);
                numericUpDown2.Maximum = (Chips / 10);
            }
        }

        private void GetCard(PictureBox Box, int n)
        {
            switch (n)
            {
                case 102:
                    Box.Image = PokerGameKursach.Resource1._102;
                    break;
                case 103:
                    Box.Image = PokerGameKursach.Resource1._103;
                    break;
                case 104:
                    Box.Image = PokerGameKursach.Resource1._104;
                    break;
                case 105:
                    Box.Image = PokerGameKursach.Resource1._105;
                    break;
                case 106:
                    Box.Image = PokerGameKursach.Resource1._106;
                    break;
                case 107:
                    Box.Image = PokerGameKursach.Resource1._107;
                    break;
                case 108:
                    Box.Image = PokerGameKursach.Resource1._108;
                    break;
                case 109:
                    Box.Image = PokerGameKursach.Resource1._109;
                    break;
                case 110:
                    Box.Image = PokerGameKursach.Resource1._110;
                    break;
                case 111:
                    Box.Image = PokerGameKursach.Resource1._111;
                    break;
                case 112:
                    Box.Image = PokerGameKursach.Resource1._112;
                    break;
                case 113:
                    Box.Image = PokerGameKursach.Resource1._113;
                    break;
                case 114:
                    Box.Image = PokerGameKursach.Resource1._114;
                    break;
                case 202:
                    Box.Image = PokerGameKursach.Resource1._202;
                    break;
                case 203:
                    Box.Image = PokerGameKursach.Resource1._203;
                    break;
                case 204:
                    Box.Image = PokerGameKursach.Resource1._204;
                    break;
                case 205:
                    Box.Image = PokerGameKursach.Resource1._205;
                    break;
                case 206:
                    Box.Image = PokerGameKursach.Resource1._206;
                    break;
                case 207:
                    Box.Image = PokerGameKursach.Resource1._207;
                    break;
                case 208:
                    Box.Image = PokerGameKursach.Resource1._208;
                    break;
                case 209:
                    Box.Image = PokerGameKursach.Resource1._209;
                    break;
                case 210:
                    Box.Image = PokerGameKursach.Resource1._210;
                    break;
                case 211:
                    Box.Image = PokerGameKursach.Resource1._211;
                    break;
                case 212:
                    Box.Image = PokerGameKursach.Resource1._212;
                    break;
                case 213:
                    Box.Image = PokerGameKursach.Resource1._213;
                    break;
                case 214:
                    Box.Image = PokerGameKursach.Resource1._214;
                    break;
                case 302:
                    Box.Image = PokerGameKursach.Resource1._302;
                    break;
                case 303:
                    Box.Image = PokerGameKursach.Resource1._303;
                    break;
                case 304:
                    Box.Image = PokerGameKursach.Resource1._304;
                    break;
                case 305:
                    Box.Image = PokerGameKursach.Resource1._305;
                    break;
                case 306:
                    Box.Image = PokerGameKursach.Resource1._306;
                    break;
                case 307:
                    Box.Image = PokerGameKursach.Resource1._307;
                    break;
                case 308:
                    Box.Image = PokerGameKursach.Resource1._308;
                    break;
                case 309:
                    Box.Image = PokerGameKursach.Resource1._309;
                    break;
                case 310:
                    Box.Image = PokerGameKursach.Resource1._310;
                    break;
                case 311:
                    Box.Image = PokerGameKursach.Resource1._311;
                    break;
                case 312:
                    Box.Image = PokerGameKursach.Resource1._312;
                    break;
                case 313:
                    Box.Image = PokerGameKursach.Resource1._313;
                    break;
                case 314:
                    Box.Image = PokerGameKursach.Resource1._314;
                    break;
                case 402:
                    Box.Image = PokerGameKursach.Resource1._402;
                    break;
                case 403:
                    Box.Image = PokerGameKursach.Resource1._403;
                    break;
                case 404:
                    Box.Image = PokerGameKursach.Resource1._404;
                    break;
                case 405:
                    Box.Image = PokerGameKursach.Resource1._405;
                    break;
                case 406:
                    Box.Image = PokerGameKursach.Resource1._406;
                    break;
                case 407:
                    Box.Image = PokerGameKursach.Resource1._407;
                    break;
                case 408:
                    Box.Image = PokerGameKursach.Resource1._408;
                    break;
                case 409:
                    Box.Image = PokerGameKursach.Resource1._409;
                    break;
                case 410:
                    Box.Image = PokerGameKursach.Resource1._410;
                    break;
                case 411:
                    Box.Image = PokerGameKursach.Resource1._411;
                    break;
                case 412:
                    Box.Image = PokerGameKursach.Resource1._412;
                    break;
                case 413:
                    Box.Image = PokerGameKursach.Resource1._413;
                    break;
                case 414:
                    Box.Image = PokerGameKursach.Resource1._414;
                    break;
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            Parent.Show();
            Close();
        }

        private void HomeButton_MouseLeave(object sender, EventArgs e)
        {
            HomeButton.Image = Resource1.MenuButton;
        }

        private void HomeButton_MouseEnter(object sender, EventArgs e)
        {
            HomeButton.Image = Resource1.MenuButtonPush;
        }

        private void HomeButton_MouseDown(object sender, MouseEventArgs e)
        {
            HomeButton.Image = Resource1.MenuButtonMousePush;
        }

        private void HomeButton_MouseUp(object sender, MouseEventArgs e)
        {
            HomeButton.Image = Resource1.MenuButtonPush;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GC.Collect();
        }

        private void ComboButton_MouseEnter(object sender, EventArgs e)
        {
            ComboButton.Image = Resource1.ComboButonPush;
        }

        private void ComboButton_MouseLeave(object sender, EventArgs e)
        {
            ComboButton.Image = Resource1.ComboButton;
        }

        private void ComboButton_MouseDown(object sender, MouseEventArgs e)
        {
            ComboButton.Image = Resource1.ComboButtonMousePush;
        }

        private void ComboButton_MouseUp(object sender, MouseEventArgs e)
        {
            ComboButton.Image = Resource1.ComboButonPush;
        }

        private void ComboButton_Click(object sender, EventArgs e)
        {
            FormCombinations frcmb = new FormCombinations();
            frcmb.Show();
        }
    }
}
