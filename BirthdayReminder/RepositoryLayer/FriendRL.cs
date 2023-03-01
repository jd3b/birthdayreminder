using BirthdayReminder.CommonLayer.Model;
using Microsoft.AspNetCore.Mvc;
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


        public async Task<ReadFriendsResponse> ReadFriends()
        {
            ReadFriendsResponse response = new ReadFriendsResponse();
            
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Select Id, UserName, DOB from Friends ";
                
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 100;
                    
                    _sqlConnection.Open();
                    //using (DbDataReader _sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    using (SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readFriends = new List<ReadFriends>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadFriends getResponse = new ReadFriends();
                                getResponse.UserID = sqlDataReader["ID"]!=DBNull.Value?Convert.ToInt32(sqlDataReader["ID"]):0;
                                getResponse.UserName =sqlDataReader["UserName"]!=DBNull.Value? sqlDataReader["UserName"].ToString():string.Empty;
                                getResponse.DOB = sqlDataReader["DOB"]!=DBNull.Value? sqlDataReader["DOB"].ToString():string.Empty;
                                response.readFriends.Add(getResponse);
                            }
                        }
                        else
                        {
                            response.Message = "No data Return";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                //await _mySqlConnection.CloseAsync();
                //await _mySqlConnection.DisposeAsync();
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }
        public async Task<DeleteFriendResponse> DeleteFriend(DeleteFriendRequest request)
        {
            DeleteFriendResponse response = new DeleteFriendResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_sqlConnection != null)
                {
                    string SqlQuery = "Delete from Friends where Id=@Id";
                    
                    
                    using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _sqlConnection))
                    {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.CommandTimeout = 100;
                        //sqlCommand.Parameters.AddWithValue("?UserId", request.UserId);
                        sqlCommand.Parameters.AddWithValue("@Id", request.UserId);
                        //await _mySqlConnection.OpenAsync();
                        _sqlConnection.Open();
                        int Status = await sqlCommand.ExecuteNonQueryAsync();
                        if (Status <= 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "UnSuccessful";
                        }
                        
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Message : " + ex.Message;
            }
            finally
            {
                
                await _sqlConnection.CloseAsync();
                await _sqlConnection.DisposeAsync();
            }

            return response;
        }

    }
}
