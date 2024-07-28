using System.ComponentModel.DataAnnotations;

namespace DAL.DTO
{
    public class SettlementsDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        // שדות נוספים
    }
}
