using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.ComponentModel.Composition;

namespace BookStore.RhetosExtendions
{

    [Export(typeof(IConceptMacro))]

    public class EmailMacro : IConceptMacro<Email>
    {
        public IEnumerable<IConceptInfo> CreateNewConcepts(Email conceptInfo, IDslModel existingConcepts)
        {
            var newConcepts = new List<IConceptInfo>();

            if (conceptInfo.DataStructure is IWritableOrmDataStructure)
                newConcepts.Add(new RegExMatchInfo
                {
                    Property = conceptInfo,
                    RegularExpression = @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    ErrorMessage = "Invalid email format."
                });

            return newConcepts;
        }
    }
}
