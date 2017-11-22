using MoveAndSeeBackOffice.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Service
{
    class InterestPointService
    {
        public async Task<IEnumerable<InterestPointWithVote>> GetAllInterestPointSortedByVoteInterestPoint()
        {
            var http = new HttpClient();

            //Url à changer en : http://moveandsee.azurewebsites.net/api/InterestPoint/GetAllInterestPointSortedByVoteInterestPoint
            //Quand le problème dans l'Api sera reglé
            var stringInput = await http.GetStringAsync(new Uri("http://moveandsee.azurewebsites.net/api/InterestPoint/GetAllInterestPoints"));
            InterestPointWithVote[] points = JsonConvert.DeserializeObject<InterestPointWithVote[]>(stringInput);

            return points;
        }

        public async Task<int> DeleteInterestPointById(long idInterestPoint)
        {
            var http = new HttpClient();

            HttpResponseMessage response = await http.DeleteAsync(new Uri("http://moveandsee.azurewebsites.net/api/InterestPoint/DeleteInterestPointById/" + idInterestPoint));
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