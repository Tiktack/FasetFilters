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
            return context.Books.Include(x => x.language)
                .Include(x => x.sales_notes);
        }
        public IEnumerable<Book> GetBooks(int count = 10)
        {
            return context.Books.Include(x => x.language)
                .Include(x => x.publisher)
                .Include(x => x.sales_notes)
                .Include(x => x.picture)
                .Take(count);
        }
        public IEnumerable<string> GetLanguages()
        {
            return context.Languages.Take(5).Select(x => x.name);
        }
        public IEnumerable<string> GetSales_note()
        {
            return context.Sales_Notes.Take(5).Select(x => x.name);
        }
        public IEnumerable<string> GetPublishers()
        {
            return context.Publishers.Take(5).Select(x => x.name);
        }

    }
}
