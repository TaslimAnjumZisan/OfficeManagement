using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OfficeManagement.Models
{
    public class RquestProject
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Budget { get; set; }

    }
}