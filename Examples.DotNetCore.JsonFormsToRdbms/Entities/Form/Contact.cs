using Examples.DotNetCore.JsonFormsToRdbms.Entities.Base;

namespace Examples.DotNetCore.JsonFormsToRdbms.Entities.Form
{
    public class Contact : BaseEntity
    {
        public int Id { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? dateofbirth { get; set; }
        public string? country { get; set; }
        public string? address1_line1 { get; set; }
        public string? address1_line2 { get; set; }
        public string? address1_city { get; set; }
        public string? address1_stateorprovince { get; set; }
        public string? address1_postalcode { get; set; }
        public string? new_gender { get; set; }
    }
}
