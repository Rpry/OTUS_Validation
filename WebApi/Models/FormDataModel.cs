using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models
{
    public class FormDataModel
    {
        public IFormFile File1 { get; set; }
        
        public IFormFile File2 { get; set; }
    }
}