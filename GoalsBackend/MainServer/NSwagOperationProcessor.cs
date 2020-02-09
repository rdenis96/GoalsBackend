using NSwag;
using NSwag.SwaggerGeneration.Processors;
using NSwag.SwaggerGeneration.Processors.Contexts;
using System.Threading.Tasks;

namespace MainServer
{
    public class NSwagOperationProcessor : IOperationProcessor
    {
        public async Task<bool> ProcessAsync(OperationProcessorContext context)
        {
            context.OperationDescription.Operation.Parameters.Add(new SwaggerParameter
            {
                Name = "licenseinfo",
                Kind = SwaggerParameterKind.Header,
                Type = NJsonSchema.JsonObjectType.String,
                IsRequired = false
            });
            return true; // return false to exclude the operation from the document
        }
    }
}