using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Core.Contents.Extensions;
using System;

namespace Orchard.PusdKop
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("CustomerPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("FirstName", c => c.WithLength(50))
                .Column<string>("LastName", c => c.WithLength(50))
                .Column<string>("Title", c => c.WithLength(10))
                .Column<DateTime>("CreatedUtc")
                );

            SchemaBuilder.CreateTable("QuestionnairePartRecord", table => table
                .ContentPartRecord()
                .Column<int>("CustomerId")
                .Column<string>("Type", c => c.WithLength(50))
                );

            return 1;
        }
        

        public int UpdateFrom1()
        {
            

            ContentDefinitionManager.AlterPartDefinition("CustomerPart", part => part
                .Attachable(false)
                );

            ContentDefinitionManager.AlterTypeDefinition("Customer", type => type
                .WithPart("CustomerPart")
                .WithPart("UserPart")
                );

            ContentDefinitionManager.AlterPartDefinition("QuestionnairePart", part => part
                .Attachable(false)
                //.WithField("Name", f => f.OfType("TextField"))
                //.WithField("AddressLine1", f => f.OfType("TextField"))
                //.WithField("AddressLine2", f => f.OfType("TextField"))
                //.WithField("Zipcode", f => f.OfType("TextField"))
                //.WithField("City", f => f.OfType("TextField"))
                //.WithField("Country", f => f.OfType("TextField"))
                //.Column<string>("Name")
                //.Column<string>("Surname")
                //.Column<string>("Interests")
                //.Column<string>("Kitchen")
                //.Column<string>("City")
                .WithField("Name", f => f.OfType("TextField"))
                .WithField("Surname", f => f.OfType("TextField"))
                .WithField("Interests", f => f.OfType("TextField"))
                .WithField("Kitchen", f => f.OfType("TextField"))//change to dropdown
                .WithField("City", f => f.OfType("TextField"))
                );

            ContentDefinitionManager.AlterTypeDefinition("Questionnaire", type => type
                .WithPart("CommonPart")
                .WithPart("QuestionnairePart")
                );

            return 2;
        }

    }
}