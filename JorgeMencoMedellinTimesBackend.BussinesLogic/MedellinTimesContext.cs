using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using entities = JorgeMencoMedellinTimesBackend.Entities;

namespace JorgeMencoMedellinTimesBackend.BussinesLogic
{
    public class MedellinTimesContext: DbContext
    {
        public MedellinTimesContext() : base("MedellinTimesConexion"){
        }

        public virtual DbSet<entities.News> News { get; set; }
        public virtual DbSet<entities.Event> Event { get; set; }

        public virtual DbSet<entities.Advertising> Advertising { get; set; }
        public virtual DbSet<entities.Admin> Admins { get; set; }

    }
}
