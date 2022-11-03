

using Examples.DotNetCore.JsonFormsToRdbms.Contexts;
using Examples.DotNetCore.JsonFormsToRdbms.Entities.Form;

SeedAsync();

static void SeedQuestionnaire(FormContext context)
{
    var questionnaires = new List<Questionnaire>()
    {
        new Questionnaire
        {
            Name = "Client Questionnaire"
        },
        new Questionnaire 
        {
            Name = "Address Capture"
        }
    };

    if (context.Questionnaire == null) return ;

    context.Questionnaire.AddRange(questionnaires);
    
    context.SaveChanges();
}

static void SeedQuestions(FormContext context)
{
    var questionnaires = context.Questionnaire;

    var clientQuestionnaire = questionnaires.First(x => x.Name.Equals("Client Questionnaire"));

    var clientQuestions = new List<Question>() {
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "First name",
                FieldType = "text",
                MappedEntity = "contact",
                MappedAttribute = "firstname",
                Answer = "Joe"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Last name",
                FieldType = "text",
                MappedEntity = "contact",
                MappedAttribute = "lastname",
                Answer = "Bloggs"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Date of birth",
                FieldType = "date",
                MappedEntity = "contact",
                MappedAttribute = "dateofbirth",
                Answer = "1978-12-31T22:00:00.000Z"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Sex",
                FieldType = "radio",
                MappedEntity = "contact",
                IsOptionSet = true,
                MappedAttribute = "new_gender",
                Answer = "1"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Country",
                FieldType = "select",
                IsOptionSet = true,
                MappedEntity = "contact",
                MappedAttribute = "new_country",
                Answer = "5578"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Address line 1",
                FieldType = "string",
                MappedEntity = "contact",
                MappedAttribute = "address1_line1",
                Answer = "224B Clarence street"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Address line 2",
                FieldType = "string",
                MappedEntity = "contact",
                MappedAttribute = "address1_line2",
                Answer = ""
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Post Town/City",
                FieldType = "string",
                MappedEntity = "contact",
                MappedAttribute = "address1_city",
                Answer = "Vogeltown"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "State/Province",
                FieldType = "string",
                MappedEntity = "contact",
                MappedAttribute = "address1_stateorprovince",
                Answer = "Wellington"
            },
            new Question {
                Questionnaire = clientQuestionnaire,
                Label = "Postal code",
                FieldType = "string",
                MappedEntity = "contact",
                MappedAttribute = "address1_postalcode",
                Answer = "6023"
            }
        };

    context.Question.AddRange(clientQuestions);

    var addressCapture = questionnaires.First(x => x.Name.Equals("Address Capture"));

    var dependentsMainQuestion = new Question
    {
        Questionnaire = addressCapture,
        Label = "Please provide all your addresses for the past 5 years",
        FieldType = "repatable",
        MappedEntity = "address", // the entity where we will save the listing/rows
        Answer = "" // wont have an answer, since its jsut a group
    };

    context.Question.Add(dependentsMainQuestion);

    var dependentsMainChildQuestions = new List<Question>()
    {
            new Question {
                Questionnaire = addressCapture,
                Label = "Country",
                FieldType = "select",
                IsOptionSet = true,
                MappedEntity = "",
                MappedAttribute = "country",
                Answer = "5578",
                Parent = dependentsMainQuestion
            },
            new Question {
                Questionnaire = addressCapture,
                Label = "Address line 1",
                FieldType = "string",
                MappedEntity = "",
                MappedAttribute = "addressline1",
                Answer = "",
                Parent = dependentsMainQuestion
            },
            new Question {
                Questionnaire = addressCapture,
                Label = "Address line 2",
                FieldType = "string",
                MappedEntity = "",
                MappedAttribute = "addressline2",
                Answer = "",
                Parent = dependentsMainQuestion
            },
            new Question {
                Questionnaire = addressCapture,
                Label = "Post Town/City",
                FieldType = "string",
                MappedEntity = "",
                MappedAttribute = "city",
                Answer = "",
                Parent = dependentsMainQuestion
            },
            new Question {
                Questionnaire = addressCapture,
                Label = "State/Province",
                FieldType = "string",
                MappedEntity = "",
                MappedAttribute = "stateorprovince",
                Answer = "",
                Parent = dependentsMainQuestion
            },
            new Question {
                Questionnaire = addressCapture,
                Label = "Postal code",
                FieldType = "string",
                MappedEntity = "",
                MappedAttribute = "postalcode",
                Answer = "",
                Parent = dependentsMainQuestion
            }
    };

    context.Question.AddRange(dependentsMainChildQuestions);

    context.SaveChanges();
}

static void SeedContact(FormContext context)
{
    var contact = new Contact()
    {
        firstname = "Joe",
        lastname = "Bloggs",
        dateofbirth = "1978-12-31T22:00:00.000Z",
        country = "5578",
        address1_line1 = "224B Clarence street",
        address1_line2 = "",
        address1_city = "Vogeltown",
        address1_stateorprovince = "Wellington",
        address1_postalcode = "6023",
        new_gender = "1"
    };

    context.Contact.Add(contact);

    context.SaveChanges();
}


static async Task SeedAsync()
{
    using (var context = new FormContext())
    {
        // create db if not exists
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        SeedQuestionnaire(context);

        //if (questionnaire == null) return;

        SeedQuestions(context);

        if (context.Questionnaire == null) return;

        // get client questionnaire
        var questionare = context.Questionnaire.FirstOrDefault(x => x.Name.Equals("Client Questionnaire"));

        
        if (context.Question == null) return;

        // get questions of this questionnaire
        var questions = context.Question.Where(x => x.Questionnaire.Equals(questionare));        
        
        // null check
        if (questions == null) return;

        SeedContact(context);



    }
}



/*
static void PopulateFieldsTypes(string[] args)
{
    // fill types
    var fieldTypes = new List<FieldType>();

    fieldTypes.Add(new FieldType
    {
        Name = "string"
    });
    fieldTypes.Add(new FieldType
    {
        Name = "number"
    });
    if (context.FieldType == null) return;
    context.FieldType.AddRange(fieldTypes);
}
*/