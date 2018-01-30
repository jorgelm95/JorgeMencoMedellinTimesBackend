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
using System.Web.Helpers;

namespace JorgeMencoMedellinTimesBackend.API.Controllers
{
    public class NewsController : ApiController
    {
        private NewsBussinesLogic newsBL = new NewsBussinesLogic();

        // GET: api/News
        public async Task<List<News>> GetNews()
        {
            return await newsBL.getAllNews();
        }

        // GET: api/News/5
        [ResponseType(typeof(News))]
        public async Task<IHttpActionResult> GetNews(String id)
        {
            var news = await newsBL.getNewsgById(Guid.Parse(id));  
            if (news == null)
            {
                return NotFound();
            }

            return Ok(news);
        }

        // PUT: api/News/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNews(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                newsBL.updateNewa(news);
                return Ok("Actualizado");
            }
        }

        // POST: api/News
        [ResponseType(typeof(News))]
        public IHttpActionResult PostNews(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                newsBL.saveNews(news);
                return Ok(news);
            }

        }

        // DELETE: api/News/5
        [ResponseType(typeof(News))]
        public async Task<IHttpActionResult> DeleteNews(String id)
        {
            var deleteNews = await newsBL.deleteNews(Guid.Parse(id));
            if (deleteNews != null)
            {
                return Ok(deleteNews);
            }
            else
            {
                return Ok("no se encontro el elemento");
            }
        }        
    }

}