using Newtonsoft.Json;
using ProjectModel.GoogleBooksApiAdapter.Clients;
using ProjectModel.Domain.Adapters;
using ProjectModel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ProjectModel.GoogleBooksApiAdapter
{
    public class GoogleBooksReadOnlyAdapter : IGoogleBooksReadOnlyAdapter
    {
        private GoogleBooksReadOnlyAdapterConfiguration dbAdapterConfiguration;

        public GoogleBooksReadOnlyAdapter(GoogleBooksReadOnlyAdapterConfiguration dbAdapterConfiguration)
        {
            this.dbAdapterConfiguration = dbAdapterConfiguration ?? throw new ArgumentNullException(nameof(dbAdapterConfiguration));
        }

        public async Task<IEnumerable<Livro>> GetLivroPorTituloAsync(string titulo)
        {
            BookResponseGet retorno = null;
            List<Livro> listaRetorno = new List<Livro>();

            var uri = new Uri(string.Format("{0}title:{1}", dbAdapterConfiguration.DbApiUrlBase,  titulo));

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<BookResponseGet>(responseString);
                }
            }

            // Mapeamento manual de retorno
            //TODO: utilizar o AutoMapper
            foreach (Book item in retorno.items)
            {
                Livro livro = new Livro();

                livro.Isbn_13 = item.volumeInfo.industryIdentifiers.Where(x => x.type == "ISBN_13").FirstOrDefault().identifier;
                livro.Isbn_10 = item.volumeInfo.industryIdentifiers.Where(x => x.type == "ISBN_10").FirstOrDefault().identifier;
                livro.Titulo = item.volumeInfo.title;
                livro.Descricao = item.volumeInfo.description;
                livro.Autores = item.volumeInfo.authors;

                listaRetorno.Add(livro);
            }
            return listaRetorno;
        }
    }
}
