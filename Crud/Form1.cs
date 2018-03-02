using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Crud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Variavel para conexao com o DB
        SqlConnection sqlCon = null;



        //Sting de conexão com o DB sql
        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CRUD;Data Source=DANIEL-NOTEBOOK\SQLSERVER; ";

        private string strSql = string.Empty;


        private void button1_Click(object sender, EventArgs e)
        {
            strSql = "insert into usuario (nome, idade) values (@nome, @idade)";

            sqlCon = new SqlConnection(strCon);

            SqlCommand comando = new SqlCommand(strSql, sqlCon);


            //Passando o conteudo dos textbox para as variaveis usadas no insert
            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@idade", SqlDbType.Int).Value = txtIdade.Text;

            //Tratamento de exeções
            //Se Cadastrado com sucesso
            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro efetuado com sucesso");
            }
            //Caso ocorra uma exeção
            catch (Exception ex)
            {
                //Exibi mensagem de exeção
                MessageBox.Show(ex.Message);

            }
            finally
            //Finalizando - Fechando a conexão com o BD
            {
                sqlCon.Close();
            }
        }
    }
}
