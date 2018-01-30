using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities = JorgeMencoMedellinTimesBackend.Entities;
namespace JorgeMencoMedellinTimesBackend.BussinesLogic
{
   public class NewsBussinesLogic
    {
        public  void saveNews(entities.News news)
        {
            using (var db = new MedellinTimesContext() )
            {
                news.Id = Guid.NewGuid();
                news.DatePublish = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
            }
        }
        public async Task<List<entities.News>> getAllNews()
        {
            using (var  db = new MedellinTimesContext())
            {
                try
                {
                    return  await db.News.ToListAsync();     
                }
                catch(Exception e)
                {
                    return null;
                }
            }
        }

        public async void updateNewa( entities.News news)
        {
            using (var db = new MedellinTimesContext())
            {

                db.Entry(news).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
                
        }

        public async Task<entities.News> deleteNews(Guid id)
        {
            var isdelete=false;
            using (var db = new MedellinTimesContext())
            {
                try
                {
                    var deleteNews = await getNewsgById(id);
                    db.Entry(deleteNews).State = EntityState.Deleted;
                    await db.SaveChangesAsync();
                    return deleteNews;
                }
                catch 
                {
                    return null;
                }
            }
        }
        public async Task<entities.News> getNewsgById(Guid id)
        {
            using (var db = new MedellinTimesContext())
            {
                return await db.News.FirstAsync(n => n.Id == id);
            }
        }
    }
}
