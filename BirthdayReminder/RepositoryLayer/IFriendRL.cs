using BirthdayReminder.CommonLayer.Model;

namespace BirthdayReminder.RepositoryLayer
{
    public interface IFriendRL
    {
        public Task<CreateFriendResponse> CreateFriend(CreateFriendRequest request);
        public Task<ReadFriendsResponse> ReadFriends();
        public Task<DeleteFriendResponse> DeleteFriend(DeleteFriendRequest request);
    }
}
