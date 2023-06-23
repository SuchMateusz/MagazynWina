using MagazynWina.App;
using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Concrete;
using MagazynWina.App.Manager;
using MagazynWina.Domain.Model;
using FluentAssertions;
using Moq;
using Xunit;

namespace MagazynWina.Tests
{
    public class BeerServiceTest
    {
        [Fact]
        public void AddNewBeer_ProvidingAddNewBeerComplete_AddingNewBeer()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            //Act
            var returnedBeer = service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Assert
            Assert.Equal(beer.Id, returnedBeer.Id);
        }

        [Fact]
        public void TestBeerRemoveById_ProvidingRemoveByIdCompleted_TestBeerRemoveByID()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            service.DeleteBeerFromList(beer.Id);
            var returnedBeer = service.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeer.Should().BeNull();
        }

        [Fact]
        public void TestUpdatesOBeerDetailsById_ProviddingUpdatesBeerDetails_UpdatesBeerDetails()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            service.AddNewBeerToList(beer.Id+1, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            var beerId = service.UpdateBeer(beer.Id+1, beer.Name, 5, 10);
            var returnedBeer = service.GetBeerDetailsById(beerId);
            //Assert
            returnedBeer.Quantity.Should().Be(10);
            returnedBeer.Blg.Should().Be(5);
        }

        [Fact]
        public void TestBeerDetailsById_ProviddingBeerShowsDetailsById_ShowingBeerDetailsById()
        {
            //Arrange
            var service = new BeerService();
            Beer beer = GenerateNewBeerForTest();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act2
            var returnedBeer = service.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeer.Id.Should().Be(beer.Id);
            returnedBeer.Quantity.Should().Be(beer.Quantity);
            returnedBeer.Blg.Should().Be(beer.Blg);
        }

        [Fact]
        public void TestBeerDetailsById_ProviddingBeerDontShowsDetailsById_DontShowingBeerDetailsById()
        {
            //Arrange
            var service = new BeerService();
            int id = 10;
            //Act
            var returnedBeer = service.GetBeerDetailsById(id);
            //Assert
            returnedBeer.Should().BeNull();
        }

        [Fact]
        public void TestGetAllBeersObject_ProviddingGetAllBeersObjects_GetAllBeersObjects()
        {
            //Arrange
            Beer beerTest1 = new Beer(1, "nameTest1", 3, 20, 2020, "yeast", "PaleAle");
            Beer beerTest2 = new Beer(2, "nameTest3", 1, 50, 2021, "yeast", "PaleAle");
            var service = new BeerService();
            service.AddNewBeerToList(beerTest1.Id, beerTest1.Name, beerTest1.Blg, beerTest1.YearProduction, beerTest1.Quantity, beerTest1.Yeast, beerTest1.TypeOfBeer);
            service.AddNewBeerToList(beerTest2.Id, beerTest2.Name, beerTest2.Blg, beerTest2.YearProduction, beerTest2.Quantity, beerTest2.Yeast, beerTest2.TypeOfBeer);
            //Act
            int id = service.GetAllBeerObjects();
            //Assert
            id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void TestGetNotAllBeersObject_ProviddingGetNoOneBeerObjects_GetNoOneBeerObjects()
        {
            //Arrange
            Beer beerTest1 = new Beer(1, "nameTest1", 3, 20, 2020, "yeast", "PaleAle");
            Beer beerTest2 = new Beer(2, "nameTest2", 1, 50, 2021, "yeast", "PaleAle");
            var service = new BeerService();
            //Act
            int id = service.GetAllBeerObjects();
            //Assert
            id.Should().Be(0);
        }

        private Beer GenerateNewBeerForTest()
        {
            Beer beer = new Beer(0, "nameTest", 0, 0, 0, "yeast", "PaleAle");
            return beer;
        }
    }
}
