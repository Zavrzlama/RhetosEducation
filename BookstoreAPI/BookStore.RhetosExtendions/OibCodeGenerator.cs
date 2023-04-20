using Rhetos.Compiler;
using Rhetos.Dom.DefaultConcepts;
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
            string oib = {0};
            if (oib.Length != 11) throw new Exception(""Neispravan OIB"");

            int number, sum, midRemainder, remainder, mulitplier;
            remainder = 10;

            for (int charIndex = 0; charIndex < oib.Length - 1; charIndex++)
            {
                number = Convert.ToInt32(oib[charIndex].ToString());
                sum = number + remainder;
                midRemainder = sum % 10;
                if (midRemainder == 0)
                    midRemainder = 10;
                    mulitplier = midRemainder * 2;
                    remainder = mulitplier % 11;
            }

            int kontrolniBroj = 11 - remainder;

            if (Convert.ToInt32(oib[oib.Length - 1].ToString()) != kontrolniBroj)
                throw new Rhetos.UserException(""Neispravan OIB!\"");
            ", conceptInfo);

            codeBuilder.InsertCode(code, WritableOrmDataStructureCodeGenerator.InitializationTag, info.DataStructure);


        }
    }
}
