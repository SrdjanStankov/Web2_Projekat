namespace Core.Entities
{
    public class UserFriends
    {
        public long Id { get; set; }

        public User Friend { get; set; }
        public string FriendEmail { get; set; }

        public User User { get; set; }
        public string UserEmail { get; set; }

        public UserFriends()
        {
        }

        public UserFriends(string userEmail, string friendEmail)
        {
            UserEmail = userEmail;
            FriendEmail = friendEmail;
        }
    }
}