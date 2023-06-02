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
        Beer beer = new Beer(0, "nameTest", 0, 0, 0, "yeast", "PaleAle");

        [Fact]
        public void AddNewBeer_ProvidingAddNewBeerComplete_AddingNewBeer()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var returnedBeerId = manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Assert
            Assert.Equal(beer.Id, returnedBeerId.Id);
        }
        [Fact]
        public void AddNewBeer_ProvidingAddNewBeerNotCompleted_ErrorAddingNewBeer()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var returnedBeer = manager.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeer.Should().BeNull();
        }
        [Fact]
        public void TestBeerRemoveById_ProvidingRemoveByIdCompleted_TestBeerRemoveByID()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var returnedBeerId = manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            manager.DeleteBeerFromList(beer.Id);
            var returnedBeerId2 = manager.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeerId2.Should().BeNull();
        }
        [Fact]
        public void TestBeerRemoveById_ProvidingRemoveBeerByIdNotCompleted_TestBeerRemoveByIDNotCompleted()
        {
            //Arrange
            Beer beer2 = new Beer(1, "nameTest3", 1, 50, 2021, "yeast", "PaleAle");
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var returnedBeerId = manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            var returnedBeerId2 = manager.AddNewBeerToList(beer2.Id, beer2.Name, beer2.Blg + 20, beer2.YearProduction, beer2.Quantity, beer2.Yeast, beer2.TypeOfBeer);
            manager.DeleteBeerFromList(beer2.Id);
            var returnedBeerId3 = manager.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeerId3.Id.Should().Be(beer.Id);
        }
        [Fact]
        public void TestBeerDetailById_ProviddingBeerShowsDetails_ShowingBeerDetails()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var returnedBeerId = manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            var returnedBeerId2 = manager.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeerId2.Id.Should().Be(beer.Id);
        }
        [Fact]
        public void TestBeeretailById_ProviddingBeerDontShowsDetails_DontShowingBeerDetails()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var returnedBeerId = manager.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeerId.Should().BeNull();
        }
        [Fact]
        public void TestUpdatesOBeerDetailsById_ProviddingUpdatesBeerDetails_UpdatesBeerDetails()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            manager.AddNewBeerToList(beer.Id+1, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            int newBeerId = 20;
            var beerId = manager.UpdateBeer(beer.Id+1, newBeerId, 5, 10);
            var returnedBeer = manager.GetBeerDetailsById(newBeerId);
            //Assert
            returnedBeer.Id.Should().Be(20);
            returnedBeer.Quantity.Should().Be(10);
            returnedBeer.Blg.Should().Be(5);
        }
        [Fact]
        public void TestUpdatesBeerDetailsById_ProviddingNotUpdatesBeerDetails_NotUpdatesBeerDetails()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            int newBeerId = 20;
            var beerId = manager.UpdateBeer(beer.Id + 1, newBeerId, 5, 10);
            var returnedBeer = manager.GetBeerDetailsById(newBeerId);
            //Assert
            returnedBeer.Should().BeNull();
        }
        [Fact]
        public void TestGetBeerById_ProviddingGetBeerDetailsById_DetailsBeerById()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            var beerTest = manager.GetBeerDetailsById(beer.Id);
            //Assert
            beerTest.Id.Should().Be(beer.Id);
            beerTest.Quantity.Should().Be(beer.Quantity);
            beerTest.Blg.Should().Be(beer.Blg);
        }
        [Fact]
        public void TestGetBeerById_ProviddingNotGetBeerDetailsById_DetailsBeerByIdIsntShowed()
        {
            //Arrange
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            var beerTest = manager.GetBeerDetailsById(1);
            //Assert
            beerTest.Should().BeNull();
        }
        [Fact]
        public void TestGetAllBeersObject_ProviddingGetAllBeersObjects_GetAllBeersObjects()
        {
            //Arrange
            Beer beerTest1 = new Beer(1, "nameTest1", 3, 20, 2020, "yeast", "PaleAle");
            Beer beerTest2 = new Beer(3, "nameTest3", 1, 50, 2021, "yeast", "PaleAle");
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            manager.AddNewBeerToList(beerTest1.Id, beerTest1.Name, beerTest1.Blg, beerTest1.YearProduction, beerTest1.Quantity, beerTest1.Yeast, beerTest1.TypeOfBeer);
            manager.AddNewBeerToList(beerTest2.Id, beerTest2.Name, beerTest2.Blg, beerTest2.YearProduction, beerTest2.Quantity, beerTest2.Yeast, beerTest2.TypeOfBeer);
            int id = manager.GetAllBeerObjects();
            //Assert
            id.Should().BeGreaterThan(0);
        }
        [Fact]
        public void TestGetNotAllBeersObject_ProviddingGetNoOneBeerObjects_GetNoOneBeerObjects()
        {
            //Arrange
            Beer beerTest1 = new Beer(1, "nameTest1", 3, 20, 2020, "yeast", "PaleAle");
            Beer beerTest2 = new Beer(3, "nameTest2", 1, 50, 2021, "yeast", "PaleAle");
            var mockBeer = new Mock<BeerService>();
            var manager = new BeerService();
            //Act
            int id = manager.GetAllBeerObjects();
            //Assert
            id.Should().Be(0);
        }
    }
}
