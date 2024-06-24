using banco.DAL.DataBases;
using banco.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_DO_CARRINHO.Formularios.Menu_Principal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConexaoDB conexao = new ConexaoDB();
            ComandosDB comandosDB = new ComandosDB(conexao);

   

            // Exemplo de consulta
            string querySelect = "SELECT * FROM tb_carrinho";
            DataTable result = comandosDB.ExecuteQuery(querySelect);

            foreach (DataRow row in result.Rows)
            {
                Console.WriteLine();
                MessageBox.Show(row["ID"] + ", " + row["Nome"]);
            }
          
            //// Exemplo de inserção
            //string queryInsert = "INSERT INTO mytable (column1, column2) VALUES ('value1', 'value2')";
            //int rowsAffected = comandosDB.ExecuteNonQuery(queryInsert);
            //Console.WriteLine("Rows affected: " + rowsAffected);

            //// Exemplo de execução de comando escalar
            //string queryScalar = "SELECT COUNT(*) FROM mytable";
            //object count = comandosDB.ExecuteScalar(queryScalar);
            //Console.WriteLine("Count: " + count);
        }




    }
}

