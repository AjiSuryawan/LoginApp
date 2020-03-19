using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace LoginApp
{
    class DAOaplikasi
    {
        ModelUser user;
        string MyConnection = "datasource=localhost;port=3306;username=root;password=";
        public bool insertBarang(ModelUser user)
        {
            bool status = true;
            try
            {

                string Query = "insert into student.studentinfo(idStudentInfo,Name,Father_Name,Age,Semester) values('" + user.IdWaliMurid + "','" + user.NamaWaliMurid + "','" + user.Alamat + "','" + user.NoTelp + "','" + user.Email + "');";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.
                MyConn2.Close();
            }
            catch (Exception e)
            {
                status = false;
            }
            return status;
        }

        public bool updateData(ModelUser user)
        {
            bool status = true;
            try
            {

                string Query = "update student.studentinfo set idStudentInfo='" + user.IdWaliMurid
                    + "',Name='" + user.NamaWaliMurid + "',Father_Name='" + user.Alamat + "',Age='" + user.NoTelp + "',Semester='" + user.Email + "' where idStudentInfo='" + user.IdWaliMurid + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();//Connection closed here
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool deletedata(String id)
        {
            bool status = true;
            try
            {

                string Query = "delete from student.studentinfo where idStudentInfo='" + id + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public List<ModelUser> getAllBarang()
        {
            List<ModelUser> getMhs = new List<ModelUser>();
            string Query = "select * from student.studentinfo;";
            
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
            MyConn2.Open();
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader myReader;
            myReader = MyCommand2.ExecuteReader();
            try
            {
                while (myReader.Read())
                {
                    user = new ModelUser();
                    Console.WriteLine(myReader.GetString(0));
                    user.IdWaliMurid = myReader.GetString(1);
                    user.NamaWaliMurid = myReader.GetString(2);
                    user.Alamat = myReader.GetString(3);
                    user.NoTelp = myReader.GetString(4);
                    user.Email = myReader.GetString(5);
                    getMhs.Add(user);
                }
            }
            finally
            {
                myReader.Close();
                
            }
            return getMhs;
        }
    }
}