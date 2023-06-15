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
            var service = new BeerService();
            //Act
            var returnedBeerId = service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Assert
            Assert.Equal(beer.Id, returnedBeerId.Id);
        }

        //[Fact]
        //public void AddNewBeer_ProvidingAddNewBeerNotCompleted_ErrorAddingNewBeer()
        //{
        //    //Arrange
        //    var service = new BeerService();
        //    //Act
        //    var returnedBeer = service.GetBeerDetailsById(beer.Id);
        //    //Assert
        //    returnedBeer.Should().BeNull();
        //}

        [Fact]
        public void TestBeerRemoveById_ProvidingRemoveByIdCompleted_TestBeerRemoveByID()
        {
            //Arrange
            var service = new BeerService();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            service.DeleteBeerFromList(beer.Id);
            var returnedBeerId = service.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeerId.Should().BeNull();
        }

        //[Fact]
        //public void TestBeerRemoveById_ProvidingRemoveBeerByIdNotCompleted_TestBeerRemoveByIDNotCompleted()
        //{
        //    //Arrange
        //    var service = new BeerService();
        //    var returnedBeerId = service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
        //    //Act
        //    service.DeleteBeerFromList(beer.Id);
        //    var returnedBeerId3 = service.GetBeerDetailsById(beer.Id);
        //    //Assert
        //    returnedBeerId3.Id.Should().Be(beer.Id);
        //}

        [Fact]
        public void TestBeerDetailById_ProviddingBeerShowsDetails_ShowingBeerDetails()
        {
            //Arrange
            var service = new BeerService();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act2
            var returnedBeerId2 = service.GetBeerDetailsById(beer.Id);
            //Assert
            returnedBeerId2.Id.Should().Be(beer.Id);
        }

        [Fact]
        public void TestBeeretailById_ProviddingBeerDontShowsDetails_DontShowingBeerDetails()
        {
            //Arrange
            var service = new BeerService();
            int id = 10;
            //Act
            var returnedBeerId = service.GetBeerDetailsById(id);
            //Assert
            returnedBeerId.Should().BeNull();
        }

        [Fact]
        public void TestUpdatesOBeerDetailsById_ProviddingUpdatesBeerDetails_UpdatesBeerDetails()
        {
            //Arrange
            var service = new BeerService();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            var beerId = service.UpdateBeer(beer.Id, beer.Name, 5, 10);
            var returnedBeer = service.GetBeerDetailsById(beerId);
            //Assert
            beerId.Should().Be(beer.Id);
            returnedBeer.Quantity.Should().Be(10);
            returnedBeer.Blg.Should().Be(5);
        }

        //[Fact]
        //public void TestUpdatesBeerDetailsById_ProviddingNotUpdatesBeerDetails_NotUpdatesBeerDetails()
        //{
        //    Arrange
        //    var mockBeer = new Mock<BeerService>();
        //    var manager = new BeerService();
        //    manager.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
        //    int newBeerId = 20;
        //    Act
        //    var beerId = manager.UpdateBeer(beer.Id, beer.Name, 5, 10);
        //    var returnedBeer = manager.GetBeerDetailsById(newBeerId + 1);
        //    Assert
        //    returnedBeer.Should().BeNull();
        //}

        [Fact]
        public void TestGetBeerById_ProviddingGetBeerDetailsById_DetailsBeerById()
        {
            //Arrange
            var service = new BeerService();
            service.AddNewBeerToList(beer.Id, beer.Name, beer.Blg, beer.YearProduction, beer.Quantity, beer.Yeast, beer.TypeOfBeer);
            //Act
            var beerTest = service.GetBeerDetailsById(beer.Id);
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
            var service = new BeerService();
            //Act
            var beerTest = service.GetBeerDetailsById(61);
            //Assert
            beerTest.Should().BeNull();
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
    }
}
