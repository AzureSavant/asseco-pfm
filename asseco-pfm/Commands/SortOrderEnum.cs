using System.Runtime.Serialization;

namespace asseco_pfm.Commands
{
    public enum SortOrderEnum
    {
        [EnumMember(Value = "asc")]
        asc = 0,
            
       [EnumMember(Value = "desc")]
        desc = 1  
    }
}