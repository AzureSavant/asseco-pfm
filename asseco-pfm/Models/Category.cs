using System.ComponentModel.DataAnnotations.Schema;

namespace asseco_pfm.Models
{
    public class Category
    {
        public string Code { get; set; }
        public string? ParentCode { get; set; }
        public string Name { get; set; }
        [ForeignKey("Parent")]
        public string? ParentCategory { get; set; }
        public Category? Parent { get; set; }



        public Category() { }
        public Category(string code, string? parentCode, string name)
        {
            Code = code;
            ParentCode = parentCode;
            Name = name;
        }

        public Category(string code, string? parentCode, string name, string? parentCategory, Category? parent)
        {
            Code = code;
            ParentCode = parentCode;
            Name = name;
            ParentCategory = parentCategory;
            Parent = parent;
        }
        
    }

}
