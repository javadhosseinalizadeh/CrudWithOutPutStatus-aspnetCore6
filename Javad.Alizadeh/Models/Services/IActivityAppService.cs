namespace Javad.Alizadeh.Models.Services
{
    public interface IActivityAppService
    {
        OutPutResualt EnsureNameDoesNotExist(string name);
        OutPutResualt EnsureCodeValidation(int id, int code);
    }
}
