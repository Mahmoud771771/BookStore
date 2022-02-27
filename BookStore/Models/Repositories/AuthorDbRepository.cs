﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models.Repositories
{
    public class AuthorDbRepository : IBookstoreRepository<Author>
    {
        BookstoreDbContext db;

        public AuthorDbRepository(BookstoreDbContext _db)
        {
            db = _db;

        }
        public void Add(Author entity)
        {
           // entity.Id = db.Authors.Max(b => b.Id) + 1;
            db.Authors.Add(entity);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var author = Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();

        }

        public Author Find(int id)
        {
            var author = db.Authors.SingleOrDefault(b => b.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return db.Authors.ToList();
        }

        public List<Author> Search(string term)
        {
            return db.Authors.Where(a => a.Name.Contains(term)).ToList();

        }

        public void Update(int id, Author entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
