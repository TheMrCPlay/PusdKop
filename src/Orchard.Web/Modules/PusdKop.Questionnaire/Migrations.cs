using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using Orchard.Core.Contents.Extensions;

namespace PusdKop.Questionnaire
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("UserQuestionnaireRecord",
                table => table
                    .ContentPartRecord()
                    .Column<string>("Name")
                    .Column<string>("Surname")
                    .Column<string>("Interests")
                    .Column<string>("Kitchen")
                    .Column<string>("City")
                    
                );

            return 1;
        }

        //public int UpdateFrom1()
        //{
        //    ContentDefinitionManager.AlterTypeDefinition("User", cfg => cfg.Creatable(false));

        //    return 2;
        //}

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition("Questionnaire", cfg => cfg.Creatable(false));

            return 2;
        }
    }
}