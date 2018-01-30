using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entities = JorgeMencoMedellinTimesBackend.Entities;
using api = JorgeMencoMedellinTimesBackend.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Results;

namespace JorgeMencoMedellinTimesBackend.API.Tests
{
    [TestClass]
    public  class NewsControllerUnitTest
    {
        [TestMethod]
        public async Task getNews_ShouldNotFindNews()
        {
            var testNews = getTestNews();
            var controller = new api.Controllers.NewsController();
            var response = await controller.GetNews() as List<entities.News>;
            Assert.AreEqual(testNews.Count , response.Count);

        }

        public List<entities.News> getTestNews()
        {
            var testNews = new List<entities.News>();
            testNews.Add(new entities.News {Id=Guid.NewGuid(), Title="noticia1", Subtitle="sun noticia", Description="des noticia1", DatePublish=DateTime.Now });
            testNews.Add(new entities.News { Id = Guid.NewGuid(), Title = "noticia2", Subtitle = "sun noticia", Description = "des noticia2", DatePublish = DateTime.Now });
            testNews.Add(new entities.News { Id = Guid.NewGuid(), Title = "noticia3", Subtitle = "sun noticia", Description = "des noticia3", DatePublish = DateTime.Now });
            return testNews;
        }

        [TestMethod]
        public void AddNewsTest()
        {
            // Arrange  
            var controller = new api.Controllers.NewsController();
            entities.News noticia = new entities.News
            {
                Id = Guid.NewGuid(),
                Title = "noticia 1",
                Subtitle="sub title 1",
                Description = "descrip",
                DatePublish = DateTime.Now,   
            };
            
            IHttpActionResult actionResult = controller.PostNews(noticia);
            var createdResult = actionResult as OkNegotiatedContentResult<entities.News>;
             
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(noticia.Id, createdResult.Content.Id);
        }


    }
}
