using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class HostAccess
    {
        ApartmentAutomationEntities db;
        public HouseHost GetHostByID(int hostID)
        {
            using (db = new ApartmentAutomationEntities())
            {
                return db.HouseHost.FirstOrDefault(hh => hh.HostID == hostID);
            }
        }

        public void NewHost(HouseHost houseHost)
        {
            using (db = new ApartmentAutomationEntities())
            {
                db.HouseHost.Add(houseHost);
                db.SaveChanges();
            }
        }

        public void UpdateHost(HouseHost houseHost)
        {
            using (db = new ApartmentAutomationEntities())
            {
                HouseHost hostToUpdate = db.HouseHost.FirstOrDefault(hh => hh.HostID == houseHost.HostID);
                hostToUpdate.HostName = houseHost.HostName;
                hostToUpdate.HostLastName = houseHost.HostLastName;
                hostToUpdate.HostPhone = houseHost.HostPhone;
                hostToUpdate.HostTC = houseHost.HostTC;
                hostToUpdate.HostIsRemoved = false;
                db.SaveChanges();
            }
        }
    }
}
