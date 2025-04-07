using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonTrackingSystem.DataAccess.Models
{
    public class LessonSearchInput
    {

        public string Name { get; set; } = string.Empty;

        
        public string? Code { get; set; }

        public int Akts { get; set; }
    }
}
