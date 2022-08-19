using Javad.Alizadeh.Models.Entities;
using Javad.Alizadeh.Models.Services;

namespace Javad.Alizadeh.Models.Repositories
{
    public interface IActivityRepostory
    {
        public ActivityType Get(int id);
        public ActivityType Get(int id, int code);
        public ActivityType Get(string name);
        public List<ActivityType> GetAll();
        public void Create(ActivityType activityType);
        public void Update(ActivityType activityType);
        public void Delete(int id);


    }
}
