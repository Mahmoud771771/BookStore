using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class BookDbRepository : IBookstoreRepository<Book>
    {
        BookstoreDbContext db;

        public BookDbRepository(BookstoreDbContext _db)
        {
            db = _db;

        }
        public void Add(Book entity)
        {
           
            db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            db.Books.Remove(book);
            db.SaveChanges();

        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
             return db.Books.ToList();
            //var book =( from b in db.Books
            //            join a in db.Authors
            //           on b.Author equals a.Id
            //           select new
            //           {
            //               BookId = b.Id,
            //               bookTitle = b.Title,
            //               bookDescription = b.Description,
            //               bookAuthor = a.Name
            //           }).ToList();
            //return book;
               
        }

        public void Update(int id, Book newBook)
        {
            db.Update(newBook);
            db.SaveChanges();

        }
        public List<Book> Search(string term)
        {
            var result = db.Books.Include(a => a.Author)
                .Where(b => b.Title.Contains(term) 
                        || b.Description.Contains(term) 
                        || b.Author.Name.Contains(term)).ToList();
            return result;
        }
    }
}