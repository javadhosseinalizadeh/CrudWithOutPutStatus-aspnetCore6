using Javad.Alizadeh.Models.Entities;

namespace Javad.Alizadeh.Models.Services
{
    public class OutPutResualt
    {
        public List<string> Messages { get; set; } = new List<string>();
        public int Status { get; set; } = 1; //==> 0 -> sussess , 1 -> error
        public ActivityType Output { get; set; }
    }
}
