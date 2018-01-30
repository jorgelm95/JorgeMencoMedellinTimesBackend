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
    public class AdvertisingsController : ApiController
    {
        //private MedellinTimesContext db = new MedellinTimesContext();
        private AdvertisingBussinesLogic AdvertisingBL = new AdvertisingBussinesLogic();

        // GET: api/Advertisings
        public async Task<List<Advertising>> GetAdvertising()
        {
            
            return await AdvertisingBL.getAllAdvertising();
        }

        // GET: api/Advertisings/5
        [ResponseType(typeof(Advertising))]
        public async Task<IHttpActionResult> GetAdvertising(String id)
        {
            Advertising advertising =  AdvertisingBL.getAdvertisingById(Guid.Parse(id));
            if (advertising == null)
            {
                return NotFound();
            }
            return Ok(advertising);
        }

        // PUT: api/Advertisings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdvertising(Advertising advertising)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await AdvertisingBL.updateAdvertising(advertising);
                return Ok("Actualizado");
            }

        }

        // POST: api/Advertisings
        [EnableCors(origins:"*",headers: "AllowAllHeaders", methods:"*")]
        [ResponseType(typeof(Advertising))]
        public  IHttpActionResult PostAdvertising(Advertising advertising)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                advertising.Id = Guid.NewGuid();
                advertising.DateCreation = DateTime.Now;
               AdvertisingBL.saveAdvertising(advertising);
            }

            return Ok(advertising);
        }

        // DELETE: api/Advertisings/5
        [ResponseType(typeof(Advertising))]
        public IHttpActionResult DeleteAdvertising(String id)
        {
            var resultDelete =  AdvertisingBL.deleteAdvertising(Guid.Parse(id));
            if (resultDelete!= null)
            {
                return Ok(resultDelete);
            }
            else
            {
                return Ok("no se encontro el eelemento");
            }
        }
        /*
                protected override void Dispose(bool disposing)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                    base.Dispose(disposing);
                }

                private bool AdvertisingExists(Guid id)
                {
                    return db.Advertising.Count(e => e.Id == id) > 0;
                }
            }
            */
    }
}