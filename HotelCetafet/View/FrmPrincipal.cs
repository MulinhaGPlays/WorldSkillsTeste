using HotelCetafet.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCetafet
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente formCliente = new FrmCliente();
            formCliente.ShowDialog();
            

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void paisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPais formPais = new FrmPais();
            formPais.ShowDialog();

        }

        private void profissãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProfissao frmProfissao = new FrmProfissao();
            frmProfissao.ShowDialog();
        }
    }
}
