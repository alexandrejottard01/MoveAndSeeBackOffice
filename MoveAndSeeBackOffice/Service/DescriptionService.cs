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
        public async Task<IEnumerable<DescriptionWithVote>> GetAllDescriptionsByInterestPoint(long idInterestPoint, Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            var stringInput = await http.GetStringAsync(new Uri(Constants.ADDRESS_API + "Description/GetAllDescriptionsSortedByVoteByInterestPoint/" + idInterestPoint));
            DescriptionWithVote[] descriptions = JsonConvert.DeserializeObject<DescriptionWithVote[]>(stringInput);

            return descriptions;
        }

        public async Task<int> DeleteDescriptionById(long idDescription, Token token)
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.TokenString);
            HttpResponseMessage response = await http.DeleteAsync(new Uri(Constants.ADDRESS_API + "Description/DeleteDescriptionById/" + idDescription));
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