using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exHomeTest_server.Models
{
    
    public class IssPosition
    {
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Latitude { get; set; }
    }

    public class Location
    {
        [Required(ErrorMessage = "Timestamp is Required")]
        public int Timestamp { get; set; }
        [Required]
        public IssPosition Iss_position { get; set; }
        [Required]
        public string Message { get; set; }
        public string Note { get; set; }
    }

}