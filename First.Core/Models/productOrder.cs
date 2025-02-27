using System.ComponentModel.DataAnnotations;

namespace First.Core.Models
{
    public class productOrder
    {
        [Key]
        public int Id { get; set; }
        public product Product { get; set; }
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public order order { get; set; }
        public int OrdertId { get; set; }


    }
}
