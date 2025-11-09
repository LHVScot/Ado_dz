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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (SqlConnection conn = new SqlConnection())
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = @"DANIIL\SQLEXPRESS";
                builder.InitialCatalog = "VegetablesAndFruits";
                builder.IntegratedSecurity = true;
                conn.ConnectionString = builder.ConnectionString;

                conn.Open();

                // Задание 3.1
                using (SqlCommand command1 = new SqlCommand("SELECT * FROM VegetablesAndFruits", conn))
                using (SqlDataReader reader1 = command1.ExecuteReader())
                {
                    TextBlock1.Text += "\nId Name Type Color CalorieContent\n";
                    while (reader1.Read())
                    {
                        TextBlock1.Text += $"{reader1[0].ToString()} {reader1[1].ToString()} {reader1[2].ToString()} {reader1[3].ToString()} {reader1[4].ToString()} \n";
                    }
                } 

                // Задание 3.2
                using (SqlCommand command2 = new SqlCommand("SELECT Name FROM VegetablesAndFruits", conn))
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    TextBlock2.Text += "\nName\n";
                    while (reader2.Read())
                    {
                        TextBlock2.Text += $"{reader2[0].ToString()}\n";
                    }
                }

                // Задание 3.3
                using (SqlCommand command3 = new SqlCommand("SELECT Color FROM VegetablesAndFruits", conn))
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    TextBlock3.Text += "\nColor\n";
                    while (reader3.Read())
                    {
                        TextBlock3.Text += $"{reader3[0].ToString()}\n";
                    }
                }

                // Задание 3.4
                using (SqlCommand command4 = new SqlCommand("SELECT MAX(CalorieContent) FROM VegetablesAndFruits", conn))
                using (SqlDataReader reader4 = command4.ExecuteReader())
                {
                    TextBlock4.Text += "\nMaxCalorieContent\n";
                    while (reader4.Read())
                    {
                        TextBlock4.Text += $"{reader4[0].ToString()}\n";
                    }
                }

                // Задание 3.5
                using (SqlCommand command5 = new SqlCommand("SELECT MIN(CalorieContent) FROM VegetablesAndFruits", conn))
                using (SqlDataReader reader5 = command5.ExecuteReader())
                {
                    TextBlock5.Text += "\nMinCalorieContent\n";
                    while (reader5.Read())
                    {
                        TextBlock5.Text += $"{reader5[0].ToString()}\n";
                    }
                }

                // Задание 3.6
                using (SqlCommand command6 = new SqlCommand("SELECT AVG(CalorieContent) FROM VegetablesAndFruits", conn))
                using (SqlDataReader reader6 = command6.ExecuteReader())
                {
                    TextBlock6.Text += "\nAverageCalorieContent\n";
                    while (reader6.Read())
                    {
                        TextBlock6.Text += $"{reader6[0].ToString()}\n";
                    }
                }

                // Задание 4.1
                using (SqlCommand command7 = new SqlCommand("SELECT Name FROM VegetablesAndFruits WHERE Type = 'Vegetable'", conn))
                using (SqlDataReader reader7 = command7.ExecuteReader())
                {
                    TextBlock7.Text += "\nQuantityOfVegetables\n";
                    int quantity = 0;
                    while (reader7.Read())
                    {
                        quantity++;
                    }
                    TextBlock7.Text += $"{quantity}\n";
                }

                // Задание 4.2
                using (SqlCommand command8 = new SqlCommand("SELECT Name FROM VegetablesAndFruits WHERE Type = 'Fruit'", conn))
                using (SqlDataReader reader8 = command8.ExecuteReader())
                {
                    TextBlock8.Text += "\nQuantityOfFruits\n";
                    int quantity = 0;
                    while (reader8.Read())
                    {
                        quantity++;
                    }
                    TextBlock8.Text += $"{quantity}\n";
                }

                // Задание 4.3
                string color = "Green";
                using (SqlCommand command9 = new SqlCommand($"SELECT Name FROM VegetablesAndFruits WHERE Color = '{color}'", conn))
                using (SqlDataReader reader9 = command9.ExecuteReader())
                {
                    TextBlock9.Text += $"\nQuantityOf{color}\n";
                    int quantity = 0;
                    while (reader9.Read())
                    {
                        quantity++;
                    }
                    TextBlock9.Text += $"{quantity}\n";
                }

                // Задание 4.4
                TextBlock10.Text += $"\nRed Green Yellow Orange\n";
                using (SqlCommand command10 = new SqlCommand($"SELECT Name FROM VegetablesAndFruits WHERE Color = 'Red'", conn))
                using (SqlDataReader reader10 = command10.ExecuteReader())
                {
                    int quantityOfRed = 0;
                    while (reader10.Read())
                    {
                        quantityOfRed++;
                    }
                    TextBlock10.Text += $"{quantityOfRed}      ";
                }
                using (SqlCommand command11 = new SqlCommand($"SELECT Name FROM VegetablesAndFruits WHERE Color = 'Green'", conn))
                using (SqlDataReader reader11 = command11.ExecuteReader())
                {
                    int quantityOfGreen = 0;
                    while (reader11.Read())
                    {
                        quantityOfGreen++;
                    }
                    TextBlock10.Text += $"{quantityOfGreen}        ";
                }
                using (SqlCommand command12 = new SqlCommand($"SELECT Name FROM VegetablesAndFruits WHERE Color = 'Yellow'", conn))
                using (SqlDataReader reader12 = command12.ExecuteReader())
                {
                    int quantityOfYellow = 0;
                    while (reader12.Read())
                    {
                        quantityOfYellow++;
                    }
                    TextBlock10.Text += $"{quantityOfYellow}         ";
                }
                using (SqlCommand command13 = new SqlCommand($"SELECT Name FROM VegetablesAndFruits WHERE Color = 'Orange'", conn))
                using (SqlDataReader reader13 = command13.ExecuteReader())
                {
                    int quantityOfOrange = 0;
                    while (reader13.Read())
                    {
                        quantityOfOrange++;
                    }
                    TextBlock10.Text += $"{quantityOfOrange}";
                }

                // Задание 4.5
                int Calories1 = 53;
                using (SqlCommand command14 = new SqlCommand($"SELECT Name, CalorieContent FROM VegetablesAndFruits WHERE CalorieContent < {Calories1}", conn))
                using (SqlDataReader reader14 = command14.ExecuteReader())
                {
                    TextBlock11.Text += $"\nProduceWithCalories < {Calories1}\n";
                    while (reader14.Read())
                    {
                        TextBlock11.Text += $"{reader14[0].ToString()} {reader14[1].ToString()}\n";
                    }
                }

                // Задание 4.6
                int Calories2 = 37;
                using (SqlCommand command15 = new SqlCommand($"SELECT Name, CalorieContent FROM VegetablesAndFruits WHERE CalorieContent > {Calories2}", conn))
                using (SqlDataReader reader15 = command15.ExecuteReader())
                {
                    TextBlock12.Text += $"\nProduceWithCalories > {Calories2}\n";
                    while (reader15.Read())
                    {
                        TextBlock12.Text += $"{reader15[0].ToString()} {reader15[1].ToString()} \n";
                    }
                }

                // Задание 4.7
                int Calories3 = 14;
                int Calories4 = 43;
                using (SqlCommand command16 = new SqlCommand($"SELECT Name, CalorieContent FROM VegetablesAndFruits WHERE CalorieContent > {Calories3} AND CalorieContent < {Calories4}", conn))
                using (SqlDataReader reader16 = command16.ExecuteReader())
                {
                    TextBlock13.Text += $"\n{Calories3} > ProduceWithCalories > {Calories4}\n";
                    while (reader16.Read())
                    {
                        TextBlock13.Text += $"{reader16[0].ToString()} {reader16[1].ToString()} \n";
                    }
                }

                // Задание 4.8
                using (SqlCommand command17 = new SqlCommand($"SELECT Name, Color FROM VegetablesAndFruits WHERE Color = 'Red' OR Color = 'Yellow'", conn))
                using (SqlDataReader reader17 = command17.ExecuteReader())
                {
                    TextBlock14.Text += $"\nRedAndYellowProduce\n";
                    while (reader17.Read())
                    {
                        TextBlock14.Text += $"{reader17[0].ToString()} {reader17[1].ToString()} \n";
                    }
                }
            }
        }
    }
}
