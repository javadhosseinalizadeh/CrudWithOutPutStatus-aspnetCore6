using System.ComponentModel.DataAnnotations;

namespace Javad.Alizadeh.Models.Entities
{
    public class ActivityType : BaseData
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int Code { get; set; }
        public bool IsActive { get; set; }
    }
}
