using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FoodHunter.FoodHunterWeb.DataLayer;
using FoodHunter.FoodHunterWeb.DataLayer.ModelClasses;
using FoodHunter.FoodHunterWeb.DataLayer.RepositoryInterfaces;

namespace FoodHunter.FoodHunterWeb.DataLayer.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly DataContext _context;

        public CheckInRepository()
        {
            _context = new DataContext();
        }

        public List<CheckIn> GetAll()
        {
            return _context.CheckIns.ToList();
        }

        public CheckIn Get(int id)
        {
            return _context.CheckIns.SingleOrDefault(e => e.CheckInId == id);
        }

        public int Insert(CheckIn checkIn)
        {
            this._context.CheckIns.Add(checkIn);

            return _context.SaveChanges();
        }

        public int Update(CheckIn checkIn)
        {
            CheckIn checkInToUpdate = _context.CheckIns.SingleOrDefault(e => e.CheckInId == checkIn.CheckInId);
            foreach (PropertyInfo property in typeof(CheckIn).GetProperties())
            {
                property.SetValue(checkInToUpdate, property.GetValue(checkIn, null), null);
            }

            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            CheckIn checkInToDelete = _context.CheckIns.SingleOrDefault(e => e.CheckInId == id);
            if (checkInToDelete != null) _context.CheckIns.Remove(checkInToDelete);

            return _context.SaveChanges();
        }
    }
}
