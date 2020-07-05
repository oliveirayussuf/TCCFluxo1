using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluxoCaixa
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void cAIXAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CAIXA caixa = new CAIXA();
            caixa.ShowDialog();
        }

        private void pRODUTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRODUTOS produtos = new PRODUTOS();
            produtos.ShowDialog();

        }
    }
}
