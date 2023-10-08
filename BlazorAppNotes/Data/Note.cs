using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppNotes.Data
{
    public class Note
    {
        [Column("NoteId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is a required field.")]
        public string Content { get; set; }
        public DateTime CreatedDate { get; private set; }
        public Note()
        {
            CreatedDate = DateTime.UtcNow;
        }
    }
}
