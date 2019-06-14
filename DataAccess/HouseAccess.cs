using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HouseAccess
    {
        ApartmentAutomationEntities db;
        public List<House> GetHouses()
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.House.ToList();
            }
        }

        public House GetHouseByID(int houseID)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.House.FirstOrDefault(h => h.HouseID == houseID);
            }
        }

        public void NewHouse(House house)
        {
            using (db = new ApartmentAutomationEntities())
            {
                db.House.Add(house);
                db.SaveChanges();
            }
        }

        public void UpdateHouse(House house)
        {
            using (db = new ApartmentAutomationEntities())
            {
                House houseToUpdate = db.House.FirstOrDefault(h => h.HouseID == house.HouseID);
                houseToUpdate.HouseFloor = house.HouseFloor;
                houseToUpdate.HouseNo = house.HouseNo;
                houseToUpdate.HouseHostID = house.HouseHostID;
                db.SaveChanges();
            }
        }
    }
}
