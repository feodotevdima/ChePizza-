using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChePizza_
{
    public partial class Autorization : Form
    {
        public Autorization()
        {
            InitializeComponent();
        }

        private void Autorization_Load(object sender, EventArgs e)
        {
            Helper.connection = new System.Data.OleDb.OleDbConnection();
            Helper.connection.ConnectionString = Helper.ConnectionString;
            try
            {
                Helper.connection.Open();
                MessageBox.Show("Связь с БД установлена");

            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Ошибка подключения " + ex.Message);
                return;
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Вход по логину и паролю с получением роли
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogon_Click(object sender, EventArgs e)
        {
            // String sqlText = "SELECT User.* FROM [User];";
            //String sqlText = "SELECT user.Код, user.namee, user.specialization_ID, user.login, user.password FROM[user];";
            String sqlText = "SELECT user.Код, user.namee, user.login, user.password, specialization.namee FROM specialization INNER JOIN [user] ON specialization.Код = user.specialization_ID;";


            OleDbCommand command = new OleDbCommand(sqlText, Helper.connection);
            OleDbDataReader reader = command.ExecuteReader();
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text; 
            bool isLogin = false;
            while (reader.Read())
            {
                if (reader["login"].ToString() == login && reader["password"].ToString() == password)
                {
                    MessageBox.Show("Вы зарегестрированны в системе со специализацией "+ reader["specialization.namee"].ToString());
                    isLogin = true;
                    switch(reader["specialization.namee"].ToString())
                    {
                        case "Кассир":
                            //тут код касира
                            Cashier cashier = new Cashier();
                            this.Hide();
                            cashier.ShowDialog();
                            this.Show();
                            break;
                        case "Повар":
                            // тут код повара
                            break;
                    }

                    break;
                }
            }
            if (isLogin == false)
            {
                MessageBox.Show("Вы не зарегистрированны в системе");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
