namespace BlazorAppNotesTests.UnitTests
{
    public class NoteRepositoryTests
    {
        Mock<INoteRepository> mockRepository;
        public NoteRepositoryTests()
        {
            mockRepository = new Mock<INoteRepository>();
        }

        [Fact]
        public async Task GetNoteByIdAsync_Returns_Note_When_Found()
        {
            // Arrange
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(new Note { Id = 1, Title = "Note 1", Content = "Perfect note" });

            // Act
            var note = await mockRepository.Object.GetByIdAsync(1);

            // Assert
            Assert.NotNull(note);
            Assert.Equal(1, note.Id);
            Assert.Equal("Note 1", note.Title);
            Assert.Equal("Perfect note", note.Content);
        }

        [Fact]
        public async Task GetNoteByIdAsync_Returns_Null_When_Not_Found()
        {
            // Arrange
            mockRepository.Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync((Note)null);

            // Act
            var note = await mockRepository.Object.GetByIdAsync(1);

            // Assert
            Assert.Null(note);
        }

        [Fact]
        public async Task GetNoteByIdAsync_Throws_Exception_On_Repository_Failure()
        {
            // Arrange
            mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Repository error occurred."));

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(async () => await mockRepository.Object.GetByIdAsync(1));
        }

        [Fact]
        public async Task GetAllNotesAsync_Returns_Empty_List_When_No_Notes()
        {
            // Arrange
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Note>()); 

            // Act
            var notes = await mockRepository.Object.GetAllAsync();

            // Assert
            Assert.Empty(notes);
        }

        [Fact]
        public async Task GetAllNotesAsync_Returns_Multiple_Notes()
        {
            // Arrange
            var notesList = new List<Note>
            {
            new Note { Id = 1, Title = "Note 1", Content = "Perfect note 1" },
            new Note { Id = 2, Title = "Note 2", Content = "Perfect note 1"},
            new Note { Id = 3, Title = "Note 3", Content = "Perfect note 1" }
            };
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(notesList); 

            // Act
            var notes = await mockRepository.Object.GetAllAsync();

            // Assert
            Assert.Equal(3, notes.Count());
        }

        [Fact]
        public async Task AddNoteAsync_Adds_Note_To_Repository()
        {
            // Arrange
            var noteToAdd = new Note { Id = 4, Title = "Note 4", Content = "Perfect note 4" };

            Note capturedNote = null;
            mockRepository.Setup(repo => repo.CreateAsync(It.IsAny<Note>()))
                .Callback<Note>(note =>
                {
                    capturedNote = note;
                })
                .Returns(Task.CompletedTask);

            // Act
            await mockRepository.Object.CreateAsync(noteToAdd);

            // Assert
            Assert.NotNull(capturedNote);
            Assert.Equal(noteToAdd.Id, capturedNote.Id);
            Assert.Equal(noteToAdd.Title, capturedNote.Title);
            Assert.Equal(noteToAdd.Content, capturedNote.Content);
        }

        [Fact]
        public async Task UpdateNoteAsync_Should_Update_Note_In_Mock_Context()
        {
            // Arrange
            var repository = mockRepository.Object;

            var updatedNote = new Note { Id = 1, Title = "Updated Note", Content = "Perfect updated note" };

            mockRepository.Setup(repo => repo.UpdateAsync(updatedNote)).Returns(Task.CompletedTask);

            // Act
            await repository.UpdateAsync(updatedNote);

            // Assert
            mockRepository.Verify(repo => repo.UpdateAsync(updatedNote), Times.Once);
        }
    }
}
