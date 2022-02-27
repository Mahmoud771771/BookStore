using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorRepository : IBookstoreRepository<Author>
    {
        List<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>() { 
            new Author{Id=1,Name="Mahmoud Shabaan "},
            new Author{Id=2,Name="Mohamed Taha "},
            new Author{Id=3,Name="Mohamed Hasn "}

            };

        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(b =>b.Id==id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a=>a.Name.Contains(term)).ToList();
        }

        public void Update(int id, Author entity)
        {
            var author = Find(id);
             author.Name = entity.Name;
        }
    }
}
