using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using entities = JorgeMencoMedellinTimesBackend.Entities;
namespace JorgeMencoMedellinTimesBackend.BussinesLogic
{
    public class AdvertisingBussinesLogic
    {
        public  void saveAdvertising(entities.Advertising advertising)
        {
            using (var db = new MedellinTimesContext())
            {
                db.Advertising.Add(advertising);
                 db.SaveChanges();
            }       
        }
        public async Task<List<entities.Advertising>> getAllAdvertising()
        {
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    return await db.Advertising.OrderByDescending(e=> e.DateCreation).ToListAsync();
                }
                catch
                {
                    return null;
                }
            }
        }
        public async Task<Boolean> updateAdvertising(entities.Advertising advertising)
        {
          
            using (var db = new MedellinTimesContext())
            {
                try {
                    /*
                    var updateAdvertising = await db.Advertising.FirstAsync(a => a.Id == advertising.Id);
                    updateAdvertising.Title = advertising.Title;
                    updateAdvertising.Descriotion = advertising.Descriotion;
                    updateAdvertising.PathImage = advertising.PathImage;
                    */
                    db.Entry(advertising).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return  true;
                }
                catch {
                    return false;
                }
            }
        }
        public async Task<entities.Advertising> deleteAdvertising(Guid Id)
        {
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    entities.Advertising deleteAdvertising =  getAdvertisingById(Id);
                    db.Entry(deleteAdvertising).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return deleteAdvertising;
                }
                catch (Exception e)
                {
                   var error= e.Message;
                    return null;   
                }
            }
        }

        public entities.Advertising getAdvertisingById(Guid id)
        {
            using (var db = new MedellinTimesContext())
            {
                return db.Advertising.First(a => a.Id == id);
            }
        }
    }
}
