namespace BirthdayReminder.CommonLayer.Model
{
    public class ReadFriendsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<ReadFriends> readFriends { get; set; }
    }

    public class ReadFriends
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string DOB { get; set; }
    }
}
