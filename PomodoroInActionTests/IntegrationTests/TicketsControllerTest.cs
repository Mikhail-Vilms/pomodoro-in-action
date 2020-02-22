using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PomodoroInAction.Models;
using System.Net;
using System.Net.Http;
using System.Text;

namespace PomodoroInActionTests.IntegrationTests
{
    [TestClass]
    public class TicketsControllerTest : IntegrationTest
    {
        [TestMethod]
        public void Post_ReturnsCreatedCode()
        {
            string _boardRequestUri = "http://localhost/api/boards";
            Board board = new Board()
            {
                Id = 2001,
                DisplayName = "Board Display Name 2001",
                SortOrder = 1,
                Description = "Board Description 2001"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(board), Encoding.UTF8, "application/json");
            HttpResponseMessage response = TestClient.PostAsync(_boardRequestUri, content).Result;

            string _containersRequestUri = "http://localhost/api/containers";
            KanbanContainer container = new KanbanContainer()
            {
                Id = 2001,
                DisplayName = "Kanban Container Display Name 2001",
                SortOrder = 1,
                Description = "Kanban Container Description 2001",
                BoardId = 2001
            };

            content = new StringContent(JsonConvert.SerializeObject(container), Encoding.UTF8, "application/json");
            response = TestClient.PostAsync(_containersRequestUri, content).Result;

            // Arrange
            string _requestUri = "http://localhost/api/tickets";
            Ticket ticket = new Ticket()
            {
                Id = 1001,
                DisplayName = "Ticket Display Name 1",
                SortOrder = 1,
                Description = "Ticket Description 1",
                KanbanContainerId = 2001
            };

            // Act
            content = new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/json");
            response = TestClient.PostAsync(_requestUri, content).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Get_ReturnsOneRecord()
        {
            // Arrange
            string _requestUri = "http://localhost/api/tickets/2001";

            // Act
            HttpResponseMessage response = TestClient.GetAsync(_requestUri).Result;
            JObject responseJson = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1001, responseJson["id"]);
        }

        [TestMethod]
        public void Get_ReturnsAllRecord()
        {
            // Arrange
            string _requestUri = "http://localhost/api/tickets";

            // Act
            HttpResponseMessage response = TestClient.GetAsync(_requestUri).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Put_UpdatesRecord_Returns200()
        {
            // Arrange
            string _requestUri = "http://localhost/api/tickets/1001";
            Ticket ticket = new Ticket()
            {
                Id = 1001,
                DisplayName = "Ticket Display Name 2001 UPDATED",
                SortOrder = 2,
                Description = "Ticket Description 2001 UPDATED",
                KanbanContainerId = 2001
            };

            // Act
            StringContent content = new StringContent(JsonConvert.SerializeObject(ticket), Encoding.UTF8, "application/json");
            HttpResponseMessage response = TestClient.PutAsync(_requestUri, content).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
