using HotelCetafet.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelCetafet.View
{
    public partial class FrmProfissao : Form
    {
        private ProfissaoDAL _context;

        public FrmProfissao()
        {
            InitializeComponent();
            _context = new ProfissaoDAL();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Profissao novaProfissao = new Profissao();
                novaProfissao.descricao = textBox1.Text;
                await _context.setCadastrarPais(novaProfissao);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Profissao profissaoAlterar = (Profissao)bindingSource1.Current;
            await _context.setAtualizar(profissaoAlterar);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await _context.setApagar((Profissao)bindingSource1.Current);
        }

        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getProfissoes();
            dataGridView1.DataSource = bindingSource1;
        }

        private async void textBox4_TextChanged(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getProfissaoLetraInicial(textBox4.Text);
            dataGridView1.DataSource = bindingSource1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void FrmProfissao_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getProfissoes();
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            textBox1.DataBindings.Add("Text", bindingSource1, "descricao", true);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private async void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            await _context.setApagar((Profissao)bindingSource1.Current);
        }
    }
}
