using Rhetos.Dsl;
using Rhetos.Dsl.DefaultConcepts;
using System.ComponentModel.Composition;

namespace BookStore.RhetosExtendions
{
    [Export(typeof(IConceptInfo))]
    [ConceptKeyword("PhoneNumberInfo")]
    public class PhoneNumberInfo : ShortStringPropertyInfo
    {
    }
}
