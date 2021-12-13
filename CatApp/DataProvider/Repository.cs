using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatApp.DataProvider
{
    public class Repository
    {
        private readonly  ICatDataProvider m_provider;

        public Repository(ICatDataProvider provider)
        {
            m_provider = provider;
        }

        public int CountResults(string search)
        {
            return m_provider.GetAboutBreed(search).Count();
                //Where(o => o.name.Contains(search)).Count();

        }
    }
}
