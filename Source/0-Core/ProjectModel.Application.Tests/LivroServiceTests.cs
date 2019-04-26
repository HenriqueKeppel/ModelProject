using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProjectModel.Domain.Adapters;
using ProjectModel.Domain.Services;
using ProjectModel.GoogleBooksApiAdapter;
using ProjectModel.GoogleBooksApiAdapter.Clients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProjectModel.Application.Tests
{
    public class LivroServiceTests
    {
      /*  private readonly ServiceProvider serviceProvider;

        public LivroServiceTests()
        {
            var googlebooksApiReadOnlyAdapterMock = new Mock<IGoogleBooksReadOnlyAdapter>();

            ConfiguraGooglebooksApiReadOnlyAdapterMock(googlebooksApiReadOnlyAdapterMock);

            IServiceCollection services = new ServiceCollection();

            services.AddTransient<GoogleBooksReadOnlyAdapterConfigurarion>(c => new GoogleBooksReadOnlyAdapterConfigurarion
            {
                DbApiUrlBase = "google.com"
            });
            services.AddTransient<ApplicationConfiguration>();
            services.AddTransient(t => googlebooksApiReadOnlyAdapterMock.Object);
            services.AddTransient<ILivrosService, LivrosService>();

            serviceProvider = services.BuildServiceProvider();
        }

        public void ConfiguraGooglebooksApiReadOnlyAdapterMock(Mock<IGoogleBooksReadOnlyAdapter> mockItem)
        {
            List<IndustryIdentifiers> industryIdentifiers = new List<IndustryIdentifiers>();
            List<string> authors = new List<string>();
            List<Book> books = new List<Book>();           

            IndustryIdentifiers item1 = new IndustryIdentifiers
            {
                identifier = "9780465097517",
                type = "ISBN_13"
            };

            IndustryIdentifiers item2 = new IndustryIdentifiers
            {
                identifier = "0465097510",
                type = "ISBN_10"
            };

            industryIdentifiers.Add(item1);
            industryIdentifiers.Add(item2);
            authors.Add("Hachette UK");

            VolumeInfo volumeInfo = new VolumeInfo
            {
                title = "How Star Wars Conquered the Universe",
                industryIdentifiers = industryIdentifiers,
                publishedDate = "2015-10-06",
                publisher = "Hachette UK",
                authors = authors,
                description = "In 1973, a young filmmaker named George Lucas scribbled some notes for a far-fetched space-fantasy epic. Some forty years and 37 billion later, Star Wars–related products outnumber human beings, a growing stormtrooper army spans the globe, and “Jediism” has become a religion in its own right. Lucas's creation has grown into far more than a cinematic classic; it is, quite simply, one of the most lucrative, influential, and interactive franchises of all time. Yet incredibly, until now the complete history of Star Wars—its influences and impact, the controversies it has spawned, its financial growth and long-term prospects—has never been told. In How Star Wars Conquered the Universe, veteran journalist Chris Taylor traces the series from the difficult birth of the original film through its sequels, the franchise's death and rebirth, the prequels, and the preparations for a new trilogy. Providing portraits of the friends, writers, artists, producers, and marketers who labored behind the scenes to turn Lucas's idea into a legend, Taylor also jousts with modern-day Jedi, tinkers with droid builders, and gets inside Boba Fett's helmet, all to find out how Star Wars has attracted and inspired so many fans for so long. Since the first film's release in 1977, Taylor shows, Star Wars has conquered our culture with a sense of lightness and exuberance, while remaining serious enough to influence politics in far-flung countries and spread a spirituality that appeals to religious groups and atheists alike. Controversial digital upgrades and poorly received prequels have actually made the franchise stronger than ever. Now, with a savvy new set of bosses holding the reins and Episode VII on the horizon, it looks like Star Wars is just getting started. An energetic, fast-moving account of this creative and commercial phenomenon, How Star Wars Conquered the Universe explains how a young filmmaker's fragile dream beat out a surprising number of rivals to gain a diehard, multigenerational fan base—and why it will be galvanizing our imaginations and minting money for generations to come."
            };

            Book book = new Book()
            {
                id = "pok5DgAAQBAJ",
                etag = "TSsFeBVStIc",
                kind = "books#volume",
                selfLink = "https://www.googleapis.com/books/v1/volumes/pok5DgAAQBAJ",
                volumeInfo = volumeInfo
            };

            books.Add(book);

            BookResponseGet bookResponseGet = new BookResponseGet
            {
                kind = "books#volumes",
                totalItens = 1,
                items = books
            };

            mockItem
                .Setup(s => s.GetLivroPorTituloAsync("123456"))
                .Returns(Task.FromResult(bookResponseGet));
        }

        [Fact]
        public void ObterLivroPorTituloAsync()
        {
            string titulo = "star wars";

            var livroService = serviceProvider.GetService<ILivrosService>();
            var retorno = livroService.ObterLivroPorTituloAsync(titulo);

            Assert.NotEmpty(retorno.Result);
        }*/
    }
}
