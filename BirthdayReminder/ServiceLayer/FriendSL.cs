using BirthdayReminder.CommonLayer.Model;
using BirthdayReminder.RepositoryLayer;

namespace BirthdayReminder.ServiceLayer
{
    public class FriendSL : IFriendSL
    {
        public readonly IFriendRL _friendRL;
        public FriendSL(IFriendRL friendRL)
        {
            _friendRL = friendRL;
        }

        public async Task<CreateFriendResponse> CreateFriend(CreateFriendRequest request)
        {
            return await _friendRL.CreateFriend(request);
        }
        public async Task<ReadFriendsResponse> ReadFriends()
        {
            return await _friendRL.ReadFriends();
        }
        public async Task<DeleteFriendResponse> DeleteFriend(DeleteFriendRequest request)
        {
            return await _friendRL.DeleteFriend(request);
        }
    }
}
