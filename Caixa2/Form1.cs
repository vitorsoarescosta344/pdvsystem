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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("datasource = localhost; userid=root;password=33333386;database=saleswebmvcappdb");

        private string strMySQL;
        private void label1_Click(object sender, EventArgs e)
        {

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
            else if(pictureBox1.Image != null)
            {
                pictureBox1.Image.Save(stream, ImageFormat.Png);
                stream.Seek(0, SeekOrigin.Begin);
            }

            bArray = new byte[stream.Length];
            stream.Read(bArray, 0, Convert.ToInt32(stream.Length));
            return bArray;
        }

        private void CadastrarProduto()
        {
            strMySQL = "insert into mercado.produtos(ProdutoID, Nome, Preco, Quantidade, Foto) values(@ProdutoID, @Nome, @Preco, @Quantidade, @Foto)";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            comando.Parameters.AddWithValue("@ProdutoID", txbCodigo.Text);
            comando.Parameters.AddWithValue("@Nome", textBox3.Text);
            comando.Parameters.Add("@Preco", MySqlDbType.Float).Value = textBox2.Text;
            comando.Parameters.AddWithValue("@Quantidade", textBox4.Text);
            comando.Parameters.AddWithValue("@Foto", CconverterBitArray());

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Produto cadastrado com sucesso!");
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

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarProduto();
            txbCodigo.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txbCodigo_Validating(object sender, CancelEventArgs e)
        {
            strMySQL = "select * from mercado.produtos";
            MySqlCommand comando = new MySqlCommand(strMySQL, con);

            try
            {
                con.Open();
                MySqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    if ((dr.HasRows) && (dr["ProdutoID"].ToString() == txbCodigo.Text))
                    {
                        MessageBox.Show("Código de barras já cadastrado!");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 fc = new Form3();
            fc.ShowDialog();
        }
    }
}
