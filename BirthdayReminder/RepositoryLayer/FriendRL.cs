using BirthdayReminder.CommonLayer.Model;
using System.Data.SqlClient;

namespace BirthdayReminder.RepositoryLayer
{
    public class FriendRL : IFriendRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        public FriendRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);
        }
        public async Task<CreateFriendResponse> CreateFriend(CreateFriendRequest request)
        {
            CreateFriendResponse response = new CreateFriendResponse();
            response.IsSuccess = true;
            response.Message = "Successful";

            try
            {
                string SqlQuery = "Insert Into Friends (UserName, DOB) values (@UserName, @DOB)";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 100;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@DOB", request.DOB);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status == 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong!";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            finally 
            { 
                _sqlConnection.Close(); 
            }
            return response;
        }
    }
}
