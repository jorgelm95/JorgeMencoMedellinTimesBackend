using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JorgeMencoMedellinTimesBackend.BussinesLogic;
using JorgeMencoMedellinTimesBackend.Entities;
using System.Web.Http.Cors;

namespace JorgeMencoMedellinTimesBackend.API.Controllers
{
    public class EventsController : ApiController
    {
        //private MedellinTimesContext db = new MedellinTimesContext();

        private EventBussinesLogic eventBL = new EventBussinesLogic();

        // GET: api/Events
        public async Task<List<Event>> GetEvents()
        {
            return await eventBL.getAllEvents();
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(String id)
        {
            Event @event =  eventBL.getEventById(Guid.Parse(id));
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await eventBL.updateEvent(@event);
                return Ok("Actualizado");
            }

        }

        // POST: api/Events
        [EnableCors(origins: "*", headers: "AllowAllHeaders", methods: "*")]
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                @event.Id = Guid.NewGuid();
                eventBL.saveEvent(@event);
                return Ok(@event);
            }
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(String id)
        {
            var eventoDelete = await eventBL.deleteEvent(Guid.Parse(id));
            if (eventoDelete != null)
            {
                return Ok(eventoDelete);
            }
            else
            {
                return Ok("no se encontro el elemento");
            }

        }
    }
}