using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DB_Pharmacy.Models;
using System.Data.Entity.Validation;

namespace DB_Pharmacy.Manager
{
    public class PatientManager : GeneralManager
    {
        public int Addpatient(PatientModel PAT)
        {
            tbl_patient P_Data = new tbl_patient()
            {
                PName = PAT.PName,
                Paddress = PAT.Paddress,
                Disease = PAT.Diease
                
                
            };
            
            db.tbl_patient.Add(P_Data);
            db.SaveChanges();
            int ID = P_Data.PID;
            return ID;
        }

        public List<PatientModel> GetallPatient()
        {
            var P_Data = db.tbl_patient.ToList();
            List<PatientModel> PAT = P_Data.Select(x => new PatientModel() { PID = x.PID, PName = x.PName, Paddress = x.Paddress, Diease=x.Disease}).ToList();
            return PAT;
        }

        public PatientModel GetPat(int PID)
        {
            tbl_patient P_Data = db.tbl_patient.Where(x => x.PID == PID).FirstOrDefault();
            PatientModel PAT = new PatientModel()
            {
                PID = P_Data.PID,
                PName = P_Data.PName,
                Paddress = P_Data.Paddress,
                Diease = P_Data.Disease
            };

            return PAT;
        }


        public bool EditPat(PatientModel PAT)
        {
            tbl_patient P_Data = db.tbl_patient.Where(x => x.PID == PAT.PID).FirstOrDefault();
            bool check = false;
            if (P_Data != null)
            {
            
                P_Data.PName = PAT.PName;
                P_Data.Paddress = PAT.Paddress;
                P_Data.Disease = PAT.Diease;
                db.Entry(P_Data).State = EntityState.Modified;
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

        

    }
}