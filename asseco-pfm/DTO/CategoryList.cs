using asseco_pfm.Models;
using System.Runtime.Serialization;

namespace asseco_pfm.DTO
{
    public class CategoryList
    {
        [DataMember(Name = "items")]
        public List<Category> Items { get; set; }
    }
}
