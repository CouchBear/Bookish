using Bookish.Models;


namespace Bookish.Services;

public interface IBookService
{
    List<BookDatabaseModel> Index();
    void Add(BookRequestModel model);
}

public class BookService:IBookService{
    public List<BookDatabaseModel>Index()
    {
        using (var context = new BookishContext())

        return (context.Books.ToList());
    }

    public void Add(BookRequestModel model )
    {
        BookDatabaseModel newBook = new BookDatabaseModel(model.Title,model.Author, model.Year);
        using (var context = new BookishContext())
        {
            context.Books.Add(newBook);
            context.SaveChanges();
    }
    }
}

