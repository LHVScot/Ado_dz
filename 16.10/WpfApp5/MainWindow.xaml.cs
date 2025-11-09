using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"VLADIMIR\SQLEXPRESS";
                builder.InitialCatalog = "Storage";
                builder.IntegratedSecurity = true;
                conn.ConnectionString = builder.ConnectionString;

                conn.Open();

                string selectQuery = "SELECT * FROM Storage";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
                using (SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Задание 1
                    
                    DataRow newRow = table.NewRow();
                    newRow["Product"] = "Notepad";
                    newRow["Type"] = "Stationer";
                    newRow["Supplier"] = "PaperWorld Inc";
                    newRow["Quantity"] = 25;
                    table.Rows.Add(newRow);

                    // Задание 2
                    
                    adapter.Update(table);

                    // Задание 3
                    
                    var rowToDelete = table.Select("Id = 16").FirstOrDefault();

                    if (rowToDelete != null)
                    {
                        rowToDelete.Delete();
                        adapter.Update(table);
                    }
                }


                // Задание 4

                //1
                
                using (SqlCommand command5 = new SqlCommand("SELECT MAX(Quantity) FROM Storage", conn))
                using (SqlDataReader reader5 = command5.ExecuteReader())
                
                {
                
                    while (reader5.Read())
                    {
                    
                        Textblock3.Text = $"{reader5[0].ToString()}\n";
                        
                    }
                }
                
                using (SqlCommand command6 = new SqlCommand($"SELECT Product FROM Storage WHERE Quantity = {Convert.ToInt32(Textblock3.Text)}", conn))
                using (SqlDataReader reader6 = command6.ExecuteReader())
                {
                    while (reader6.Read())
                    {
                        Textblock3.Text += $"{reader6[0].ToString()}";
                        
                    }
                }



                // 2
                
                using (SqlCommand command7 = new SqlCommand("SELECT MIN(Quantity) FROM Storage", conn))
                using (SqlDataReader reader7 = command7.ExecuteReader())
                {
                    while (reader7.Read())
                    {
                        Textblock4.Text = $"{reader7[0].ToString()}\n";
                        
                    }
                }
                using (SqlCommand command8 = new SqlCommand($"SELECT Product FROM Storage WHERE Quantity = {Convert.ToInt32(Textblock4.Text)}", conn))
                using (SqlDataReader reader8 = command8.ExecuteReader())
                {
                    while (reader8.Read())
                    
                    {
                        Textblock4.Text += $"{reader8[0].ToString()}";
                    }
                }



            }
            
            using (SqlConnection conn1 = new SqlConnection())
            {
                SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
                builder1.DataSource = @"DANIIL\SQLEXPRESS";
                builder1.InitialCatalog = "Storage";
                builder1.IntegratedSecurity = true;
                conn1.ConnectionString = builder1.ConnectionString;

                conn1.Open();

                // 3

                
                using (SqlCommand command2 = new SqlCommand("SELECT MAX(QuantityOfProducts) FROM Suppliers", conn1))
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        Textblock1.Text = $"{reader2[0].ToString()}\n";
                    }
                }
                using (SqlCommand command1 = new SqlCommand($"SELECT Name FROM Suppliers WHERE QuantityOfProducts = {Convert.ToInt32(Textblock1.Text)}", conn1))
                using (SqlDataReader reader1 = command1.ExecuteReader())
                
                {
                    while (reader1.Read())
                    
                    {
                      
                        Textblock1.Text += $"{reader1[0].ToString()}";

                        
                    }
                    
                }


                // 4

                
                using (SqlCommand command3 = new SqlCommand("SELECT MIN(QuantityOfProducts) FROM Suppliers", conn1))
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    
                    {
                    
                        Textblock2.Text = $"{reader3[0].ToString()}\n";
                    }
                    
                }
                
                using (SqlCommand command4 = new SqlCommand($"SELECT Name FROM Suppliers WHERE QuantityOfProducts = {Convert.ToInt32(Textblock2.Text)}", conn1))
                using (SqlDataReader reader4 = command4.ExecuteReader())
                {
                
                    while (reader4.Read())
                    {
                    
                        Textblock2.Text += $"{reader4[0].ToString()}";
                        
                    }
                    
                }

                


            }

        }
    }
}
