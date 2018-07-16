using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SwaggerGenericWebApi.Swagger
{
    public class ApplySummariesOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var controllerActionDescriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;

            if (!string.IsNullOrWhiteSpace(operation.Summary) || controllerActionDescriptor == null)
            {
                return;
            }

            var actionName = controllerActionDescriptor.ActionName;
            var resourceName = controllerActionDescriptor.ControllerName.TrimEnd('s').ToSentenceCase();
            var baseType = controllerActionDescriptor.ControllerTypeInfo.BaseType?.GetTypeInfo();

            switch (actionName)
            {
                case "GetAll":
                    operation.Summary = $"Returns all {resourceName}s";
                    break;
                case "GetById":
                    operation.Summary = $"Retrieves a {resourceName} by int id";
                    break;
                case "Post":
                    operation.Summary = $"Creates a {resourceName}";
                    operation.Parameters[0].Description = $"a {resourceName} representation";
                    break;
                case "Put":
                    operation.Summary = $"Updates a {resourceName} with int id in it";
                    operation.Parameters[0].Description = $"a {resourceName} representation";
                    break;
                case "Delete":
                    operation.Summary = $"Deletes a {resourceName} by int id";
                    operation.Parameters[0].Description = $"a unique id for the {resourceName}";
                    break;
            }
        }
    }

    public static class StringExtension
    {
        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]} {m.Value[1]}");
        }
    }
}
