using Bookish.Models;

namespace Bookish.Services;

public interface IMemberService
{
    List<MemberModel>Index();
    void Add (MemberRequestModel model);
}

public class MemberService:IMemberService{
    public List<MemberModel>Index()
    {
        using (var context = new BookishContext())

        return (context.Members.ToList());
    }

    public void Add(MemberRequestModel model )
    {
        MemberModel newMember = new MemberModel(model.FirstName,model.LastName, model.DateOfBirth);
        using (var context = new BookishContext())
        {
            context.Members.Add(newMember);
            context.SaveChanges();
    }
    }
}

