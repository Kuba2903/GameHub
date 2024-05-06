using System.ComponentModel.DataAnnotations;

namespace API.DTO_s
{
    public class PublisherDTO
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Publisher_Name { get; set; }
    }
}
