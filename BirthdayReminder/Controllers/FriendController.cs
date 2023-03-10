using BirthdayReminder.CommonLayer.Model;
using BirthdayReminder.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayReminder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        public readonly IFriendSL _friendSL;
        public FriendController(IFriendSL friendSL)
        {
            _friendSL = friendSL;
        }
        [HttpPost]
        [Route("CreateFriend")]
        public async Task<IActionResult> CreateFriend(CreateFriendRequest request)
        {
            CreateFriendResponse response = null;
            try
            {
                response=await _friendSL.CreateFriend(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("ReadFriends")]
        public async Task<IActionResult> ReadFriends()
        {
            ReadFriendsResponse response = null;
            try
            {

                response = await _friendSL.ReadFriends();

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }
        [HttpPost]
        [Route("DeleteFriend")]
        public async Task<IActionResult> DeleteFriend(DeleteFriendRequest request)
        {
            DeleteFriendResponse response = null;
            try
            {

                response = await _friendSL.DeleteFriend(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }

            return Ok(response);
        }
    }
}
