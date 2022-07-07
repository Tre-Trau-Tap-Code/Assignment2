using BusinessObject;
using System;
namespace DataAccess;
public interface IMemberRepository
{
    IEnumerable<Member> GetMembers();
    Member GetMemberById(int memberId);
    Member GetMemberByEmailAndPassword(string email, string password);
    void InsertMember(Member member);
    void DeleteMember(int memberId);
    void UpdateMember();
}
