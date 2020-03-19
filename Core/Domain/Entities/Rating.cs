using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CharId { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
