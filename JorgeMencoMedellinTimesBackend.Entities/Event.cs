using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JorgeMencoMedellinTimesBackend.Entities
{
    public class Event
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]
        public String Name { get; set; }
        [MaxLength(500)]
        public String Description { get; set; }
        [MaxLength(250)]
        public String Adress { get; set; }

        public DateTime DateEvent { get; set; }

    }
}
