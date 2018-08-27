using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.Entities;

namespace Logic.Services
{
    public class BookService
    {
        public ApplicationContext context = new ApplicationContext();

        public BookService(/*ApplicationContext context*/)
        {
            //this.context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books;
        }
        public IEnumerable<Book> GetBooks(int count = 10)
        {
            return context.Books.Include(x => x.language)
                .Include(x => x.publisher)
                .Include(x => x.sales_notes)
                .Include(x => x.picture)
                .Take(count);
        }

    }
}
