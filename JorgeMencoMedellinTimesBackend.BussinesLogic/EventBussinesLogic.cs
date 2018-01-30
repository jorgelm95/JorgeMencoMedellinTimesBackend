using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using entities = JorgeMencoMedellinTimesBackend.Entities;
namespace JorgeMencoMedellinTimesBackend.BussinesLogic
{
    public class EventBussinesLogic
    {
        public  void saveEvent(entities.Event evento)
        {
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    db.Event.Add(evento);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    var error = e.Message;
                }
               
            }
        }

        public async Task<List<entities.Event>> getAllEvents()
        {
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    return await db.Event.ToListAsync();
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }

        public async Task<bool> updateEvent(entities.Event evento)
        {
            var isupdtae = false;
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    /*  var updateEvent = await db.Event.FirstAsync(e => e.Id == evento.Id);
                      updateEvent.Name = evento.Name;
                      updateEvent.Description = evento.Description;
                      updateEvent.Adress = evento.Adress;
                      */
                    db.Entry(evento).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return isupdtae = true;
                }
                catch (Exception e)
                {
                    return isupdtae = false;
                }
            }
        }

        public async Task<entities.Event> deleteEvent(Guid Id)
        {
            var isDelete = false;
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    var deleteEvent =  getEventById(Id);
                    db.Entry(deleteEvent).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return deleteEvent;
                }
                catch
                {
                    return null;
                }
            }
        }

        public entities.Event getEventById(Guid id)
        {
            using (var db = new MedellinTimesContext())
            {
                return  db.Event.First(e => e.Id == id);
            }
        }
    }
}
