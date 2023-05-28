using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsDB.Models
{
     class Parts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string NamberPart { get; set; }
        public string? ImgPath { get; set; }
        public string? ShortInfo { get; set; }
        public int idCategory { get; set; }
    }
}
