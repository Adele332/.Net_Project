using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CatApp.DataProvider
{
    public class RestApi : ICatDataProvider
    {
        private IRestClient m_client;

        public RestApi(IRestClient restClient)
        {
            m_client = restClient;
        }

        public RestApi()
        {
            m_client = new RestClient($"https://api.thecatapi.com/v1/");
            m_client.Timeout = -1;
        }
        public IList<CategoriesModel> GetCategories()
        {
            var request = new RestRequest($"categories", Method.GET);
            IRestResponse response = m_client.Execute(request);
            List<CategoriesModel> list = JsonConvert.DeserializeObject<List<CategoriesModel>>(response.Content);
            return list;
        }
        public IList<ImageModel> GetImage(string search)
        {
            var request = new RestRequest($"images/search?category_ids={search}", Method.GET);
            IRestResponse response = m_client.Execute(request);
            List<ImageModel> list = JsonConvert.DeserializeObject<List<ImageModel>>(response.Content);
            return list;
        }

        public IList<AboutBreedModel> GetAboutBreed(string search)
        {
            var request = new RestRequest($"breeds/search?q={search}", Method.GET);
            IRestResponse response = m_client.Execute(request);
            List<AboutBreedModel> list = JsonConvert.DeserializeObject<List<AboutBreedModel>>(response.Content);
            return list;
        }
    }
}
