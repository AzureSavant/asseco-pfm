

namespace asseco_pfm.DTO
{
    public class SpendingsByCategoryDto
    {
        public List<SpendingInCategory> Groups { get; set; }

        public SpendingsByCategoryDto()
        {
            Groups = new List<SpendingInCategory>();
        }
    }
}