namespace Core.DomainModels
{
    public class PinnedUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }       // who pinned
        public int PinnedUserId { get; set; } // who is pinned
    }
}
