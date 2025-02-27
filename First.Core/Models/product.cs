using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace First.Core.Models
{
    public class product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int AvilableCount { get; set; }
        public int CreatedBy { get; set; }
        [JsonIgnore]
        public ICollection<productOrder> ProductOrder { get; set; } = new List<productOrder>();


    }
}
