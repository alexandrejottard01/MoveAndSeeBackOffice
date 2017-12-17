using MoveAndSeeBackOffice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Service
{
    class UserService
    {
        public async Task<User> GetUserByPseudo(string pseudoUser, Token token)
        {
            User user;
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);

            try
            {
                var stringInput = await http.GetStringAsync(new Uri(Constants.ADDRESS_API + "User/GetUserByPseudo/" + pseudoUser));
                user = JsonConvert.DeserializeObject<User>(stringInput);
            }
            catch(HttpRequestException e)
            {
                user = null;
            }

            return user;
        }

        public async Task<int> EditUser(User userEdit, Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            string json = JsonConvert.SerializeObject(userEdit);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await http.PutAsync(new Uri(Constants.ADDRESS_API + "User/EditUser"), content);
            if (response.IsSuccessStatusCode)
            {
                return Constants.CODE_SUCCESS;
            }
            else
            {
                return Constants.CODE_NOT_FOUND;
            }
        }

        public async Task<int> LoginUser(LoginUser loginUser)
        {
            int resultCode = 0;
            Token token;
            var http = new HttpClient();
            string json = JsonConvert.SerializeObject(loginUser);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var stringInput = await http.PostAsync(new Uri(Constants.ADDRESS_API + "Jwt"), content);
                HttpStatusCode statusCode = stringInput.StatusCode;

                if(statusCode == HttpStatusCode.OK)
                {
                    var stringToken = await stringInput.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<Token>(stringToken);

                    if (VerificationIsAdmin(token.TokenString))
                    {
                        resultCode = 200;
                        Token.tokenCurrent = token;
                    }
                    else
                    {
                        resultCode = 401;
                    }
                }
                else
                {
                    if(statusCode == HttpStatusCode.NotFound)
                    {
                        resultCode = 404;
                    }
                    else
                    {
                        resultCode = 401;
                    }
                }
            }
            catch (HttpRequestException)
            {
                resultCode = 0;
            }

            return resultCode;
        }

        public bool VerificationIsAdmin(String token)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            var role = tokenS.Claims.SingleOrDefault(claim => claim.Type == "Role").Value;

            return (role != null && role == "admin");
        }
    }
}