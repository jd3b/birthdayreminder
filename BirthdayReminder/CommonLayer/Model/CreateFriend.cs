namespace BirthdayReminder.CommonLayer.Model
{
    public class CreateFriendRequest
    {
        public string UserName { get; set; } 
        public DateTime DOB { get; set; }
    }

    public class CreateFriendResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        
    }
}
