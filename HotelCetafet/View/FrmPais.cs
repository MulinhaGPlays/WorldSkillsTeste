using HotelCetafet.Modelo;
using System;
using System.Windows.Forms;

namespace HotelCetafet.View
{
    public partial class FrmPais : Form
    {
        private PaisDAO _context;

        public FrmPais()
        {
            InitializeComponent();
            _context = new PaisDAO();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pais novoPais = new Pais();
                novoPais.nome = textBox1.Text;
                novoPais.sigla = textBox2.Text;
                novoPais.Populacao = Convert.ToInt32(textBox3.Text);
                await _context.setCadastrarPais(novoPais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getPaises();
            dataGridView1.DataSource = bindingSource1;
        }

        private async void textBox4_TextChanged(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getPaisLetraInicial(textBox4.Text);
            dataGridView1.DataSource = bindingSource1;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Pais paisAlterar = (Pais)bindingSource1.Current;
            await _context.setAtualizar(paisAlterar);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await _context.setApagar((Pais) bindingSource1.Current);
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private async void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            await _context.setApagar((Pais)bindingSource1.Current);
        }

        private async void FrmPais_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getPaises();
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            textBox1.DataBindings.Add("Text", bindingSource1, "nome", true);
            textBox2.DataBindings.Add("Text", bindingSource1, "sigla", true);
            textBox3.DataBindings.Add("Text", bindingSource1, "Populacao", true);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
