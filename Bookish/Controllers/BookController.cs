using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookish.Models;
using Bookish.Services;


namespace Bookish.Controllers;


public class BookController : Controller
{
    private readonly ILogger<BookController> _logger; //write log messages that associated with BookController class
    private readonly IBookService _myService;

    public BookController(ILogger<BookController> logger, IBookService myService)
    {
        _logger = logger;
        _myService = myService;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Index()
    {
        // using (var context = new BookishContext())

        //     return View(context.Books.ToList());
        return View(_myService.Index());
    }

    public IActionResult Add()
    {
        return View("Views/Book/Add.cshtml");
    }

    [HttpPost]
    public IActionResult Add(BookRequestModel model)

    {   //User input validation
        if (!ModelState.IsValid)
        {   ModelState.AddModelError("","Validation summary Error.");
            return RedirectToAction("Add");
        }

        _myService.Add(model);
        return RedirectToAction("Index");


    }


    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            ModelState.AddModelError("IdError", "Can't find this book.");
            return RedirectToAction("Index");
        }
        using (var context = new BookishContext())
        {
            BookDatabaseModel newBook = context.Books.Find(id);
            //BookDatabaseModel newBook=context.Books.Where(b=>b.Id==id).FirstOrDefault();

            if (newBook == null)
            {
                ModelState.AddModelError("NotFoundBookError", "Can't find this book in the Library.");
                return RedirectToAction("Index");
            }
            return View(newBook);
        }
    }


    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            ModelState.AddModelError("IdError", "Can't find this book.");
            return RedirectToAction("Index");
        }
        using (var context = new BookishContext())
        {
            BookDatabaseModel newBook = context.Books.Find(id);

            if (newBook == null)
            {
                ModelState.AddModelError("NotFoundBookError", "Can't find this book in the Library.");
                return RedirectToAction("Index");
            }
            else

                return View(newBook);

        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PostEdit(int? id, BookRequestModel model)
    {   
        if (ModelState.IsValid)
        {
            using (var context = new BookishContext())
            {
                BookDatabaseModel book = context.Books.Find(id);
                // Console.WriteLine(id);
                // Console.WriteLine(book.Title);
                if (book!= null)
                {
                    book.Title = model.Title; //can't use context.Books.Update(model) is because model is of BookRequestModel, book is of BookDatabaseModel
                    book.Author = model.Author;
                    book.Year = model.Year;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("NotFoundBookError", "Can't find this book in the Library.");
                    return RedirectToAction($"Edit/{id}");
                }
            }
        }
        else
        {   
            return RedirectToAction($"Edit/{id}");
        }
    }

    //Delete command comes from a link, so it is Get, rather than Post method
    public IActionResult Delete(int? id)
    {
        using (var context = new BookishContext())
        {   
           BookDatabaseModel book = context.Books.Find(id);

            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("NotFoundBookError", "Can't find this book in the Library.");
                return RedirectToAction("Index");
            }
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
