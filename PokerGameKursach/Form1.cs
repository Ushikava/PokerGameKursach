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
        public Form1()
        {
            InitializeComponent();
        }


        Random rnd = new Random();
        public int[] p_hand = new int[3];   //рука игрока
        public int[] k_hand = new int[3];   //рука крупье
        public int highest_combination_p = 0;
        public int highest_combination_k = 0;
        public int high_card_result = 0;
        public int quantity = 0;
        public string congratulations;
        public int chips = 1000;            //Количество фишек при запуске игры
        public int now_chips = 0;
        public int ante_bet = 0;            //размер начальной ставки (Ante)
        public int pairplus_bet = 0;        //размер ставки пара плюс (Pair+)



        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown1.Maximum = (chips / 2);
            numericUpDown2.Maximum = (chips / 10);
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)                    // КНОПКА НАЧАЛЬНОЙ СТАВКИ (ANTE)
        {
            //начальная ставка

            now_chips = chips;
            ante_bet = Convert.ToInt32(numericUpDown1.Value);
            chips -= ante_bet;
            label10.Text = "Chips = " + Convert.ToString(chips);
            

            (sender as Button).Enabled = false;
            numericUpDown1.Enabled = false;
            button7.Enabled = true;
            if (ante_bet == numericUpDown1.Maximum || chips == 0)
            {
                button6.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            else
            {
                button6.Enabled = true;
                numericUpDown2.Enabled = true;
                if (((now_chips - (ante_bet * 2)) / 2) >= (chips / 10))
                {
                    numericUpDown2.Maximum = (chips / 10);
                }
                else
                {
                    numericUpDown2.Maximum = (now_chips - (ante_bet * 2)) / 2;
                }
            }
            pictureBox7.Image = PokerGameKursach.Resource1.fishka2;
        }

        private void button2_Click(object sender, EventArgs e)                              // ОТВЕТНАЯ СТАВКА (DOUBLE)
        {
            int temp;
            int len = p_hand.Length;

            chips -= ante_bet;
            label10.Text = "Chips = " + Convert.ToString(chips);

            GetCard(this.pictureBox4, k_hand[0]);
            GetCard(this.pictureBox5, k_hand[1]);
            GetCard(this.pictureBox6, k_hand[2]);

            //сортировка карт в руках обоих игроков

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (p_hand[i] % 100 > p_hand[j] % 100)
                    {
                        temp = p_hand[i];
                        p_hand[i] = p_hand[j];
                        p_hand[j] = temp;
                    }
                }
            }

            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    if (k_hand[i] % 100 > k_hand[j] % 100)
                    {
                        temp = k_hand[i];
                        k_hand[i] = k_hand[j];
                        k_hand[j] = temp;
                    }
                }
            }


            //анализ комбинаций

            Combinations combinations = new Combinations();

            highest_combination_p = combinations.combo(p_hand[0], p_hand[1], p_hand[2]);
            highest_combination_k = combinations.combo(k_hand[0], k_hand[1], k_hand[2]);


            Exceptions exceptions = new Exceptions();

            ChipsAnalys chipsAnalys = new ChipsAnalys();

            //Результат игры:

            if (highest_combination_p == highest_combination_k)
            {

                high_card_result = exceptions.uexception(highest_combination_p, p_hand[0], p_hand[1], p_hand[2], k_hand[0], k_hand[1], k_hand[2]);

                //1 - Игрок победил || 2 - пк победил || 3 - ничья || 0 - у крупье нет игры

                if (high_card_result == 1)
                {
                    quantity = chipsAnalys.hardbets(highest_combination_p, ante_bet, pairplus_bet, high_card_result);
                    label9.Text = "Победил ИГРОК! Комбинация + Старшая карта ";
                    chips += quantity;
                    label10.Text = "Chips = " + Convert.ToString(chips);
                }
                else if (high_card_result == 2)
                {
                    label9.Text = "Победил ПК! Комбинация + Старшая карта";
                    
                    label10.Text = "Chips = " + Convert.ToString(chips);
                }
                else if (high_card_result == 3)
                {
                    label9.Text = "Ничья!";
                    chips += (ante_bet + pairplus_bet);
                    label10.Text = "Chips = " + Convert.ToString(chips);
                }
                else
                {
                    quantity = chipsAnalys.hardbets(highest_combination_p, ante_bet, pairplus_bet, high_card_result);
                    label9.Text = "У крупье нет игры!";
                    chips += quantity;
                    label10.Text = "Chips = " + Convert.ToString(chips);
                }
            }
            else
            {
                if (highest_combination_p > highest_combination_k)
                {
                    if ((k_hand[0] % 100) >= 12 || (k_hand[1] % 100) >= 12 || (k_hand[2] % 100) >= 12)
                    {
                        high_card_result = 1;
                    }
                    else
                    {
                        high_card_result = 0;
                    }

                    quantity = chipsAnalys.simplebets(highest_combination_p, ante_bet, pairplus_bet, high_card_result);

                    if (highest_combination_p == 2)
                    {
                        congratulations = "Победил ИГРОК! Комб - Пара";
                        chips += quantity;
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else if (highest_combination_p == 3)
                    {
                        congratulations = "Победил ИГРОК! Комб - Флеш";
                        chips += quantity;
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else if (highest_combination_p == 4)
                    {
                        congratulations = "Победил ИГРОК! Комб - Стрит";
                        chips += quantity;
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else if (highest_combination_p == 5)
                    {
                        congratulations = "Победил ИГРОК! Комб - Тройка";
                        chips += quantity;
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else
                    {
                        congratulations = "Победил ИГРОК! Комб - Стрит-флеш";
                        chips += quantity;
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                }
                else
                {
                    if (highest_combination_k == 2)
                    {
                        congratulations = "Победил ПК! Комб - Пара";
                        
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else if (highest_combination_k == 3)
                    {
                        congratulations = "Победил ПК! Комб - Флеш";
                        
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else if (highest_combination_k == 4)
                    {
                        congratulations = "Победил ПК! Комб - Стрит";
                        
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else if (highest_combination_k == 5)
                    {
                        congratulations = "Победил ПК! Комб - Тройка";
                        
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                    else
                    {
                        congratulations = "Победил ПК! Комб - Стрит-флеш";
                        label10.Text = "Chips = " + Convert.ToString(chips);
                    }
                }

                label9.Text = congratulations;
            }

            (sender as Button).Enabled = false;
            button8.Enabled = true;
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)                              // КНОПКА СБРОСА (FOLD)
        {

            label10.Text = "Chips = " + Convert.ToString(chips);

            GetCard(this.pictureBox4, k_hand[0]);
            GetCard(this.pictureBox5, k_hand[1]);
            GetCard(this.pictureBox6, k_hand[2]);

            label9.Text = "Вы сбросили карты";

            (sender as Button).Enabled = false;
            button8.Enabled = true;
            button2.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)                              // КНОПКА НАЧАЛА ИГРЫ (START)
        {
            (sender as Button).Enabled = false;
            button1.Enabled = true;
            numericUpDown1.Enabled = true;
            //button5.Enabled = true;
            numericUpDown1.Maximum = (chips / 2);
        }

        private void button5_Click(object sender, EventArgs e)                              // КНОПКА ПАУЗЫ (PAUSE)
        {
            (sender as Button).Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)                              // БЕЗ ПАРЫ ПЛЮС
        {
            pairplus_bet = 0;

            Cards q = new Cards();

            int suit_index, rank_index;


            //очистка рук обоих игроков на всякий случай

            for (int i = 0; i < 3; i++)
            {
                p_hand[i] = 0;
                k_hand[i] = 0;
            }

            //выдача карт

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            p_hand[0] = q.cards(suit_index, rank_index);
            GetCard(this.pictureBox1, p_hand[0]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            p_hand[1] = q.cards(suit_index, rank_index);
            while (p_hand[0] == p_hand[1])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                p_hand[1] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox2, p_hand[1]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            p_hand[2] = q.cards(suit_index, rank_index);
            while (p_hand[0] == p_hand[2] || p_hand[1] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                p_hand[2] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox3, p_hand[2]);
            

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            k_hand[0] = q.cards(suit_index, rank_index);
            while (k_hand[0] == p_hand[0] || k_hand[0] == p_hand[1] || k_hand[0] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                k_hand[0] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox4, k_hand[0]);


            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            k_hand[1] = q.cards(suit_index, rank_index);
            while (k_hand[1] == k_hand[0] || k_hand[1] == p_hand[0] || k_hand[1] == p_hand[1] || k_hand[1] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                k_hand[1] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox5, k_hand[1]);


            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            k_hand[2] = q.cards(suit_index, rank_index);
            while (k_hand[2] == k_hand[1] || k_hand[2] == k_hand[0] || k_hand[2] == p_hand[0] || k_hand[2] == p_hand[1] || k_hand[2] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                k_hand[2] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox6, k_hand[2]);


            (sender as Button).Enabled = false;
            numericUpDown2.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)                              // С ПАРОЙ ПЛЮС (PAIR+)
        {
            pictureBox8.Image = PokerGameKursach.Resource1.fishka2;

            //ставка пара плюс

            pairplus_bet = Convert.ToInt32(numericUpDown2.Value);
            chips -= pairplus_bet;
            label10.Text = "Chips = " + Convert.ToString(chips);
            

            Cards q = new Cards();

            int suit_index, rank_index;


            //очистка рук обоих игроков на всякий случай

            for (int i = 0; i < 3; i++)
            {
                p_hand[i] = 0;
                k_hand[i] = 0;
            }

            //выдача карт

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            p_hand[0] = q.cards(suit_index, rank_index);
            GetCard(this.pictureBox1, p_hand[0]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            p_hand[1] = q.cards(suit_index, rank_index);
            while (p_hand[0] == p_hand[1])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                p_hand[1] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox2, p_hand[1]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            p_hand[2] = q.cards(suit_index, rank_index);
            while (p_hand[0] == p_hand[2] || p_hand[1] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                p_hand[2] = q.cards(suit_index, rank_index);
            }
            GetCard(this.pictureBox3, p_hand[2]);

            

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            k_hand[0] = q.cards(suit_index, rank_index);
            while (k_hand[0] == p_hand[0] || k_hand[0] == p_hand[1] || k_hand[0] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                k_hand[0] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox4, k_hand[0]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            k_hand[1] = q.cards(suit_index, rank_index);
            while (k_hand[1] == k_hand[0] || k_hand[1] == p_hand[0] || k_hand[1] == p_hand[1] || k_hand[1] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                k_hand[1] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox5, k_hand[1]);

            suit_index = rnd.Next(1, 5);
            rank_index = rnd.Next(2, 15);
            k_hand[2] = q.cards(suit_index, rank_index);
            while (k_hand[2] == k_hand[1] || k_hand[2] == k_hand[0] || k_hand[2] == p_hand[0] || k_hand[2] == p_hand[1] || k_hand[2] == p_hand[2])
            {
                suit_index = rnd.Next(1, 5);
                rank_index = rnd.Next(2, 15);
                k_hand[2] = q.cards(suit_index, rank_index);
            }
            //GetCard(this.pictureBox6, k_hand[2]);

            

            (sender as Button).Enabled = false;
            numericUpDown2.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)                              // КНОПКА НОВОГО РАУНдА (NEW ROUND)
        {
            GC.Collect();

            if (chips == 0 || chips == 1)
            {
                label9.Text = "";
                label9.Text = "Вы банкрот!";
                pictureBox1.Image = PokerGameKursach.Resource1.Empty;
                pictureBox2.Image = PokerGameKursach.Resource1.Empty;
                pictureBox3.Image = PokerGameKursach.Resource1.Empty;
                pictureBox4.Image = PokerGameKursach.Resource1.Empty;
                pictureBox5.Image = PokerGameKursach.Resource1.Empty;
                pictureBox6.Image = PokerGameKursach.Resource1.Empty;
                pictureBox7.Image = PokerGameKursach.Resource1.Empty;
                pictureBox8.Image = PokerGameKursach.Resource1.Empty;
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


                (sender as Button).Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown1.Maximum = (chips / 2);
                numericUpDown2.Maximum = (chips / 10);
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
    }
}
