using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Caixa2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("datasource = localhost; userid=root;password=33333386;database=saleswebmvcappdb");

        private string strMySQL;

        private void ConsultarProduto()
        {
            strMySQL = "select * from mercado.produtos where ProdutoID= '" + txbConsulta + "'";
            MySqlDataAdapter comando = new MySqlDataAdapter(strMySQL, con);

            try
            {
                con.Open();
                DataSet ds = new DataSet();
                comando.Fill(ds, "mercado.produto");
                int cont = ds.Tables["mercado.produtos"].Rows.Count;

                if(cont == 0)
                {
                    MessageBox.Show("Produto não cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txbConsulta.Clear();
                }

                else if(cont > 0)
                {
                    byte[] data = new byte[0];
                    data = (Byte[])ds.Tables["mercado.produtos"].Rows[cont - 1]["Foto"];
                    MemoryStream stream = new MemoryStream(data);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromStream(stream);
                    txbCod.Text = Convert.ToString(ds.Tables["mercado.produtos"].Rows[cont - 1]["ProdutoID"]);
                    textBox3.Text = Convert.ToString(ds.Tables["mercado.produtos"].Rows[cont - 1]["Nome"]);
                    txbQuantEstoque.Text = Convert.ToString(ds.Tables["mercado.produtos"].Rows[cont - 1]["Quantidade"]);
                    txbValor.Text = Convert.ToString(ds.Tables["mercado.produtos"].Rows[cont - 1]["Preco"]);

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

        private void AlterarProduto()
        {
            strMySQL = "update mercado.produtos set ProdutoID = @ProdutoID, Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade, Foto = @Foto where ProdutoID='" + txbCod.Text + "'";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            comando.Parameters.AddWithValue("@ProdutoID", txbCod.Text);
            comando.Parameters.AddWithValue("@Nome", textBox3.Text);
            comando.Parameters.Add("@Preco", MySqlDbType.Float).Value = txbValor.Text;
            comando.Parameters.AddWithValue("@Quantidade", txbQuantEstoque.Text);
            comando.Parameters.AddWithValue("@Foto", CconverterBitArray());

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Dados salvos com sucesso");
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }

        private void ExcluirProduto()
        {
            strMySQL = "delete from mercado.produtos where ProdutoID = '" + txbCod.Text + "'";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Item Excluido");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                con.Close();
            }
        }

        private byte[] CconverterBitArray()
        {
            MemoryStream stream = new MemoryStream();
            byte[] bArray;
            if (pictureBox1.Image == null)
            {
                stream = null;
                bArray = new byte[stream.Length];
            }
            else if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
            }

            bArray = new byte[stream.Length];
            stream.Read(bArray, 0, Convert.ToInt32(stream.Length));
            return bArray;
        }

        private void txbConsulta_KeyUp(object sender, KeyEventArgs e)
        {
            ConsultarProduto();
            txbConsulta.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Multiselect = false;
            if (abrir.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(abrir.FileName);
            }
        }

        private void btnSalvarAlt_Click(object sender, EventArgs e)
        {
            AlterarProduto();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            ExcluirProduto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            Form1 f1 = new Form1();
            f1.Visible = true;
        }
    }
}
