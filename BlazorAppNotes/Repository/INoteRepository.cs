using BlazorAppNotes.Data;

namespace BlazorAppNotes.Repository
{
    public interface INoteRepository
    {
        Task<List<Note>> GetAllAsync();
        Task<Note> GetByIdAsync(int id);
        Task CreateAsync(Note entity);
        Task UpdateAsync(Note entity);
        Task DeleteAsync(Note entity);
        string TimeAgo(DateTime dateTime);
        Task<List<Note>> SearchAsync(string searchItem);
    }
}
