using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Examen3TrimestreDuncan
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            var dbCon = DbConnection.Instance();
            dbCon.DatabaseName = "pajareria";

            if (dbCon.IsConnect())
            {
               
                string query = "USE EMPRESA; SELECT cod_emple, nom_emple, edad, nom_dep  FROM empleados   INNER JOIN departamentos dept      ON departamento=Dept.id_depart; ";
                

                var cmd = new MySqlCommand(query, dbCon.Connection);
                

                MySqlDataReader rdr = cmd.ExecuteReader();
                

                
                while (rdr.Read())
                {
                    
                    texto.Text += "Codigo empleado : " + rdr[0].ToString() + '\n' +
                                  "Nombre : " + rdr[1].ToString() + '\n' +
                                  "Edad : " + rdr[2].ToString() + '\n' +
                                  "Departamento : " + rdr[3].ToString() + '\n' + '\n';


                }
                rdr.Close();

            }
        }

        private void btnInf_Click(object sender, RoutedEventArgs e)
        {
            Informe informe= new Informe();

            informe.ShowDialog();
        }
    }
}
