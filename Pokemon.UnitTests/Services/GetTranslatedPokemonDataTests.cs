namespace Pokemon.UnitTests.Services
{
    using AutoFixture;
    using FluentAssertions;
    using Moq;
    using Pokemon.DTO;
    using Pokemon.Helpers;
    using Pokemon.Repositories;
    using Pokemon.Services;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class GetTranslatedPokemonDataTests
    {
        private readonly PokemonDataService pokemonDataService;
        private readonly Mock<IPokemonDataRepository> mockPokemonDataRepository;
        private readonly Mock<IPokemonDataParser> mockPokemonDataParser;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTranslatedPokemonDataTests"/> class.
        /// </summary>
        public GetTranslatedPokemonDataTests()
        {
            this.mockPokemonDataRepository = new Mock<IPokemonDataRepository>();
            this.mockPokemonDataParser = new Mock<IPokemonDataParser>();
            this.pokemonDataService = new PokemonDataService(this.mockPokemonDataRepository.Object, this.mockPokemonDataParser.Object);
        }

        /// <summary>
        /// Tests that description is translated to yoda language if habitat is cave.
        /// </summary>
        [Fact]
        public async Task GetTranslatedPokemonData_GetsYodaTranslation_IfHabitatIsCave()
        {
            // Arrange
            Fixture fixture = new Fixture();
            string pokemonName = fixture.Create<string>();
            TranslationResponse translation = fixture.Create<TranslationResponse>();
            PokemonSpeciesData speciesData = fixture.Create<PokemonSpeciesData>();
            PokemonData data = fixture.Create<PokemonData>();
            data.Habitat = "cave";
            data.Description = pokemonName;

            this.mockPokemonDataRepository.Setup(x => x.GetPokemonData(pokemonName))
                .ReturnsAsync(speciesData);
            this.mockPokemonDataParser.Setup(x => x.BuildPokemonData(speciesData))
                .Returns(data);
            this.mockPokemonDataRepository.Setup(x => x.GetTranslation(data.Description, "yoda"))
                .ReturnsAsync(translation);

            // Act
            PokemonData response = await this.pokemonDataService.GetTranslatedPokemonData(pokemonName);

            // Assert
            this.mockPokemonDataRepository.Verify(x => x.GetTranslation(pokemonName, "yoda"), Times.Once());
            response.Description.Should().BeEquivalentTo(translation.Contents.Translated);
        }

        /// <summary>
        /// Tests that GetTranslatedPokemonData still returns untranslated data in the even of a GetTranslation exception.
        /// </summary>
        [Fact]
        public async Task GetTranslatedPokemonData_ReturnsData_IfGetTranslationThrowsException()
        {
            // Arrange
            Fixture fixture = new Fixture();
            string pokemonName = fixture.Create<string>();
            PokemonSpeciesData speciesData = fixture.Create<PokemonSpeciesData>();
            PokemonData data = fixture.Create<PokemonData>();
            data.Habitat = "cave";

            this.mockPokemonDataRepository.Setup(x => x.GetPokemonData(pokemonName))
                .ReturnsAsync(speciesData);
            this.mockPokemonDataParser.Setup(x => x.BuildPokemonData(speciesData))
                .Returns(data);
            this.mockPokemonDataRepository.Setup(x => x.GetTranslation(data.Description, "yoda"))
                .Throws(new Exception());

            // Act
            PokemonData response = await this.pokemonDataService.GetTranslatedPokemonData(pokemonName);

            // Assert
            response.Should().BeEquivalentTo(data);
        }

        //TODO : Test all other cases.
    }
}
