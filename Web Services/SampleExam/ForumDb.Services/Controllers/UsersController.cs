using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ForumDb.Models;
using ForumDb.Repositories;
using ForumDb.Services.Models;

namespace ForumDb.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;

        private const int MinNicknameLength = 6;
        private const int MaxNicknameLength = 30;

        private const string ValidUsernameChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidNicknameChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_. -";

        private const string SessionKeyChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        private static readonly Random rand = new Random();

        private const int SessionKeyLength = 50;

        private const int Sha1Length = 40;

        private readonly IRepository<User> userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    ValidateUsername(model.Username);
                    ValidateNickname(model.Nickname);
                    ValidateAuthCode(model.AuthCode);

                    string modelUsernameToLower = model.Username.ToLower();
                    string modelNickNameToLower = model.Nickname.ToLower();

                    User user = this.userRepository.GetAll().Where(
                        usr => usr.Username.ToLower() == modelUsernameToLower &&
                               usr.AuthCode == model.AuthCode).FirstOrDefault();

                    if (user != null)
                    {
                        throw new InvalidOperationException("The user already exists");
                    }

                    user = new User()
                    {
                        Username = modelUsernameToLower,
                        Nickname = model.Nickname,
                        AuthCode = model.AuthCode
                    };

                    this.userRepository.Add(user);

                    user.SessionKey = this.GenerateSessionKey(user.Id);
                    this.userRepository.Update(user.Id, user);

                    var userLoggedModel = new UserLoggedModel()
                    {
                        Nickname = user.Nickname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, userLoggedModel);
                    return response;
                });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    ValidateUsername(model.Username);
                    ValidateAuthCode(model.AuthCode);

                    string modelUsernameToLower = model.Username.ToLower();

                    User user = this.userRepository.GetAll().Where(
                        usr => usr.Username.ToLower() == modelUsernameToLower &&
                               usr.AuthCode == model.AuthCode).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid username or password");
                    }

                    if (user.SessionKey == null)
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        this.userRepository.Update(user.Id, user);
                    }

                    var userLoggedModel = new UserLoggedModel()
                    {
                        Nickname = user.Nickname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(HttpStatusCode.OK, userLoggedModel);
                    return response;
                });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(UserLoggedModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var user = this.userRepository.GetAll().Where(
                        u => u.SessionKey == model.SessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new InvalidOperationException("The user is not logged in");
                    }

                    user.SessionKey = null;
                    this.userRepository.Update(user.Id, user);

                    var response = this.Request.CreateResponse(HttpStatusCode.OK, (object)null);
                    return response;
                });

            return responseMsg;
        }

        private string GenerateSessionKey(int userId)
        {
            StringBuilder skeyBuilder = new StringBuilder(SessionKeyLength);
            skeyBuilder.Append(userId);

            while (skeyBuilder.Length < SessionKeyLength)
            {
                var index = rand.Next(SessionKeyChars.Length);
                skeyBuilder.Append(SessionKeyChars[index]);
            }

            return skeyBuilder.ToString();
        }

        private void ValidateAuthCode(string authCode)
        {
            if (authCode == null || authCode.Length != Sha1Length)
            {
                throw new ArgumentOutOfRangeException("Password should be encrypted");
            }
        }

        private void ValidateNickname(string nickname)
        {
            if (nickname == null)
            {
                throw new ArgumentNullException("Nickname cannot be null");
            }
            else if (nickname.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Nickname must be at least {0} characters long", MinNicknameLength));
            }
            else if (nickname.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long", MaxNicknameLength));
            }
            else if (nickname.Any(ch => !ValidNicknameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_ and space");
            }
        }

        private void ValidateUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (username.Length < MinUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be at least {0} characters long", MinUsernameLength));
            }
            else if (username.Length > MaxUsernameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Username must be less than {0} characters long", MaxUsernameLength));
            }
            else if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "Username must contain only Latin letters, digits .,_");
            }
        }
    }
}
