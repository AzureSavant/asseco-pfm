using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace asseco_pfm.DTO
{
    public class CatCodeDto
    {
        [DataMember(Name = "catCode")]
        public string CatCode { get; set; }
    }
}
