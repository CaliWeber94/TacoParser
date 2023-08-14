using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("31.570771, -84.10353, Taco Bell Albany...", -84.10353)]
        [InlineData("34.271508, -84.798907, Taco Bell Cartersville...", -84.798907)]
        [InlineData("32.524378, -84.88839, Taco Bell Columbus...", -84.88839)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line).Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }


        //TODO: Create a test ShouldParseLatitude

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("31.570771, -84.10353, Taco Bell Albany...", 31.570771 )]
        [InlineData("34.271508, -84.798907, Taco Bell Cartersville...", 34.271508)]
        [InlineData("32.524378, -84.88839, Taco Bell Columbus...", 32.524378)]
        public void ShouldParseLatitude(string line, double expected)
        {


            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line).Location.Latitude;
            //Assert
            Assert.Equal(expected, actual);

        }
    }
}