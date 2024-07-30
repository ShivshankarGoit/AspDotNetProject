using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Catagorey
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime{ get; set; } = DateTime.Now;
       // public DateTime UpdatedTime { get; set;}

    }
}
