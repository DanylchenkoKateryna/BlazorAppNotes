
namespace BlazorAppNotesTests.IntegrationTests
{
    public class IntegrationTests : TestContext
    {
        [Fact]
        public async void SearchInput_Should_Update_Notes_On_Input()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<RepositoryContext>()
            .UseNpgsql(connectionString: "Host=localhost; Port=5432; Database=Notes; Username=postgres; Password=5432")
            .Options;

            using var ctx = new TestContext();
            using (var context = new RepositoryContext(options))
            {
                var repository = new NoteRepository(context);
                ctx.Services.AddScoped<INoteRepository, NoteRepository>(_ => repository);
                var component = ctx.RenderComponent<Notes>();

                // Act - Simulate user input
                var searchInput = component.Find("input[placeholder='Enter search term']");
                searchInput.Input("Hi");

                // Assert - Verify notes are updated
                var notes = component.FindAll(".container.shadow.bg-light.my-4");
                Assert.NotEmpty(notes); // Verify that notes are displayed
            }
        }
    }
}