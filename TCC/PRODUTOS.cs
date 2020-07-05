using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluxoCaixa
{
    public partial class PRODUTOS : Form
    {
        public PRODUTOS()
        {
            InitializeComponent();


            txt_pesquisa.Enabled = false;
            txt_preco.Enabled = false;
            txt_marca.Enabled = false;
            txt_prod.Enabled = false;
            txt_quant.Enabled = false;
        }

        SqlConnection sqlCon = null;
        private string strCon = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Fluxodb;Data Source=YUSSUF";
        private string strSql = string.Empty;


        private void ADD_Click(object sender, EventArgs e)
        {
            txt_pesquisa.Enabled = true;
            txt_preco.Enabled = true;
            txt_marca.Enabled = true;
            txt_prod.Enabled = true;
            txt_quant.Enabled = true;
        }

        private void SALVAR_Click(object sender, EventArgs e)
        {
            strSql = "Insert into dbo.PRODUTOS(idproduto,produto,marca,quantidade,preco) values(@idproduto,@produto,@marca,@quantidade,@preco)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@idproduto", SqlDbType.Int).Value = int.Parse(txt_pesquisa.Text);
            comando.Parameters.Add("@produto", SqlDbType.VarChar).Value = (txt_prod.Text);
            comando.Parameters.Add("@marca", SqlDbType.VarChar).Value = (txt_marca.Text);
            comando.Parameters.Add("@quantidade", SqlDbType.Int).Value = int.Parse(txt_quant.Text);
            comando.Parameters.Add("@preco", SqlDbType.Int).Value = decimal.Parse(txt_preco.Text);


            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("CADASTRO EFETUADO COM SUCESSO!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
            txt_pesquisa.Enabled = true;

            txt_marca.Clear();
            txt_prod.Clear();
            txt_quant.Clear();
            txt_preco.Clear();
            txt_pesquisa.Clear();
        }

        private void BUSCAR_Click(object sender, EventArgs e)
        {
            strSql = "select = from Fluxodb where idproduto = @idproduto";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@idproduto", SqlDbType.Int).Value = int.Parse(txt_pesquisa.Text);

            try
            {
                sqlCon.Open();
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false)
                {
                    throw new Exception("OPS! ESTE PRODUTO NÃO ESTÁ CADASTRADO!");
                }
                dr.Read();

                txt_pesquisa.Text = Convert.ToString(dr["idproduto"]);
                txt_prod.Text = Convert.ToString(dr["idproduto"]);
                txt_marca.Text = Convert.ToString(dr["idproduto"]);
                txt_quant.Text = Convert.ToString(dr["idproduto"]);
                txt_preco.Text = Convert.ToString(dr["idproduto"]);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }


        }
    }
}
