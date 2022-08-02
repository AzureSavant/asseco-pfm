using asseco_pfm.Commands;
using System.Runtime.Serialization;
using asseco_pfm.Models;

namespace asseco_pfm.DTO
{
    public class TransactionList
    {
        [DataMember(Name = "page-size")]
        public int PageSize { get; set; }
        [DataMember(Name = "page")]
        public int Page { get; set; }
        [DataMember(Name = "total-count")]
        public int TotalCount { get; set; }
        [DataMember(Name = "sort-by")]
        public string SortBy { get; set; }
        [DataMember(Name = "sort-order")]
        public SortOrderEnum SortOrder { get; set; }
        [DataMember(Name = "items")]
        public List<Transaction> Items { get; set; }

        public TransactionList(int pageSize, int page, int totalCount, string sortBy, SortOrderEnum sortOrder, List<Transaction> items)
        {
            PageSize = pageSize;
            Page = page;
            TotalCount = totalCount;
            SortBy = sortBy;
            SortOrder = sortOrder;
            Items = items;
        }
    }
}
