using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using System.Reflection;

namespace ClinicData
{
    
    public class ClReceptionService
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HOVKQKU; Initial Catalog=BlazorProject_DB;Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=true;User Id=sa;Password=sina.hgh0832;");
        SqlCommand cmd;

        public byte UpdateReceptionServiceTable(DataTable dt)
        {
            //SqlConnection cnn = new SqlConnection(con);
            con.Open();
            foreach (DataRow dr in dt.Rows)
            {
                cmd = new SqlCommand("insert into ReceptionServiceCS values(N'" + dr["ReceptionId"] + "',N'" + dr["ServiceId"] + "',N'" + dr["ServiceName"].ToString() + "',N'" + dr["BeneficiaryName"].ToString() + "',N'" + dr["ServiceCount"] + "')", con);
                cmd.ExecuteNonQuery();
            }
        
            con.Close();
            return 0;
        }


    }
}
