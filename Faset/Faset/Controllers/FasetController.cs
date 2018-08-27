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
        public IActionResult GetBookList()
        {


            var a = bookService.GetBooks(10);
            var b = a.Select(x =>
                     new FasetViewModel
                     {
                         Name = x?.name,
                         Author = x?.name,
                         Discription = x?.description,
                         Language = x?.language?.name,
                         Price = x?.price,
                         Year = x?.year
                     });

            return View(new FasetListViewModel
            {
                Books = b
            });
        }
    }
}