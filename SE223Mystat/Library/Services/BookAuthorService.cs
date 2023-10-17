﻿using Library.Models;
using Library.Repository;
using Library.Repository.Interfaces;
using Library.Services.Interfaces;
using System.Drawing.Text;

namespace Library.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookAuthorService(IBookAuthorRepository bookAuthorRepository, IAuthorRepository authorRepository)
        {
            _bookAuthorRepository = bookAuthorRepository;
            _authorRepository = authorRepository;
        }

        public List<Author> GetAllBooksWithAuthors(int bookId)
        {
            var result = _bookAuthorRepository
                .GetAll(filter: x => x.BookId == bookId, includeProperties: "Author")
                .Select(x => x.Author)
                .ToList();

            return result;
        }

        public void UpdateAuthorsOfTheBook(int bookId, List<string> authorIdsAsText)
        {
            foreach (var item in authorIdsAsText)
            {
                int.TryParse(item, out int authorId);

                var author = _authorRepository.Get(x => x.Id == authorId);

                if (author != null)
                {
                    var oldBookRecords = _bookAuthorRepository.GetAll(x => x.BookId == bookId);
                    _bookAuthorRepository.RemoveRange(oldBookRecords);

                    _bookAuthorRepository.Add(new BookAuthor
                    {
                        AuthorId = authorId,
                        BookId = bookId
                    });
                }
            }
        }
    }
}
