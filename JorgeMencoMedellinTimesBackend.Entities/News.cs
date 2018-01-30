using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JorgeMencoMedellinTimesBackend.Entities
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]
        public String Title { get; set; }
        [MaxLength(250)]
        public String Subtitle { get; set; }
        [MaxLength(500)]
        public String Description { get; set; }
        
        public DateTime DatePublish { get; set; }
    }
}
