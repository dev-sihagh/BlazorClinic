using Azure;
using ClinicData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBusiness
{
    public class ReceptionServiceBusiness
    {
        ClReceptionService obj = new ClReceptionService();
        public byte UpdateReceptionServiceTable(DataTable dt)
        {
            return obj.UpdateReceptionServiceTable(dt);
        }
    }
}
