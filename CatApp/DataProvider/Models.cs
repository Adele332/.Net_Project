using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatApp.DataProvider
{
    public class CategoriesModel
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class ImageModel
    {
        public string id { get; set; }
        public string url { get; set; }
    }

    public class AboutBreedModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string alt_names { get; set; }
        public string origin { get; set; }
        public string temperament { get; set; }
        public string description { get; set; }

    }
}
