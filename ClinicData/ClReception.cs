﻿using Microsoft.Data.SqlClient;
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
        SqlConnection con = new SqlConnection(@"Data Source=blazorprojectdb.database.windows.net,1433;Initial Catalog=BlazorProject_DB;User ID=blazor_user_admin;Password={your_password};Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=False;Persist Security Info=False;Connection Timeout=30;");
        SqlCommand cmd;
        public byte InsertReception(string firstname, string lastname, int age, string beneficiarycode,string mobilenumber,string receptiondate,bool gender, string documentcode)
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
        public DataTable ListfullPatient(string firstname, string lastname,string beneficiarycode,string gender,string receptiondate,string documentcode   )
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string WhereStr = " where 1=1 ";
            if (firstname != ""){
                WhereStr = WhereStr + " and FirstName='" + firstname.ToString() + "'";
            }
            if (lastname != "")
            {
                WhereStr = WhereStr + " and LastName='" + lastname.ToString() + "'";
            }
            if (beneficiarycode != "")
            {
                WhereStr = WhereStr + " and BeneficiaryCode='" + beneficiarycode.ToString() + "'";
            }
            if (documentcode != "")
            {
                WhereStr = WhereStr + " and DocumentCode='" + documentcode.ToString() + "'";
            }
            if (gender != "")
            {
                WhereStr = WhereStr + " and gender='" + gender.ToString() + "'";
            }
            if (receptiondate != "")
            {
                WhereStr = WhereStr + " and ReceptionDate='" + receptiondate.ToString()+"'";
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
