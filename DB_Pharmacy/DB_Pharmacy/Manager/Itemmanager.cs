using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DB_Pharmacy.Models;
using System.Data.Entity.Validation;


namespace DB_Pharmacy.Manager
{
    public class Itemmanager:GeneralManager
    {
        public int Addmed(Itemmodel Item)
        {
            tbl_Item Data = new tbl_Item()
            {
                ItemCode = Item.ItemCode,
                ItemName = Item.ItemName,
                ItemBrandName = Item.ItemBrandName,
                ItemDescription = Item.ItemDescription,
                UnitPrice = Item.Unitprice,
                Sellprice = Item.Sellprice,
                unit = Item.Unit,
                quantity = Item.Quantity,
                Expdate = Item.Expiredate
            };

            db.tbl_Item.Add(Data);
            db.SaveChanges();
            int ID = Data.ItemID;
            return ID;
        }
        
        

        public List<Itemmodel> Getallitem()
        {
            var Data = db.tbl_Item.ToList();
            List<Itemmodel> Items = Data.Select(x => new Itemmodel() { ItemID=x.ItemID, ItemCode = x.ItemCode, ItemName =x.ItemName, ItemBrandName=x.ItemBrandName, ItemDescription=x.ItemDescription, Unitprice=x.UnitPrice, Sellprice = x.Sellprice, Unit=x.unit, Quantity=x.quantity, Expiredate=x.Expdate }).ToList();
            return Items;
        }
        
        public Itemmodel Getitem(int ItemID)
        {
            tbl_Item data = db.tbl_Item.Where(x => x.ItemID == ItemID).FirstOrDefault();
            Itemmodel item = new Itemmodel()
            {
                ItemCode = data.ItemCode,
                ItemName = data.ItemName,
                ItemBrandName = data.ItemBrandName,
                ItemDescription = data.ItemDescription,
                Unitprice = data.UnitPrice,
                Sellprice = data.Sellprice,
                Unit = data.unit,
                Quantity = data.quantity,
                Expiredate = data.Expdate
            };
            return item;
        }

        public bool updateitem(Itemmodel Item)
        {
            tbl_Item data = db.tbl_Item.Where(x => x.ItemID == Item.ItemID).FirstOrDefault();
            bool check = false;
            if ( data != null)
            {
                data.ItemID = Item.ItemID;
                data.ItemCode = Item.ItemCode;
                data.ItemName = Item.ItemName;
                data.ItemBrandName = Item.ItemBrandName;
                data.ItemDescription = Item.ItemDescription;
                data.UnitPrice = Item.Unitprice;
                data.Sellprice = Item.Sellprice;
                data.unit = Item.Unit;
                data.quantity = Item.Quantity;
                data.Expdate = Item.Expiredate;
                db.Entry(data).State = EntityState.Modified;
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

        public bool deleteitem(int ItemID)
        {
            tbl_Item data = db.tbl_Item.Where(x => x.ItemID == ItemID).FirstOrDefault();
            bool check = false;
            if (data != null)
            {
                db.Entry(data).State = EntityState.Deleted;
                db.SaveChanges();
                check = true;
            }
            return check;
        }

    }
}