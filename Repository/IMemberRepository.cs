using BussinessObject;
using System.Collections.Generic;

namespace DataAccess{
    public interface IMemberRepository{
        IEnumerable<MemberObject> GetMembers();
        MemberObject GetMemberObjectByID(int memberID);
        void InsertMember(MemberObject member);
        void UpadteMember(MemberObject member);
        void DeleteMember(int memberID);
    }
}