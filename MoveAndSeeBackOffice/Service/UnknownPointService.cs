using MoveAndSeeBackOffice.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Service
{
    class UnknownPointService
    {

        public async Task<IEnumerable<UnknownPoint>> GetAllUnknownPoints(Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            var stringInput = await http.GetStringAsync(new Uri(Constants.ADDRESS_API + "UnknownPoint/GetAllUnknownPoints"));
            UnknownPoint[] points = JsonConvert.DeserializeObject<UnknownPoint[]>(stringInput);

            return points;
        }

        public async Task<int> DeleteUnknownPointById(long idUnknownPoint, Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            HttpResponseMessage response = await http.DeleteAsync(new Uri(Constants.ADDRESS_API + "UnknownPoint/DeleteUnknownPointById/" + idUnknownPoint));
            if (response.IsSuccessStatusCode)
            {
                return Constants.CODE_SUCCESS;
            }
            else
            {
                return Constants.CODE_NOT_FOUND;
            }
        }
    }
}