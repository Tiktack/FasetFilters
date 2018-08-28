using Faset.Models.Facet;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Faset.Controllers
{
    public class FacetController : Controller
    {
        private readonly BookService bookService = new BookService();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BooksPage()
        {
            return View(new PageViewModel {
                Languages = bookService.GetLanguages(),
                Sales_notes = bookService.GetSales_note()
            });
        }
        public IActionResult GetBooks(string Languages,string Sales_notes)
        {
            return View(new BookListViewModel
            {
                Books = bookService.GetBooksFaceted(Languages, Sales_notes).Take(10).Select(x =>
                   new BookViewModel
                   {
                       Name = x?.name,
                       Author = x?.name,
                       Discription = x?.description,
                       Language = x?.language?.name,
                       Price = x?.price,
                       Year = x?.year,
                       Sales_note = x?.sales_notes?.name
                   })
            });
        }
    }
}