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
        Form1 GameForm;
        public FormMenu()
        {
            InitializeComponent();
#if DEBUG
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.Manual;
#endif
        }

        private void GameStartButton_Click(object sender, EventArgs e)
        {
            if (GameForm == null || GameForm.IsDisposed)
            {
                GameForm = new Form1(this);
            }
            GameForm.Show();

            Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            FormCombinations frcmb = new FormCombinations();
            frcmb.Show();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            FormAbout frabout = new FormAbout();
            frabout.Show();
        }

        private void FormMenu_Shown(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
