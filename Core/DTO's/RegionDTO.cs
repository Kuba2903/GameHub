using System.ComponentModel.DataAnnotations;

namespace API.DTO_s
{
    public class RegionDTO
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Region_Name { get; set; }
    }
}
