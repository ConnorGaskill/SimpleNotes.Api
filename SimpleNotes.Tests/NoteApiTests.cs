using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SimpleNotes.Api.Models;
using System.Text;
using System.Text.Json;

namespace SimpleNotes.Tests
{
    public class NoteApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public NoteApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Can_Create_And_Get_Note()
        {
            var noteJson = new StringContent(
                JsonSerializer.Serialize(new { Content = "Integration Test Note" }),
                Encoding.UTF8, "application/json");

            var CreateResponse = await _client.PostAsync("/api/note", noteJson);
            CreateResponse.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/api/note");
            getResponse.EnsureSuccessStatusCode();

            var json = await getResponse.Content.ReadAsStringAsync();
            var notes = JsonSerializer.Deserialize<List<Note>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotNull(notes);
            Assert.Contains(notes, n => n.Content == "Integration Test Note");

        }
    }
}
