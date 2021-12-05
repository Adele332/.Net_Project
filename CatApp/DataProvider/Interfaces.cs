using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatApp.DataProvider
{
    public interface ICatDataProvider  
    {
        IList<CategoriesModel> GetCategories();

        IList<ImageModel> GetImage(string search);

        IList<AboutBreedModel> GetAboutBreed(string search);

    }
}
