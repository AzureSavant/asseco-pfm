using asseco_pfm.Commands;
using asseco_pfm.DTO;
using asseco_pfm.Models;

namespace asseco_pfm.Services
{
    public interface IAnalyticService
    {
        SpendingsByCategoryDto SpendingsGet(string catcode,  DateTime? startDate,  DateTime? endDate, DirectionsEnum direction);
    }
}
