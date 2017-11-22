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
    class DescriptionService
    {
        public async Task<IEnumerable<DescriptionWithVote>> GetAllDescriptionsByInterestPoint(long idInterestPoint)
        {
            var http = new HttpClient();

            //Url à changer en : http://moveandsee.azurewebsites.net/api/Description/GetAllDescriptionsSortedByVoteByInterestPoint/
            //Quand le problème dans l'Api sera reglé
            var stringInput = await http.GetStringAsync(new Uri("http://moveandsee.azurewebsites.net/api/Description/GetAllDescriptionsByInterestPoint/"+idInterestPoint));
            DescriptionWithVote[] descriptions = JsonConvert.DeserializeObject<DescriptionWithVote[]>(stringInput);

            return descriptions;
        }

        public async Task<int> DeleteDescriptionById(long idDescription)
        {
            var http = new HttpClient();

            HttpResponseMessage response = await http.DeleteAsync(new Uri("http://moveandsee.azurewebsites.net/api/Description/DeleteDescriptionById/" + idDescription));
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