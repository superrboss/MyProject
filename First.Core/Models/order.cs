using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First.Core.Models
{
    public class order
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public int User_id { get; set; }
        public decimal Total { get; set; }
        public int CreatedBy { get; set; }
        public int EditBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime EditDate { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public ICollection<productOrder> productOrder { get; set; }
    }
}
