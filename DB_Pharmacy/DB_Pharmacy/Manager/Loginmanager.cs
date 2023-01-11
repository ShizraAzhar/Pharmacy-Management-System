using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DB_Pharmacy.Models;

namespace DB_Pharmacy.Manager
{
    public class Loginmanager : GeneralManager
    {
        public Employeemodel checklogin(Loginmodel logindata)
        {
            var data = db.tbl_plogin.Where(x => x.UserName == logindata.Username && x.userpasword == logindata.userpasword).FirstOrDefault();
            Employeemodel empdata = null;
            if (data != null)
            {
                var data2 = db.tbl_employee.Where(x => x.EID == data.EID).FirstOrDefault();
                empdata = new Employeemodel()
                {
                    FirstName = data2.FirstName,
                    LastName = data2.LastName,
                    EID = data2.EID,
                    Imagepath = data2.Imagepath,
                    logininfo = new Loginmodel() { LoginID = data.LginID, Username = data.UserName, userpasword = data.userpasword, role = data.role }
                };
            }
            return empdata;
        }
    }
}