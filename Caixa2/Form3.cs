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

        public static int quant;
        public static float nValor;

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

        private void GravarVenda()
        {
            strMySQL = "insert into mercado.caixa(VendaID, ValorTotal) value(@VendaID, @ValorTotal)";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            comando.Parameters.AddWithValue("@VendaID",Convert.ToInt32( codVenda.Text));
            comando.Parameters.AddWithValue("@ValorTotal", Convert.ToDecimal(txbValorDaCompra.Text));

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
            }

            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                Inserir();
                dataGridView1.Rows.Clear();
                TotalVenda = 0;
                txbValorDaCompra.Text = "0";
                con.Close();
            }
        }

        private void Inserir()
        {
            strMySQL = "Insert into mercado.itemvenda(VendaID, ProdutoID, Quantidade, ValorTotal) values(@VendaID, @ProdutoID, @Quantidade, @ValorTotal)";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            try
            {
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@VendaID", codVenda.Text);
                    comando.Parameters.AddWithValue("@ProdutoID", dataGridView1.Rows[i].Cells[0].Value);
                    comando.Parameters.AddWithValue("@Quantidade", dataGridView1.Rows[i].Cells[3].Value);
                    comando.Parameters.AddWithValue("@ValorTotal", float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()));

                    comando.ExecuteNonQuery();


                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        private void ConsultarQuantidade()
        {
            strMySQL = "Select Quantidade from mercado.produtos where ProdutoID='" + txbCod.Text + "'";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            try
            {
                con.Open();
                MySqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    if ((int.Parse(dr["Quantidade"].ToString()) < int.Parse(txbQuant.Text) || (int.Parse(dr["Quantidade"].ToString()) <= 0))) ;
                    {
                        MessageBox.Show("Estoque de produto esgotado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txbQuant.Clear();
                    }
                }

                quant = int.Parse(dr["Quantidade"].ToString());
                if(quant <= 0)
                {
                    txbQuant.Clear();
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

        public void AlterarQuantidade()
        {
            int quantidade = 0;
            quantidade = quant - int.Parse(txbQuant.Text);

            if(quantidade <= 0)
            {
                quantidade = 0;
            }

            strMySQL = "update mercado.produtos set Quantidade = @Quantidade where ProdutoID'" + txbCod.Text + "'";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);
            comando.Parameters.AddWithValue("@Quantidade", quantidade);

            try
            {
                con.Close();
                con.Open();
                comando.ExecuteNonQuery();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            finally
            {
                con.Close();
            }
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
            ConsultarQuantidade();

            if(txbQuant.Text != string.Empty)
            {
                textBox2.Text = (float.Parse(txbValor.Text) * float.Parse(txbQuant.Text)).ToString();
                button1.Focus();
                AlterarQuantidade();
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

            Limpar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GravarVenda();
            GerarCodigoVenda();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nValor = float.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            dataGridView1.Rows.RemoveAt(e.RowIndex);
            TotalVenda -= nValor;
            textBox2.Text = TotalVenda.ToString();
        }

        void FecharForm(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        
        void PularControles(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        void FinalizarCompra(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F10)
            {
                button2.PerformClick();
            }
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            //if(e.KeyCode == Keys.Escape)
            //{
            //    FecharForm(e);
            //}

            //else if (e.KeyCode == Keys.Enter)
            //{
            //    PularControles(e);
            //}

            //else if(e.KeyCode == Keys.F10)
            //{
            //    FinalizarCompra(e);
            //}

            

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    FecharForm(e);
                    break;
                case Keys.Enter:
                    PularControles(e);
                    break;
                case Keys.F10:
                    FinalizarCompra(e);
                    break;
            }

        }
    }
}
