using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileDisplay.Models
{
    public class UserProfile
    {
        [Key]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ProfileImage { get; set; }
        public string CoverImage { get; set; }
        public string Degree { get; set; }
        public string University { get; set; }
        public string JobPost { get; set; }
        public string Company { get; set; }
        public string Experience { get; set; }
    }
}
