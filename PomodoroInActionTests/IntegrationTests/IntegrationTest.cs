using Microsoft.AspNetCore.Mvc.Testing;
using PomodoroInAction;
using System.Net.Http;

namespace PomodoroInActionTests.IntegrationTests
{
    // "WebApplicationFactory" - class from "Microsoft.AspNetCore.Mvc.Testing" package
    // #TODO: google about it
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;

        public IntegrationTest()
        {   
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
        }
    }
}
