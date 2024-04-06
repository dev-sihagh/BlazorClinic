using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicData
{
    public class ClReception
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HOVKQKU; Initial Catalog=BlazorProject_DB;Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=true;User Id=sa;Password=sina.hgh0832;");
        SqlCommand cmd;
        public byte InsertReception(string firstname, string lastname, int age, string beneficiarycode)
        {
            con.Open();
            cmd = new SqlCommand("insert into ReceptionCS values(N'" + firstname + "',N'" + lastname + "',N'" + age + "',N'" + beneficiarycode + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 0;
        }

    }
}
