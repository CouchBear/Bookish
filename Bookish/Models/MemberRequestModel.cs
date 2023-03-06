using System.ComponentModel.DataAnnotations;

namespace Bookish.Models;
public class MemberRequestModel
{ [Required(ErrorMessage ="First Name is required.")]
   public string FirstName { get; set; }
 [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; }
 [Required(ErrorMessage ="Date is required, dd/mm/yyyy")]
    public string DateOfBirth { get; set; }

    public MemberRequestModel()
    {
        
    }


    
}