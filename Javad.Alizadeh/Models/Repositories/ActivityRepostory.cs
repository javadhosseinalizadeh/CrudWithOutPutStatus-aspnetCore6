using Javad.Alizadeh.Models.Data;
using Javad.Alizadeh.Models.Entities;
using Javad.Alizadeh.Models.Services;

namespace Javad.Alizadeh.Models.Repositories
{
    public class ActivityRepostory : IActivityRepostory
    {
        private readonly ActivityDbContext _context;
        public ActivityRepostory(ActivityDbContext context)
        {
            _context = context;
        }

        public void Create(ActivityType activityType)
        {
            activityType.CreatedTime = DateTime.Now;
            _context.ActivityTypes.Add(activityType);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var activityType = _context.ActivityTypes.Where(a => a.Id == id).Single();
            _context.Remove(activityType);
            _context.SaveChanges();
        }



        public ActivityType Get(int id)
        {
            var result = _context.ActivityTypes.Where(a => a.Id == id).SingleOrDefault();
            return result;
        }

        public ActivityType Get(int id, int code)
        {
            var result = _context.ActivityTypes.Where(a => a.Id == id && a.Code == code).SingleOrDefault();
            return result;
        }

        public ActivityType Get(string name)
        {
            var result = _context.ActivityTypes.Where(a => a.Name == name).FirstOrDefault();
            return result;
        }

        public List<ActivityType> GetAll()
        {
            var result = _context.ActivityTypes.ToList();
            return result;
        }

        public void Update(ActivityType activityType)
        {
            _context.Entry(activityType).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
