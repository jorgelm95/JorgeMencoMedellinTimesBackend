using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JorgeMencoMedellinTimesBackend.Entities
{
    public class Advertising
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]
        public String Title { get; set; }
        [MaxLength(500)]
        public String Descriotion { get; set; }
        [MaxLength(250)]
        public String PathImage { get; set; }
        public DateTime DateCreation { get; set; }


    }
}
