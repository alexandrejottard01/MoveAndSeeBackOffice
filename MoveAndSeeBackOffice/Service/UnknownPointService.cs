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

        public async Task<IEnumerable<UnknownPoint>> GetAllUnknownPoints()
        {
            var http = new HttpClient();

            var stringInput = await http.GetStringAsync(new Uri("http://moveandsee.azurewebsites.net/api/UnknownPoint/GetAllUnknownPoints"));
            UnknownPoint[] points = JsonConvert.DeserializeObject<UnknownPoint[]>(stringInput);

            return points;
        }

        public async Task<int> DeleteUnknownPointById(long idUnknownPoint)
        {
            var http = new HttpClient();

            HttpResponseMessage response = await http.DeleteAsync(new Uri("http://moveandsee.azurewebsites.net/api/UnknownPoint/DeleteUnknownPointById/" + idUnknownPoint));
            if (response.IsSuccessStatusCode)
            {
                return 200;
            }
            else
            {
                return 404;
            }
        }
    }
}