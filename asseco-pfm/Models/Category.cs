namespace asseco_pfm.Models
{
    public class Category
    {
        public string Code { get; set; }
        public string? ParentCode { get; set; }
        public string Name { get; set; }

        public Category(string code, string? parentCode, string name)
        {
            Code = code;
            ParentCode = parentCode;
            Name = name;
        }
    }

}
