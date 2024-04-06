using ClinicData;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBusiness
{
   
    public class ReceptionBusiness
    {
        ClReception obj = new ClReception();
        public byte InsertReception(string firstname, string lastname, int age, string beneficiarycode)
        {
            return obj.InsertReception(firstname, lastname, age, beneficiarycode);
        }

    }
}
