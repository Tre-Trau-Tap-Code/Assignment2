using BusinessObject;
using System;

namespace DataAccess;
public class MemberRepository : IMemberRepository
{
    public void DeleteMember(int memberId) => MemberDAO.Instance.Remove(memberId);
    public Member GetMemberById(int memberId) => MemberDAO.Instance.GetMemberById(memberId);
    public IEnumerable<Member> GetMembers() => MemberDAO.Instance.GetMembers;
    public void InsertMember(Member member) => MemberDAO.Instance.AddNew(member);
    public void UpdateMember() => MemberDAO.Instance.Update();
    public Member GetMemberByEmailAndPassword(string email, string password) => MemberDAO.Instance.GetMemberByEmailAndPassword(email, password);
}
