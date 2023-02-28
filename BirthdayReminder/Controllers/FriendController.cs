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


    }
}
