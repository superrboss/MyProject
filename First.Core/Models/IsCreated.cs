using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First.Core.Models
{
    public class IsCreated
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Created{ get; set; }
    }
}
