using MagazynWina.App;
using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Concrete;
using MagazynWina.App.Manager;
using MagazynWina.Domain.Model;
using FluentAssertions;
using Moq;
using Xunit;
using System.Security.Cryptography;

namespace MagazynWina.Tests
{
    public class WineServiceTest
    {
        Wine wine = new Wine(0, "nameTest", 0, 0, 0, 0, "yeast");

        [Fact]
        public void AddNewWine_ProvidingAddNewWineComplete_AddingNewWine()
        {
            //Arrange
            //Wine wine = new Wine();
            var mockWine = new Mock<WineService>();
            var mockBeer = new Mock<BeerService>();
            //var manager = new WineAppControl(new MenuActionService(), mockWine.Object, mockBeer.Object);
            var manager = new WineService();
            //Act
            var returnedWineId2 = manager.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //Assert
            Assert.Equal(wine.Id, returnedWineId2);
        }
        [Fact]
        public void AddNewWine_ProvidingAddNewWineNotCompleted_ErrorAddingNewWine()
        {
            //Arrange
            Wine wine = new Wine(2, "nameTest", 0, 20, 0, 0, "yeast");
            var mockWine = new Mock<WineService>();
            var mockBeer = new Mock<BeerService>();
            var manager = new WineService();
            //Act
            var returnedWineId2 = manager.AddNewWineToList(wine.Id+2, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            var returnedWine = manager.GetWineDetailsById(wine.Id);
            //Assert
            returnedWineId2.Should().Be(4);
            returnedWineId2.Should().BePositive();
        }

        [Fact]
        public void TestWineRemoveById_ProvidingRemoveByIdCompleted_TestWineRemoveByID()
        {
            //Arrange
            var mockWine = new Mock<WineService>();
            var mockBeer = new Mock<BeerService>();
            var manager2 = new WineService();
            //Act
            var returnedWineId = manager2.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            manager2.DeleteWineFromList(wine.Id);
            var returnedWineId2 = manager2.GetWineDetailsById(wine.Id);
            //Assert
            returnedWineId2.Should().BeNull();
        }
        [Fact]
        public void TestWineRemoveById_ProvidingRemoveByIdNotCompleted_TestWineRemoveByIDNotCompleted()
        {
            //Arrange
            var mockWine = new Mock<WineService>();
            var manager2 = new WineService();
            //Act
            var returnedWineId = manager2.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            var returnedWineId3 = manager2.AddNewWineToList(wine.Id+1, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            var returnedWineId4 = manager2.AddNewWineToList(wine.Id+2, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            manager2.DeleteWineFromList(wine.Id+1);
            var returnedWineId2 = manager2.GetWineDetailsById(wine.Id);
            //Assert
            Assert.Equal(wine.Id, returnedWineId);
            returnedWineId2.Id.Should().Be(wine.Id);
        }
        [Fact]
        public void TestObjectDetailById_ProviddingObjectShowsDetails_ShowingObjectDetails()
        {
            //Arrange
            //Wine wine = new Wine();
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            var wineId = manager.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //manager.DeleteWineFromList(wine.Id);
            var returnedWineId = manager.GetWineDetailsById(wine.Id);
            //Assert
            returnedWineId.Id.Should().Be(wine.Id);
        }
        [Fact]
        public void TestObjectDetailById_ProviddingObjectDontShowsDetails_DontShowingObjectDetails()
        {
            //Arrange
            //Wine wine = new Wine();
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            var wineId = manager.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //manager.DeleteWineFromList(wine.Id);
            var returnedWineId = manager.GetWineDetailsById(wine.Id+2);
            //Assert
            returnedWineId.Should().BeNull();
        }
        [Fact]
        public void TestUpdatesObjectDetailsById_ProviddingUpdatesObjectDetails_UpdatesObjectDetails()
        {
            //Arrange
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            manager.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            var wineId = manager.UpdateWine(wine.Id, 5, 10);
            var returnedWineId = manager.GetWineDetailsById(wine.Id);
            //Assert

            returnedWineId.Quantity.Should().Be(10);
            returnedWineId.Blg.Should().Be(5);
        }
        [Fact]
        public void TestUpdatesObjectDetailsById_ProviddingNotUpdatesObjectDetails_NotUpdatesObjectDetails()
        {
            //Arrange
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            manager.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            var wineId = manager.UpdateWine(wine.Id + 1, 5, 10);
            var returnedWineId = manager.GetWineDetailsById(wine.Id+1);
            //Assert
            returnedWineId.Should().BeNull();
        }
        [Fact]
        public void TestGetWineById_ProviddingGetWineDetailsById_DetailsWineById()
        {
            //Arrange
            Wine wine = new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus");
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            manager.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            var wine2 = manager.GetWineDetailsById(wine.Id);
            //Assert
            wine2.Id.Should().Be(wine.Id);
            wine2.Quantity.Should().Be(wine.Quantity);
            wine2.Blg.Should().Be(wine.Blg);
        }
        [Fact]
        public void TestGetWineById_ProviddingNotGetWineDetailsById_DetailsWineByIdIsntShowed()
        {
            //Arrange
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            var wine2 = manager.GetWineDetailsById(2);
            //Assert
            wine2.Should().BeNull();
        }
        [Fact]
        public void TestGetAllWineObject_ProviddingGetAllWineObjects_GetAllWineObjects()
        {
            //Arrange
            Wine wineTest1 = new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus");
            Wine wineTest2 = new Wine(2, "apple", 2, 10, 2017, 23, "Tokay");
            var mock = new Mock<WineService>();
            var manager = new WineService();
            //Act
            manager.AddNewWineToList(wineTest1.Id, wineTest1.Name, wineTest1.TypeOfWine, (byte)wineTest1.Blg, wineTest1.YearProduction, (ushort)wineTest1.Quantity, wineTest1.Yeast);
            manager.AddNewWineToList(wineTest2.Id, wineTest2.Name, wineTest2.TypeOfWine, (byte)wineTest2.Blg, wineTest2.YearProduction, (ushort)wineTest2.Quantity, wineTest2.Yeast);
            int id = manager.GetAllWineObjects();
            //Assert
            id.Should().BeGreaterThan(0);
        }
        [Fact]
        public void TestGetNotAllWineObject_ProviddingGetNoOneWineObjects_GetNoOneWineObjects()
        {
            //Arrange
            Wine wineTest1 = new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus");
            Wine wineTest2 = new Wine(2, "apple", 2, 10, 2017, 23, "Tokay");
            var mock = new Mock<WineService>();
            var manager = new WineService();
            //Act
            int id = manager.GetAllWineObjects();
            //Assert
            id.Should().Be(0);
        }
        [Fact]
        public void TestGetNumberOfSuggarToAdd_ProviddingGetNumberSuggar_NumberSuggarAddToWine()
        {
            //Arrange
            int addedSugar = 5;
            int litersOfWine = 25;
            int power = 10;
            int neededSugar;
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            neededSugar = manager.SuggarForNewWine(addedSugar, litersOfWine, power);
            //Assert
            neededSugar.Should().BePositive();
        }
        [Fact]
        public void TestGetNumberOfSuggarToAdd_ProviddingWrongParametersToGetNumberSuggarIsWrong_NoSuggarAddToWine()
        {
            //Arrange
            int addedSugar = 5;
            int litersOfWine = 0;
            int power = 10;
            int neededSugar;
            var mockWine = new Mock<WineService>();
            var manager = new WineService();
            //Act
            neededSugar = manager.SuggarForNewWine(addedSugar, litersOfWine, power);
            //Assert
            neededSugar.Should().BeNegative();
        }
    }
}
