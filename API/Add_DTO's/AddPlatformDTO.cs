using System.ComponentModel.DataAnnotations;

namespace API.Add_DTO_s
{
    public class AddPlatformDTO
    {
        [StringLength(100)]
        public string Platform_Name { get; set; }
    }
}
