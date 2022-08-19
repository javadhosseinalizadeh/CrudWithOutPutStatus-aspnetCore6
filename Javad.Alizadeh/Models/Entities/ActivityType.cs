namespace Javad.Alizadeh.Models.Entities
{
    public class ActivityType : BaseData
    {
        public string Name { get; set; } = null!;
        public int Code { get; set; }
        public bool IsActive { get; set; }
    }
}
