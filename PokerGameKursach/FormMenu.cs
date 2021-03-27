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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
            FormCombinations frcmb = new FormCombinations();
            frcmb.Show();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
            FormAbout frabout = new FormAbout();
            frabout.Show();
        }
    }
}
