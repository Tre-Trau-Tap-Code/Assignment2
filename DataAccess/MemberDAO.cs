using BusinessObject;

namespace DataAccess
{
    public class MemberDAO : FStoreContext
    {
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Member> GetMembers => Members.ToList();

        public Member GetMemberById(int memberId) => Members.Find(memberId);
        public Member GetMemberByEmailAndPassword(string email, string password) => Members.Where(member => member.Email.Equals(email) && member.Password.Equals(password)).Single();
        public void Remove(int memberId) { Members.Remove(GetMemberById(memberId)); SaveChanges(); }
        public void AddNew(Member member) { Members.Add(member); SaveChanges(); }
        public void Update() => SaveChanges();
    }
}
