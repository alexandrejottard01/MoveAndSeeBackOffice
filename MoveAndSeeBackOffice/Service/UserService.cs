using MoveAndSeeBackOffice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Service
{
    class UserService
    {
        //public async Task<User> GetUserByPseudo(string pseudoUser)
        //{
        //    User user;
        //    var http = new HttpClient();

        //    HttpResponseMessage reponse = await http.GetAsync(new Uri("http://moveandsee.azurewebsites.net/api/User/GetUserByPseudo/" + pseudoUser));
        //    if (reponse.IsSuccessStatusCode)
        //    {
        //        var stringInput = await http.GetStringAsync(new Uri("http://moveandsee.azurewebsites.net/api/User/GetUserByPseudo/" + pseudoUser));
        //        user = JsonConvert.DeserializeObject<User>(stringInput);
        //    }
        //    else
        //    {
        //        user = null;
        //    }
        //    return user;
        //}

        public async Task<User> GetUserByPseudo(string pseudoUser)
        {
            User user;
            var http = new HttpClient();

            try
            {
                var stringInput = await http.GetStringAsync(new Uri("http://moveandsee.azurewebsites.net/api/User/GetUserByPseudo/" + pseudoUser));
                user = JsonConvert.DeserializeObject<User>(stringInput);
            }
            catch(HttpRequestException e)
            {
                user = null;
            }
            return user;
        }

        public async Task<int> EditUser(User userEdit)
        {
            var http = new HttpClient();

            string json = JsonConvert.SerializeObject(userEdit);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            //HttpContent content = new StringContent(json);


            HttpResponseMessage response = await http.PutAsync(new Uri("http://moveandsee.azurewebsites.net/api/User/EditUser"), content);


            //HttpResponseMessage response = await http.PutAsync(new Uri("http://moveandsee.azurewebsites.net/api/User/EditUserByPseudo/"), new StringContent(userEdit.ToString(),Encoding.UTF8,"application/json"));


            if (response.IsSuccessStatusCode)
            {
                return 200;
            }
            else
            {
                return 400;
            }
        }
    }
}