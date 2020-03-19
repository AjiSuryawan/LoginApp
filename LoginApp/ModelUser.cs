using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    class ModelUser
    {
        String idStudentInfo;
        String Name; 
        String Father_Name;
        String Age;
        String Semester;

        public string IdWaliMurid { get => idStudentInfo; set => idStudentInfo = value; }
        public string NamaWaliMurid { get => Name; set => Name = value; }
        public string Alamat { get => Father_Name; set => Father_Name = value; }
        public string NoTelp { get => Age; set => Age = value; }
        public string Email { get => Semester; set => Semester = value; }
    }
}
