using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        String connectionString = null;
        SqlConnection sqlConnection = null;
        DataTable dataTable = null;
        SqlCommand sqlCommand = null;
        SqlDataReader sqlDataReader = null;
        public Form1()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        }     
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = textBox1.Text;

                sqlCommand.Connection = sqlConnection;
                dataGridView1.DataSource = null;
                sqlConnection.Open();
                dataTable = new DataTable();

                sqlDataReader = sqlCommand.ExecuteReader();
                int line = 0;

                do
                {
                    while (sqlDataReader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < sqlDataReader.FieldCount; i++)
                            {
                                dataTable.Columns.Add(sqlDataReader.GetName(i));

                            }
                            line++;
                        }
                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            row[i] = sqlDataReader[i];
                        }
                        dataTable.Rows.Add(row);
                    }
                } while (sqlDataReader.NextResult());
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}