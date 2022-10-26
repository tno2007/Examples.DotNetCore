namespace Examples.DotNetCore.JsonFormsToRdbms.Entities.Form
{
    using Examples.DotNetCore.JsonFormsToRdbms.Entities.Base;

    public class Question : BaseEntity
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Label { get; set; }
        public string? Validation { get; set; }
        public string? Help{ get; set; }
        public bool Required { get; set; }
        public virtual Questionnaire? Questionnaire { get; set; }
    }
}

