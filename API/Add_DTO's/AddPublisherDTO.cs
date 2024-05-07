using System.ComponentModel.DataAnnotations;

namespace API.Add_DTO_s
{
    public class AddPublisherDTO
    {
        [StringLength(150)]
        public string Publisher_Name { get; set; }
    }
}
