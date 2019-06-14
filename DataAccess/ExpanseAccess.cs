using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ExpanseAccess
    {
        ApartmentAutomationEntities db;
        public List<Expanse> GetExpansesByDate(DateTime date)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Expanse.Where(e => e.ExpanseDate.Value.Year == date.Year && e.ExpanseDate.Value.Month == date.Month && e.ExpanseDate.Value.Day == date.Day).ToList();
            }
        }

        public int NewExpanse(Expanse expanse)
        {
            using (db = new ApartmentAutomationEntities())
            {
                db.Expanse.Add(expanse);
                return db.SaveChanges();
            }
        }

        public void UpdateExpanse(Expanse expanse)
        {
            using (db = new ApartmentAutomationEntities())
            {
                Expanse expanseToUpdate = db.Expanse.FirstOrDefault(e => e.ExpenseID == expanse.ExpenseID);
                expanseToUpdate.ExpenseName = expanse.ExpenseName;
                expanseToUpdate.ExpanseDescription = expanse.ExpanseDescription;
                expanseToUpdate.ExpansePrice = expanse.ExpansePrice;
                expanseToUpdate.ExpanseDate = expanse.ExpanseDate;
                db.SaveChanges();
            }
        }

        public Expanse GetExpanseByID(int expanseID)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Expanse.Find(expanseID);
            }
        }

        public void RemoveExpanse(int expanseID)
        {
            using (db = new ApartmentAutomationEntities())
            {
                Expanse expanseToRemove = db.Expanse.FirstOrDefault(e => e.ExpenseID == expanseID);
                db.Expanse.Remove(expanseToRemove);
                db.SaveChanges();
            }
        }
    }
}
