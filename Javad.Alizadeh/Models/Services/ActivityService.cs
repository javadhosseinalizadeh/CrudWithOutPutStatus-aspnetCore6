
using Javad.Alizadeh.Models.Entities;
using Javad.Alizadeh.Models.Repositories;

namespace Javad.Alizadeh.Models.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityAppService _activityAppService;
        private readonly IActivityRepostory _activityRepostory;

        public ActivityService(IActivityAppService activityAppService, IActivityRepostory activityRepostory)
        {
            _activityRepostory = activityRepostory;
            _activityAppService = activityAppService;
        }
        public OutPutResualt Create(ActivityType activityType)
        {

            activityType.CreatedTime = DateTime.Now;
            var outPutResualt = new OutPutResualt();

            var ensureNameDoesNotExist = _activityAppService.EnsureNameDoesNotExist(activityType.Name);
            var ensureCodeValidation = _activityAppService.EnsureCodeValidation(activityType.Id, activityType.Code);

            if (ensureNameDoesNotExist.Status == 1)
            {
                outPutResualt.Messages.AddRange(ensureNameDoesNotExist.Messages);

                return outPutResualt;
            }
            if (ensureCodeValidation.Status == 1)
            {
                outPutResualt.Messages.AddRange(ensureCodeValidation.Messages);

                return outPutResualt;
            }

            _activityRepostory.Create(activityType);


            if (outPutResualt.Messages.Count == 0)
            {
                outPutResualt.Status = 0;
            }

            return outPutResualt;
        }

        OutPutResualt IActivityService.Update(ActivityType activityType)
        {
            var outPutResualt = new OutPutResualt();

            var ensureNameDoesNotExist = _activityAppService.EnsureNameDoesNotExist(activityType.Name);
            var ensureCodeValidation = _activityAppService.EnsureCodeValidation(activityType.Id, activityType.Code);

            if (ensureNameDoesNotExist.Status == 1)
            {
                outPutResualt.Messages.AddRange(ensureNameDoesNotExist.Messages);
                outPutResualt.Messages.AddRange(ensureCodeValidation.Messages);
                return outPutResualt;
            }
            if (ensureCodeValidation.Status == 1)
            {
                outPutResualt.Messages.AddRange(ensureCodeValidation.Messages);
                return outPutResualt;
            }

            _activityRepostory.Update(activityType);

            if (outPutResualt.Messages.Count == 0)
            {
                outPutResualt.Status = 0;
            }

            return outPutResualt;
        }
    }
}
