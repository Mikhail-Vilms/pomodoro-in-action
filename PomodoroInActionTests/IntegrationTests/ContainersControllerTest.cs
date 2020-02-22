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
    public class ContainersControllerTest : IntegrationTest
    {
        [TestMethod]
        public void Post_ReturnsCreatedCode()
        {
            string _boardRequestUri = "http://localhost/api/boards";

            Board board = new Board()
            {
                Id = 1001,
                DisplayName = "Board Display Name 1001",
                SortOrder = 1,
                Description = "Board Description 1001"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(board), Encoding.UTF8, "application/json");
            HttpResponseMessage response = TestClient.PostAsync(_boardRequestUri, content).Result;

            // Arrange
            string _requestUri = "http://localhost/api/containers";
            KanbanContainer container = new KanbanContainer()
            {
                Id = 1001,
                DisplayName = "Kanban Container Display Name 1",
                SortOrder = 1,
                Description = "Kanban Container Description 1",
                BoardId = 1001
            };

            // Act
            content = new StringContent(JsonConvert.SerializeObject(container), Encoding.UTF8, "application/json");
            response = TestClient.PostAsync(_requestUri, content).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void Get_ReturnsOneRecord()
        {
            // Arrange
            string _requestUri = "http://localhost/api/containers/1001";

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
            string _requestUri = "http://localhost/api/containers";

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
            string _requestUri = "http://localhost/api/containers/1001";
            KanbanContainer container = new KanbanContainer()
            {
                Id = 1001,
                DisplayName = "Kanban Container Display Name 1 UPDATED",
                SortOrder = 2,
                Description = "Kanban Container Description 1 UPDATED",
                BoardId = 1001
            };

            // Act
            StringContent content = new StringContent(JsonConvert.SerializeObject(container), Encoding.UTF8, "application/json");
            HttpResponseMessage response = TestClient.PutAsync(_requestUri, content).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Delete_DeletesRecord_Returns200()
        {
            // Arrange
            string _requestUri = "http://localhost/api/containers/1001";

            // Act
            HttpResponseMessage response = TestClient.DeleteAsync(_requestUri).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
