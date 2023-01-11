using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DB_Pharmacy.Models;
using System.Data.Entity.Validation;

namespace DB_Pharmacy.Manager
{
    public class Employeemanager : GeneralManager
    {
        public int Addemp(Employeemodel Emp)
        {
            tbl_employee Data = new tbl_employee()
            {
                FirstName= Emp.FirstName,
                LastName =Emp.LastName,
                eaddress = Emp.eaddress,
                Birthday = Emp.Birthday,
                Gender = Emp.Gender,
                Status = Emp.Status,
                Contactno = Emp.Contactno,
                Nationality = Emp.Nationality,
                Age = Emp.Age,
                Imagepath = Emp.Imagepath
                
            };

            db.tbl_employee.Add(Data);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            int EID = Data.EID;
            return EID;
        }

        public List<Employeemodel> GetAllEmp()
        {
            var Data = db.tbl_employee.ToList();
            List<Employeemodel> Emp = Data.Select(x => new Employeemodel() { EID = x.EID , FirstName = x.FirstName, LastName = x.LastName, eaddress =x.eaddress, Birthday=x.Birthday,Gender = x.Gender, Status=x.Status, Contactno=x.Contactno, Nationality=x.Nationality, Age=x.Age, Imagepath = x.Imagepath }).ToList();
            return Emp;
        }

        public Employeemodel getemp(int EID)
        {
            tbl_employee Data = db.tbl_employee.Where(x => x.EID == EID).FirstOrDefault();
            Employeemodel emp = new Employeemodel()
            {
                FirstName = Data.FirstName,
                LastName = Data.LastName,
                eaddress = Data.eaddress,
                Birthday = Data.Birthday,
                Gender = Data.Gender,
                Status = Data.Status,
                Contactno = Data.Contactno,
                Nationality = Data.Nationality,
                Age = Data.Age,
                Imagepath = Data.Imagepath
            };

            return emp;
        }

        public bool updateemp(Employeemodel Emp)
        {
            tbl_employee Data= db.tbl_employee.Where(x => x.EID == Emp.EID).FirstOrDefault();
            bool check = false;
            if (Data != null)
            {
                Data.EID = Emp.EID;
                Data.FirstName = Emp.FirstName;
                Data.LastName = Emp.LastName;
                Data.eaddress = Emp.eaddress;
                Data.Birthday = Emp.Birthday;
                Data.Gender = Emp.Gender;
                Data.Status = Emp.Status;
                Data.Contactno = Emp.Contactno;
                Data.Nationality = Emp.Nationality;
                Data.Age = Emp.Age;
                Data.Imagepath = Emp.Imagepath;
                db.Entry(Data).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
                check = true;
            }
            return check;

        }


        public bool removeemp(int EID)
        {
            tbl_employee Data = db.tbl_employee.Where(x => x.EID == EID).FirstOrDefault();
            bool check = false;
            if ( Data != null)
            {
                db.Entry(Data).State = EntityState.Deleted;
                try
                {
                    db.SaveChanges();
                }
                catch(DbEntityValidationException e)
                {
                    Console.WriteLine(e);
                }
                
                check = true;
            }
            return check;
        }

    }
}