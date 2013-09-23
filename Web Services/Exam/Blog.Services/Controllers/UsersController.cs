using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Blog.Models;
using Blog.Repositories;
using Blog.Services.Models;

namespace Blog.Services.Controllers
{
    public class UsersController : BaseApiController
    {
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;

        private const int MinDisplayNameLength = 6;
        private const int MaxDisplayNameLength = 30;

        private const string ValidUsernameChars =
            "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM1234567890_.";
        private const string ValidDisplayNameChars =
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
        public HttpResponseMessage RegisterUser([FromBody]UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateUsername(model.Username);
                ValidateDisplayName(model.DisplayName);
                ValidateAuthCode(model.AuthCode);

                string modelUsernameToLower = model.Username.ToLower();
                string modelDisplayName = model.DisplayName.ToLower();

                User user = this.userRepository.GetAll().Where(
                    usr => usr.Username.ToLower() == modelUsernameToLower ||
                           usr.DisplayName.ToLower() == modelDisplayName).FirstOrDefault();

                if (user != null)
                {
                    throw new InvalidOperationException("The user already exists");
                }

                user = new User()
                {
                    Username = modelUsernameToLower,
                    DisplayName  = model.DisplayName,
                    AuthCode = model.AuthCode
                };

                this.userRepository.Add(user);

                user.SessionKey = this.GenerateSessionKey(user.Id);
                this.userRepository.Update(user.Id, user);

                var userLoggedModel = new UserLoggedModel()
                {
                    DisplayName = user.DisplayName,
                    SessionKey = user.SessionKey
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, userLoggedModel);
                return response;
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]UserModel model)
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
                    DisplayName = user.DisplayName,
                    SessionKey = user.SessionKey
                };

                var response = this.Request.CreateResponse(HttpStatusCode.Created, userLoggedModel);
                return response;
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser([FromUri]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var user = this.userRepository.GetAll().Where(
                    u => u.SessionKey == sessionKey).FirstOrDefault();

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

        private void ValidateDisplayName(string displayName)
        {
            if (displayName == null)
            {
                throw new ArgumentNullException("DisplayName cannot be null");
            }
            else if (displayName.Length < MinDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Displayname must be at least {0} characters long", MinDisplayNameLength));
            }
            else if (displayName.Length > MaxDisplayNameLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("DisplayName must be less than {0} characters long", MaxDisplayNameLength));
            }
            else if (displayName.Any(ch => !ValidDisplayNameChars.Contains(ch)))
            {
                throw new ArgumentOutOfRangeException(
                    "DisplaynName must contain only Latin letters, digits .,_ and space");
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
