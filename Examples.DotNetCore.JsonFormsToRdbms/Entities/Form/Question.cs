namespace Examples.DotNetCore.JsonFormsToRdbms.Entities.Form
{
    using Examples.DotNetCore.JsonFormsToRdbms.Entities.Base;

    public class Question : BaseEntity
    {
        public int Id { get; set; }
        public string? FieldType { get; set; }
        public bool? IsOptionSet { get; set; }
        public string? Name { get; set; }
        public string? Label { get; set; }
        public string? Validation { get; set; }
        public string? Help{ get; set; }
        public bool Required { get; set; }
        public virtual Questionnaire? Questionnaire { get; set; }
        public string? MappedEntity { get; set; }
        public string? MappedAttribute { get; set; }
        public string? Answer{ get; set; }
        public Question? Parent { get; set; }
    }
}

