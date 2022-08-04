

namespace asseco_pfm.DTO
{
    public class SpendingsByCategoryDto
    {
        public HashSet<SpendingInCategory> Groups { get; set; }

        public SpendingsByCategoryDto()
        {
            Groups = new HashSet<SpendingInCategory>();
        }
    }
}