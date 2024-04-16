using Azure;
using ClinicData;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBusiness
{
   
    public class ReceptionBusiness
    {
        ClReception obj = new ClReception();
        public byte InsertReception(string firstname, string lastname, int age, string beneficiarycode, string mobilenumber, string receptiondate, bool gender, string documentcode)
        {
            return obj.InsertReception(firstname, lastname, age, beneficiarycode,mobilenumber,receptiondate,gender,documentcode);
        }
        public DataRow FindLastReceptionId()
        {
            return obj.FindLastReceptionId();
        }

        public DataTable ListfullServices()
        {
            return obj.ListfullServices();
        }
        public DataTable ListfullPatient(string firstname, string lastname, string beneficiarycode, string gender, string receptiondate, string documentcode)
        {
            return obj.ListfullPatient(firstname, lastname, beneficiarycode,gender,receptiondate,documentcode);
        }
        public DataRow FindServiceById(int id)
        {
            return obj.FindServiceById(id);
        }

        public DataTable GetSchemaReceptionServiceCS()
        {
            return obj.GetSchemaReceptionServiceCS();
        }

    }
   
}
