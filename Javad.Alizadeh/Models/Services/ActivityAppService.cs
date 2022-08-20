using Javad.Alizadeh.Models.Repositories;

namespace Javad.Alizadeh.Models.Services
{
    public class ActivityAppService : IActivityAppService
    {
        private readonly IActivityRepostory _activityRepostory;
        public ActivityAppService(IActivityRepostory activityRepostory)
        {
            _activityRepostory = activityRepostory;
        }
        public OutPutResualt EnsureCodeValidation(int id, int code)
        {
            var output = new OutPutResualt();
            if (code < 100 || code > 10000000)
            {
                output.Messages.Add("Invalid code input!");
                output.Status = 1;
            }
            else
                output.Status = 0;
            return output;
        }

        public OutPutResualt EnsureNameDoesNotExist(string name)
        {
            var output = new OutPutResualt();

            var record = _activityRepostory.Get(name);

            if (record != null)
            {
                output.Messages.Add("Name is already Exist");
                output.Status = 1;
            }
            else
                output.Status = 0;

            return output;

        }

    }
}
