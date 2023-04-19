using Rhetos.Compiler;
using Rhetos.Dsl;
using Rhetos.Extensibility;
using System.ComponentModel.Composition;

namespace BookStore.RhetosExtendions
{
    [Export(typeof(IConceptCodeGenerator))]
    [ExportMetadata(MefProvider.Implements, typeof(Oib))]
    public class OibCodeGenerator : IConceptCodeGenerator
    {
        public void GenerateCode(IConceptInfo conceptInfo, ICodeBuilder codeBuilder)
        {
            var info = (Oib)conceptInfo;

            var code = string.Format(
            @"
            string oib = {0}
            int sum = 0;
            for (int i = 0; i < 10; i++) 
            {
                sum += int.Parse(oib[i].ToString()) * (i + 1);
            }
            int controlNumber = sum % 11;
            if (controlNumber == 10) {
            controlNumber = 0;
            }

            int givenControlNumber = int.Parse(oib[10].ToString());
            
            ");

            //codeBuilder.InsertCode(code)
        }
    }
}
