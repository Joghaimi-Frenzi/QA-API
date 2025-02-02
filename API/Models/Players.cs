using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Players
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Ensures auto-increment
        public int Id { get; set; }
        public string Name { get; set; }
        public string Answers { get; set; }
        public bool isCorrect { get; set; }
    }
}
