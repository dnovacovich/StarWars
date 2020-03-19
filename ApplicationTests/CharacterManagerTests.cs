using Application.Helpers;
using Application.Managers;
using Microsoft.Extensions.Configuration;
using Persistence.Repositories;
using System;
using Xunit;
using Moq;
using Application.Interfaces.Repositories;
using Application.Exceptions;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using Domain.Entities.ExternalApi;

namespace ApplicationTests
{
    public class CharacterManagerTests
    {
        private CharacterManager _characterManager { get; set; }

        public CharacterManagerTests()
        {
            // Mock Data
            Mock<IConfiguration> _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "ExternalServicesURL:Character")]).Returns("https://swapi.co/api/people/");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "ExternalServicesURL:Planet")]).Returns("https://swapi.co/api/planet/");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "ExternalServicesURL:Species")]).Returns("https://swapi.co/api/species/");
            
            Mock <IRatingRepository> ratingRepository = new Mock<IRatingRepository>();
            ratingRepository.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>()));

            Mock<RequestExternalApiHelper> requestExternalApiHelper = new Mock<RequestExternalApiHelper>(_configuration.Object);

            Mock<IMemoryCache> memoryCache = new Mock<IMemoryCache>();
            memoryCache.Setup(x => x.CreateEntry(It.IsAny<object>())).Returns(Mock.Of<ICacheEntry>);
            // *******

            _characterManager = new CharacterManager(requestExternalApiHelper.Object, ratingRepository.Object, memoryCache.Object);
    }

        [Fact]
        public void CharacterFound()
        {
            Task<Character> characterLuke = _characterManager.SearchCharacter(1);
            Assert.Equal("Luke Skywalker", characterLuke.Result.name);
        }

        [Fact]
        public void CharacterNotfound()
        {
            Assert.ThrowsAsync<CharacterNotFoundException>(() => _characterManager.SearchCharacter(99));
        }

        [Fact]
        public void AddRatingError()
        {
            Assert.Throws<ScoreOutOfRangeException>(() => _characterManager.RateCharacter(1,6));
        }
    }
}
