using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Baker 
    {
        //id is special
        public int id {get;set;}

        [Required]
        public string name {get;set;}

        public int yearsOfService {get;set;}
    }
}
