using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApartmentAccess
    {
        ApartmentAutomationEntities db;
        public Apartment GetApartmentInfo()
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.Apartment.FirstOrDefault();
            }
        }

        public void UpdateApartment(Apartment apartment)
        {
            using (db = new ApartmentAutomationEntities())
            {
                Apartment apartmentToUpdate = db.Apartment.FirstOrDefault(a => a.ApartmentID == apartment.ApartmentID);
                apartmentToUpdate.ApartmentNo = apartment.ApartmentNo;
                apartmentToUpdate.ApartmentName = apartment.ApartmentName;
                apartmentToUpdate.ApartmentAddress = apartment.ApartmentAddress;
                db.SaveChanges();
            }
        }

        public void NewApartment(Apartment apartment)
        {
            using (db = new ApartmentAutomationEntities())
            {
                db.Apartment.Add(apartment);
                db.SaveChanges();
            }
        }
    }
}
