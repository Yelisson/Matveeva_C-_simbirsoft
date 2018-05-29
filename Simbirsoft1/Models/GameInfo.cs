using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft1.Models
{
    public class GameInfo
    {
        public int Id { get; set; }
        [Required]
        public DateTime GameDate { get; set; }

        [Required]
        public string Winner { get; set; }
    }
}
