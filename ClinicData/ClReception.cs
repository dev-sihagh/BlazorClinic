using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicData
{
    public class ClReception
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HOVKQKU; Initial Catalog=BlazorProject_DB;Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=true;User Id=sa;Password=sina.hgh0832;");
        SqlCommand cmd;
        public byte InsertReception(string firstname, string lastname, int age, string beneficiarycode,string mobilenumber,DateTime receptiondate,bool gender, string documentcode)
        {
            con.Open();
            cmd = new SqlCommand("insert into ReceptionCS values(N'" + firstname + "',N'" + lastname + "',N'" + age + "',N'" + beneficiarycode + "',N'" + mobilenumber + "',N'" + receptiondate + "',N'" + gender + "',N'" + documentcode + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            return 0;
        }
        public DataRow FindLastReceptionId()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select top 1 * From ReceptionCS order by ReceptionId desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt.Rows[0];
        }


        public DataTable ListfullServices()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From BaseService";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable ListfullPatient(string firstname, string lastname,string beneficiarycode,bool gender,DateTime ReceptionDate,string documentcode   )
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string WhereStr = "";
            if (firstname != ""){
                WhereStr = WhereStr + "FirstName=" + firstname.ToString();
            }
            if (lastname != "")
            {
                WhereStr = WhereStr + "LastName=" + lastname.ToString();
            }
            if (beneficiarycode != "")
            {
                WhereStr = WhereStr + "BeneficiaryCode=" + beneficiarycode.ToString();
            }
            if (documentcode != "")
            {
                WhereStr = WhereStr + "DocumentCode=" + documentcode.ToString();
            }

            //if (ReceptionDate != "")
            //{
            //    WhereStr = WhereStr + "FirstName=" + ReceptionDate.ToString();
            //}

            cmd.CommandText = "Select * From ReceptionCS "+ WhereStr.ToString();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataRow FindServiceById(int id)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From BaseService where ServiceId="+ id.ToString();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt.Rows[0];
        }
        public DataTable GetSchemaReceptionServiceCS()
        {
            SqlDataAdapter SqlDa;
            SqlDa = new SqlDataAdapter("Select * From ReceptionServiceCS", con);
            DataTable DT = new DataTable("ReceptionServiceCS");
            SqlDa.FillSchema(DT, SchemaType.Mapped);
            return DT;
        }

    }
}
