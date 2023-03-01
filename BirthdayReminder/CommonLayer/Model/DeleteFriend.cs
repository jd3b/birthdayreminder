namespace BirthdayReminder.CommonLayer.Model
{
    public class DeleteFriendRequest
    {
        public int UserId { get; set; }
    }

    public class DeleteFriendResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public DeleteFriend deleteFriend { get; set; }
    }

    public class DeleteFriend
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string DOB { get; set; }
    }
}
