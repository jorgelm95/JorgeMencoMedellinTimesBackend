using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using api = JorgeMencoMedellinTimesBackend.API.Controllers;
using entities = JorgeMencoMedellinTimesBackend.Entities;
using System.Web.Http;

namespace JorgeMencoMedellinTimesBackend.API.Tests.Controllers
{
    [TestClass]
    public class EventsControllerUniTest
    {

        [TestMethod]
        public void getEventById(Guid id)
        {
            var eventtest = new entities.Event();
            eventtest.Id = Guid.Parse("D6E90323-51B0-45C9-ACA4-DE755F44642B");
            // Set up Prerequisites   
            var controller = new api.EventsController();
            // Act on Test  
            var response = controller.GetEvent("D6E90323-51B0-45C9-ACA4-DE755F44642B");
            var contentResult = response as OkNegotiatedContentResult<entities.Event>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(eventtest.Id, contentResult.Content.Id);
        }

        [TestMethod]
          public void getEventNotFound()
          {
              // Set up Prerequisites   
              var controller = new api.EventsController();
              // Act  
              IHttpActionResult actionResult =  controller.GetEvent("32E59E11-9D54-48B5-B481-73D6DA8E2A5F");
              // Assert  
              Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
          }

        [TestMethod]
        public void AddEvent()
        {
            // Arrange  
            var controller = new  api.EventsController();
            entities.Event evento = new entities.Event { Id = Guid.NewGuid(),
                Name ="evento1",Description="descrip", Adress="sfsff",DateEvent=DateTime.Now };
            // Act  
            IHttpActionResult actionResult = controller.PostEvent(evento);
            var createdResult = actionResult as OkNegotiatedContentResult<entities.Event>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(evento.Id, createdResult.Content.Id);
        }

        public void AddEvent_shouldNotSave()
        {
            // Arrange  
            var controller = new api.EventsController();
            entities.Event evento = new entities.Event
            {

                Name = "evento1",
                Description = "descrip",
                Adress = "sfsff",
               
            };
            // Act  
            IHttpActionResult actionResult = controller.PostEvent(evento);
            var createdResult = actionResult as OkNegotiatedContentResult<InvalidModelStateResult>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.IsInstanceOfType(createdResult.Content, typeof(InvalidModelStateResult));
        }
    }
}
