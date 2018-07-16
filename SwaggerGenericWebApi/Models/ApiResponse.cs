using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerGenericWebApi.Models
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {

        }
        public ApiResponse(T result, int statusCode, string friendlyMessage = "", long? size = null, string version = "1.0")
        {
            this.Result = result;
            this.StatusCode = statusCode;
            this.FriendlyMessage = friendlyMessage;
            this.Size = size;
            this.Version = version;
        }

        public string Version { get; set; } = "1.0";
        public int StatusCode { get; set; }
        public string FriendlyMessage { get; set; }
        public T Result { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public long? Size { get; set; }
    }
}
