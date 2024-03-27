using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DotnetBakery.Models
{
    public class Bread 
    {
        public int id {get;set;}

        [Required]
        public string name {get;set;}

        public int count {get;set;}

// This is the Id of the baker who made this bread
// In a moment, we'll see how .NET can use this field to 
// join our tables together for us
        [ForeignKey("bakedBy")]
        public int bakerId {get;set;}

// While bakedById is an integer with the baker's ID,
// this field is an actual Baker object. 
// This will allow us to nest the baker object
// inside our bread response from `GET /breads`
        public Baker bakedBy {get;set;}
    }
}
