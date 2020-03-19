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
    public partial class SantriManagement : Form
    {
        DAOaplikasi daoapps;
        
        public SantriManagement()
        {
            daoapps = new DAOaplikasi();
            InitializeComponent();
            viewDataku();
        }

        public void resetdata() {
            IdTextBox.Text = "";
            NameTextBox.Text = "";
            FnameTextBox.Text = "";
            SemesterTextBox.Text = "";
            AgeTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IdTextBox.Enabled)
                {
                    ModelUser user = new ModelUser();
                    user.IdWaliMurid = IdTextBox.Text.ToString();
                    user.NamaWaliMurid = NameTextBox.Text.ToString();
                    user.Alamat = FnameTextBox.Text.ToString();
                    user.Email = SemesterTextBox.Text.ToString();
                    user.NoTelp = AgeTextBox.Text.ToString();
                    if (daoapps.updateData(user))
                    {
                        MessageBox.Show("berhasil update data");
                        IdTextBox.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("gagal update data");
                    }
                    viewDataku();
                }
                else
                {
                    ModelUser user = new ModelUser();
                    user.IdWaliMurid = IdTextBox.Text.ToString();
                    user.NamaWaliMurid = NameTextBox.Text.ToString();
                    user.Alamat = FnameTextBox.Text.ToString();
                    user.Email = SemesterTextBox.Text.ToString();
                    user.NoTelp = AgeTextBox.Text.ToString();
                    if (daoapps.insertBarang(user))
                    {
                        MessageBox.Show("Insert data sukses");
                        resetdata();
                    }
                    else
                    {
                        MessageBox.Show("Insert data gagal");
                    }
                    viewDataku();
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this data ?", "Delete", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                if (daoapps.deletedata(IdTextBox.Text.ToString()))
                {
                    MessageBox.Show("sukses hapus data");
                }
                else
                {
                    MessageBox.Show("gagal hapus data");
                }
                viewDataku();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        public void viewDataku() {
            try
            {
                var source = new BindingSource();
                source.DataSource = daoapps.getAllBarang();
                dataGridView1.DataSource = source;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=";
                //Display query  
                string Query = "select * from student.studentinfo;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                                                   // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var source = new BindingSource();
                source.DataSource = daoapps.getAllBarang();
                dataGridView1.DataSource = source;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            string nama = dataGridView1.SelectedCells[1].Value.ToString();
            string fname = dataGridView1.SelectedCells[2].Value.ToString();
            string telp = dataGridView1.SelectedCells[3].Value.ToString();
            string semester = dataGridView1.SelectedCells[4].Value.ToString();
            
            NameTextBox.Text = nama;
            FnameTextBox.Text = fname;
            IdTextBox.Text = id;
            SemesterTextBox.Text = semester;
            AgeTextBox.Text = telp;

            IdTextBox.Enabled = false;
            //MessageBox.Show(id);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            daoapps.getAllBarang();
        }
    }
}
