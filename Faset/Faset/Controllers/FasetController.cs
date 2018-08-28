using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faset.Models;
using Logic.Services;

namespace Faset.Controllers
{
    public class FasetController : Controller
    {
        private BookService bookService = new BookService();

        public FasetController(/*BookService bookService*/)
        {
            //this.bookService = bookService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FacetMenu()
        {
            return View(new FacetMenuModel
            {
                Languages = bookService.GetLanguages(),
                //Publishers = bookService.GetPublishers(),
                Sales_notes = bookService.GetSales_note()

            });
        }
        public IActionResult GetBookList()
        {
            return View(new FasetListViewModel
            {
                Books = bookService.GetBooks(10).Select(x =>
                    new FasetViewModel
                    {
                        Name = x?.name,
                        Author = x?.name,
                        Discription = x?.description,
                        Language = x?.language?.name,
                        Price = x?.price,
                        Year = x?.year
                    })
            });
        }
        public IActionResult GetBookListFacetedLanguage(string facet)
        {
            var languagesFacet = facet.Split('|');
            var result = bookService.GetAllBooks();
                result = result.Where(x => languagesFacet.Any(t=>t==x?.language?.name));
            return View(new FasetListViewModel
            {
                Books = result.Take(10).Select(x =>
                   new FasetViewModel
                   {
                       Name = x?.name,
                       Author = x?.name,
                       Discription = x?.description,
                       Language = x?.language?.name,
                       Price = x?.price,
                       Year = x?.year
                   })
            });
        }
    }
}
