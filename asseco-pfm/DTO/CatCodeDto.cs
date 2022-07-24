using System.ComponentModel.DataAnnotations;

namespace asseco_pfm.DTO
{
    public class CatCodeDto
    {
        [Required]
        public string CatCode { get; set; }
    }
}
