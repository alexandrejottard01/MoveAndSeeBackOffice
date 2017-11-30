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
        public async Task<IEnumerable<InterestPointWithVote>> GetAllInterestPointSortedByVoteInterestPoint(Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            //Url à changer en : http://moveandsee.azurewebsites.net/api/InterestPoint/GetAllInterestPointSortedByVoteInterestPoint
            var stringInput = await http.GetStringAsync(new Uri(Constants.ADDRESS_API + "InterestPoint/GetAllInterestPoints"));
            InterestPointWithVote[] points = JsonConvert.DeserializeObject<InterestPointWithVote[]>(stringInput);

            return points;
        }

        public async Task<int> DeleteInterestPointById(long idInterestPoint, Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString); 
            HttpResponseMessage response = await http.DeleteAsync(new Uri(Constants.ADDRESS_API + "InterestPoint/DeleteInterestPointById/" + idInterestPoint));
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