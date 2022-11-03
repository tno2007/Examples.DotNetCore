using Examples.DotNetCore.JsonFormsToRdbms.Entities.Base;

namespace Examples.DotNetCore.JsonFormsToRdbms.Entities.Form
{
    public class FieldType : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
