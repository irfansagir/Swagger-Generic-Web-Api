using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using SwaggerGenericWebApi.Models.Dtos;
using SwaggerGenericWebApi.Models;

namespace SwaggerGenericWebApi.Swagger
{
    public class GenericOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var baseType = controllerDescriptor.ControllerTypeInfo.BaseType?.GetTypeInfo();

                if ((baseType == null || !baseType.IsGenericType) && context.ApiDescription.HttpMethod != "GET")
                    return;

                var response = operation.Responses["200"] ?? new Response { Description = "Success" };

                if (response.Schema == null)
                {

                    var typeParam = baseType.GenericTypeArguments[1]; // Dto'yu bulduk.

                    var apiResponseType = typeof(ApiResponse<>);

                    if (controllerDescriptor.ActionName == "GetAll")
                    {
                        var listType = typeof(List<>);
                        listType = listType.MakeGenericType(typeParam);
                        typeParam = apiResponseType.MakeGenericType(listType);
                    }
                    else //GetById methoduysa
                    {
                        typeParam = apiResponseType.MakeGenericType(typeParam);
                    }

                    string typeParamFriendlyId = typeParam.FriendlyId();

                    if (!context.SchemaRegistry.Definitions.TryGetValue(typeParamFriendlyId, out Schema typeParamSchema))
                    {
                        typeParamSchema = context.SchemaRegistry.GetOrRegister(typeParam);
                    }

                    response.Schema = new Schema { Ref = $"#/definitions/{typeParamFriendlyId}" };
                }
            }
        }
    }
}
