using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace First.Core.Models
{
    public class User
    {
        [Key]
        public int Id{ get; set; }
        public string Email{ get; set; }
        public string UserName{ get; set; }
        public string Password{ get; set; }

        [JsonIgnore]
        public ICollection<order> orders {  get; set; }  = new List<order>();

    }
}
