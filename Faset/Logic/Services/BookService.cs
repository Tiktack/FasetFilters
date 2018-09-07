using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Remotion.Linq.Parsing.Structure;
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

        public IQueryable<Book> GetAllBooks()
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

        public IEnumerable<Book> GetBooksFaceted(string Languages, string Sales_note, int PriceMin, int PriceMax)
        {
            string[] languagesFacet;
            string[] sales_notes;
            var result = GetAllBooks();
            if (Languages != null)
            {
                languagesFacet = Languages.Split('|');
                result = result.Where(x => languagesFacet.Any(t => t == x.language.name));
                var query = result.ToSql();
            }
            if (Sales_note != null)
            {
                sales_notes = Sales_note.Split('|');
                result = result.Where(x => sales_notes.Any(t => t == x.sales_notes.name));
            }
            result = result.Where(x => x.price >= PriceMin && x.price <= PriceMax);
            return result;
        }
        public IEnumerable<string> GetLanguages()
        {
            return context.Languages.Where(x => x.name.Length > 1 && x.name.Length < 14).Take(15).Select(x => x.name);
        }
        public IEnumerable<string> GetSales_note()
        {
            return context.Sales_Notes.Select(x => x.name);
        }
        public IEnumerable<string> GetPublishers()
        {
            return context.Publishers.Take(5).Select(x => x.name);
        }
    }
    public static class IQueryableExtensions
    {
        private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

        private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

        private static readonly FieldInfo QueryModelGeneratorField = QueryCompilerTypeInfo.DeclaredFields.First(x => x.Name == "_queryModelGenerator");

        private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

        private static readonly PropertyInfo DatabaseDependenciesField = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var queryCompiler = (QueryCompiler)QueryCompilerField.GetValue(query.Provider);
            var modelGenerator = (QueryModelGenerator)QueryModelGeneratorField.GetValue(queryCompiler);
            var queryModel = modelGenerator.ParseQuery(query.Expression);
            var database = (IDatabase)DataBaseField.GetValue(queryCompiler);
            var databaseDependencies = (DatabaseDependencies)DatabaseDependenciesField.GetValue(database);
            var queryCompilationContext = databaseDependencies.QueryCompilationContextFactory.Create(false);
            var modelVisitor = (RelationalQueryModelVisitor)queryCompilationContext.CreateQueryModelVisitor();
            modelVisitor.CreateQueryExecutor<TEntity>(queryModel);
            var sql = modelVisitor.Queries.First().ToString();

            return sql;
        }
    }
}
