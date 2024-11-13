using Microsoft.AspNetCore.Http;

namespace WebApi.Models
{
    public class FormDataModel
    {
        public IFormFile File { get; set; }
    }
}