using System.ComponentModel.DataAnnotations;

namespace Bookish.Models;
public class BookRequestModel
{
    [Required(ErrorMessage ="Title is Required.")]
    public string Title { get; set; }
    [Required(ErrorMessage ="Author is Required.")]
    public string Author { get; set; }
    [Required(ErrorMessage ="Year is required and between 0 and 2023")]
    [Range(0, 2023)]
    public int Year { get; set; }

    public BookRequestModel()
    {
    }


}