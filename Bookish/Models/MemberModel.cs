using System.ComponentModel.DataAnnotations;


namespace Bookish.Models;
public class MemberModel
{  [Key]
   public  int Id { get; set; }
    [Required(ErrorMessage ="First Name is required.")]
    public string FirstName { get; set; }
 [Required(ErrorMessage ="Last Name is required.")]
    public string LastName { get; set; }
 [Required(ErrorMessage ="Date is required, dd/mm/yyyy")]
    public string DateOfBirth { get; set; }

    public MemberModel(string firstName, string lastName, string dateOfBirth)
    {
        FirstName=firstName;
        LastName=lastName;
        DateOfBirth=dateOfBirth;
    }

    
}