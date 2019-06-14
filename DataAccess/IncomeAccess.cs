using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class IncomeAccess
    {
        ApartmentAutomationEntities db;
        public List<Income> GetIncomesByDate(DateTime date)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Income.Where(i => i.IncomeDate.Value.Year == date.Year && i.IncomeDate.Value.Month == date.Month && i.IncomeDate.Value.Day == date.Day).ToList();
            }
        }

        public int NewIncome(Income income)
        {
            using (db = new ApartmentAutomationEntities())
            {
                db.Income.Add(income);
                return db.SaveChanges();
            }
        }

        public void UpdateIncome(Income income)
        {
            using (db = new ApartmentAutomationEntities())
            {
                Income incomeToUpdate = db.Income.FirstOrDefault(i => i.IncomeID == income.IncomeID);
                incomeToUpdate.IncomeName = income.IncomeName;
                incomeToUpdate.IncomeDescription = income.IncomeDescription;
                incomeToUpdate.IncomePrice = income.IncomePrice;
                income.IncomeDate = income.IncomeDate;
                db.SaveChanges();
            }
        }

        public Income GetIncomeByID(int incomeID)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Income.Find(incomeID);
            }
        }

        public void RemoveIncome(int incomeID)
        {
            using (db = new ApartmentAutomationEntities())
            {
                Income incomeToRemove = db.Income.FirstOrDefault(i => i.IncomeID == incomeID);
                db.Income.Remove(incomeToRemove);
                db.SaveChanges();
            }
        }
    }
}
