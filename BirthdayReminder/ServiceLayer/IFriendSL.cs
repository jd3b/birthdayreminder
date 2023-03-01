using BirthdayReminder.CommonLayer.Model;

namespace BirthdayReminder.ServiceLayer
{
    public interface IFriendSL
    {
        public Task<CreateFriendResponse> CreateFriend(CreateFriendRequest request);
        public Task<ReadFriendsResponse> ReadFriends();
        public Task<DeleteFriendResponse> DeleteFriend(DeleteFriendRequest response);
    }
}
