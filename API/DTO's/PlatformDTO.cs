using System.ComponentModel.DataAnnotations;

namespace API.DTO_s
{
    public class PlatformDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Platform_Name { get; set; }
    }
}
