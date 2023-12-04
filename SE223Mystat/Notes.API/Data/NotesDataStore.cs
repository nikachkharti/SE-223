using Notes.API.Models;

namespace Notes.API.Data
{
    public static class NotesDataStore
    {
        public static List<Note> Notes { get; set; } = new()
        {
            new Note { Id = 1, Title = "Note 1",Description = "Note 1 description",Author = "Nika Chkhartishvili"},
            new Note { Id = 2, Title = "Note 2",Description = "Note 2 description",Author = "Luka Odishelidze"},
            new Note { Id = 3, Title = "Note 3",Description = "Note 3 description",Author = "Ana Khucishvili"},
            new Note { Id = 4, Title = "Note 4",Description = "Note 4 description",Author = "Shota Tevdorasvhili"},
            new Note { Id = 5, Title = "Note 5",Description = "Note 5 description",Author = "Giorgi Mamaiashvili"}
        };
    }
}
