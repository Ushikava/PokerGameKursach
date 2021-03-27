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
    public partial class FormCombinations : Form
    {
        public FormCombinations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            Close();
        }

        private void FormCombinations_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }

        private void FormCombinations_Load(object sender, EventArgs e)
        {

        }
    }
}
