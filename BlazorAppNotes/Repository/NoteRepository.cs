using BlazorAppNotes.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppNotes.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly RepositoryContext _repositoryContext;
        
        public NoteRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<List<Note>> SearchAsync(string searchItem)
        {
            return await _repositoryContext.Notes.Where(s => s.Title.ToLower().Contains(searchItem.ToLower()) 
                                                          || s.Content.ToLower().Contains(searchItem.ToLower())).ToListAsync();
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await _repositoryContext.Notes.ToListAsync();
        }

        public async Task<Note> GetByIdAsync(int id)
        {
            var note = await _repositoryContext.Notes.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return note;
        }
        public async Task CreateAsync(Note entity)
        {
            _repositoryContext.Notes.Add(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note entity)
        {
             _repositoryContext.Notes.Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note entity)
        {
            _repositoryContext.Notes.Update(entity);
           await _repositoryContext.SaveChangesAsync();
        }

        public string TimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.UtcNow.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("Created {0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("Created {0} minutes ago", timeSpan.Minutes) :
                    "Created a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("Created {0} hours ago", timeSpan.Hours) :
                    "Created an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("Created {0} days ago", timeSpan.Days) :
                    "Created yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("Created {0} months ago", timeSpan.Days / 30) :
                    "Created a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }
    }
}
