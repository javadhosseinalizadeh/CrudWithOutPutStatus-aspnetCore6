using Javad.Alizadeh.Models.Entities;

namespace Javad.Alizadeh.Models.Services
{
    public interface IActivityService
    {
        OutPutResualt Create(ActivityType activityType);
        OutPutResualt Update(ActivityType activityType);
    }
}
