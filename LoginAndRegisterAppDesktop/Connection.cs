using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace LoginAndRegisterAppDesktop
{
    class Connection
    {
        private MySqlConnection connect;
        string serveur;
        string user;
        string password;
        string dataBase;
        public Connection()
        {
            InitializeConnect();
        }

        /// <summary>
        /// Initialisation de connection; Methode appeler au constructeur
        /// </summary>
        private void InitializeConnect()
        {
            serveur = "localhost";
            dataBase = "etudiant";
            user = "root";
            password = "";
            string connectionString;
            connectionString = "Data Source=" + serveur + ";Database=" + dataBase + ";User Id=" + user + ";Password=" + password + ";SSL Mode=0";
            connect = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Impossible de connecter au serveur");
                        break;
                    case 1045:
                        MessageBox.Show("Mot de passe/Username invalid, Try again");
                        break;
                }
                return false;
            }
        }

        public void CloseConnection()
        {
            this.connect.Close();
        }

        public MySqlConnection GetConnection()
        {
            return this.connect;
        }

    }
}
