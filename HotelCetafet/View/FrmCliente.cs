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

namespace HotelCetafet.View
{
    public partial class FrmCliente : Form
    {
        private ClienteDAL _context;

        public FrmCliente()
        {
            InitializeComponent();
            _context = new ClienteDAL();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private async void FrmCliente_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getClientes();
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;

            textBox1.DataBindings.Add("Text", bindingSource1, "nome", true);
            textBox2.DataBindings.Add("Text", bindingSource1, "Rua", true);
            textBox3.DataBindings.Add("Text", bindingSource1, "bairro", true);
            textBox4.DataBindings.Add("Text", bindingSource1, "cep", true);
            textBox5.DataBindings.Add("Text", bindingSource1, "NumeroCasa", true);
            textBox6.DataBindings.Add("Text", bindingSource1, "TipoDocumento", true);
            textBox7.DataBindings.Add("Text", bindingSource1, "NumeroDocumento", true);
            textBox8.DataBindings.Add("Text", bindingSource1, "TipoPessoa", true);
            comboBox1.DataBindings.Add("Text", bindingSource1, "Sexo", true);
            textBox9.DataBindings.Add("Text", bindingSource1, "DataNascimento", true);
            textBox10.DataBindings.Add("Text", bindingSource1, "Telefone", true);
            textBox11.DataBindings.Add("Text", bindingSource1, "Celular", true);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente novoCliente = new Cliente();
                novoCliente.nome = textBox1.Text;
                await _context.setCadastrarPais(novoCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Cliente profissaoAlterar = (Cliente)bindingSource1.Current;
            await _context.setAtualizar(profissaoAlterar);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await _context.setApagar((Cliente)bindingSource1.Current);
        }

        private async void btnCarregar_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = await _context.getClientes();
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
