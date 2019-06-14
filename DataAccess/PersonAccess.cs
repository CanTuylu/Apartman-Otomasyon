using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace DataAccess
{
    public class PersonAccess
    {
        ApartmentAutomationEntities db;
        public bool IsAnyPersonRegistered()
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Person.Count() != 0 ? true : false;
            }
        }

        public int RegisterPerson(Person person)
        {
            using (db = new ApartmentAutomationEntities())
            {
                db.Person.Add(person);
                return db.SaveChanges();
            }
        }

        public bool IsTcTrue(string tc)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Person.First().PersonTC == tc ? true : false;
            }
        }

        public bool IsPasswordTrue(LoginVM loginVM)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Person.FirstOrDefault(p => p.PersonTC == loginVM.TC).PersonPassword == loginVM.Password ? true : false;
            }
        }

        public void UpdatePerson(Person person)
        {
            using (db = new ApartmentAutomationEntities())
            {
                Person personToUpdate = db.Person.FirstOrDefault(p => p.PersonID == person.PersonID);
                personToUpdate.PersonName = person.PersonName;
                personToUpdate.PersonLastName = person.PersonLastName;
                personToUpdate.PersonTC = person.PersonTC;
                personToUpdate.PersonPassword = person.PersonPassword;
                db.SaveChanges();
            }
        }

        public Person GetPersonByTc(string tc)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Person.FirstOrDefault(p => p.PersonTC == tc);
            }
        }
    }
}
