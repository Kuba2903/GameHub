using System.ComponentModel.DataAnnotations;

namespace API.Add_DTO_s
{
    public class AddRegionDTO
    {
        [StringLength(100)]
        public string Region_Name { get; set; }
    }
}
