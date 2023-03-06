using System.ComponentModel.DataAnnotations;

namespace Bookish.Models;
public class BookDatabaseModel
{   [Key]
   public  int Id { get; set; }

   [Required(ErrorMessage ="Title is required.")]
    public string Title { get; set; }
    [Required(ErrorMessage ="Author is required.")]
    public string Author { get; set; }
    [Required(ErrorMessage ="Year is required and between 0 and 2023")]
    [Range(0,2023)]
    public int Year { get; set; }

    public BookDatabaseModel(string title, string author, int year)
    {
        
        Title = title;
        Author = author;
        Year = year;
    }

    
}