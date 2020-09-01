using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caixa2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("datasource = localhost; userid=root;password=33333386;database=saleswebmvcappdb");

        private string strMySQL;

        float TotalVenda;

        private void GerarCodigoVenda()
        {
            strMySQL = "select max(VendaID) from mercado.caixa";

            try
            {
                con.Open();
                MySqlCommand comando = new MySqlCommand(strMySQL, con);

                if (comando.ExecuteScalar() == DBNull.Value)
                {
                    codVenda.Text = "1";
                }

                else
                {
                    Int32 ra = Convert.ToInt32(comando.ExecuteScalar()) + 1;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }

        private void ConsultarProduto()
        {
            strMySQL = "select * from mercado.produtos where ProdutoID = '"+txbCod.Text+"'";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            try
            {
                con.Open();
                MySqlDataReader dr = comando.ExecuteReader();

                if (!dr.HasRows)
                {
                    MessageBox.Show("Produto não encontrado");
                }

                else
                {
                    textBox3.Text = dr["Nome"].ToString();
                    int quantidade = int.Parse(dr["Quantidade"].ToString());
                    txbValor.Text = dr["Preco"].ToString();

                }
            }

            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                con.Close();
            }
        }

        void Limpar()
        {
            txbCod.Clear();
            txbValor.Clear();
            textBox3.Clear();
            txbQuant.Clear();
            textBox2.Clear();
        }

        private void NomearDataGrid()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Produto";
            dataGridView1.Columns[1].Width = 267;
            dataGridView1.Columns[2].Name = "Valor Unitário"; 
            dataGridView1.Columns[3].Name = "Quantidade"; 
            dataGridView1.Columns[4].Name = "Total";

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            GerarCodigoVenda();
            NomearDataGrid();
        }

        private void txbCod_Validating(object sender, CancelEventArgs e)
        {
            if(txbCod.Text != string.Empty)
            {
                ConsultarProduto();
            }

            else
            {
                txbCod.Focus();
            }

        }

        private void txbQuant_Validating(object sender, CancelEventArgs e)
        {
            if(txbQuant.Text != string.Empty)
            {
                textBox2.Text = (float.Parse(txbValor.Text) * float.Parse(txbQuant.Text)).ToString();
                button1.Focus();
            }
            else
            {
                MessageBox.Show("Digite a quantidade", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txbQuant.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(txbCod.Text, textBox3.Text, txbValor.Text, txbQuant.Text, textBox2.Text);
            TotalVenda += float.Parse(textBox2.Text);
            txbValorDaCompra.Text = TotalVenda.ToString(); 
        }
    }
}
