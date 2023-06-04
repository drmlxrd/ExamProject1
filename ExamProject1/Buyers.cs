using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject1
{
    public class Buyers
    {
        [Key]
        public string? NameClients { get; set; }
        public string? DescriptionClients { get; set; }
    }
}
