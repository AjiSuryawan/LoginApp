using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LoginApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            PassTextBox.PasswordChar = '•';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = "admin";
            String pass = "admin";
            if (user == this.UserTextBox.Text && pass == this.PassTextBox.Text)
            {
                    this.Hide();
                    MainMenu f2 = new MainMenu();
                    f2.ShowDialog();
            
            }
        }
    }
}
