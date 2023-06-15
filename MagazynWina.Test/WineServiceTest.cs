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
            var service = new WineService();
            //Act
            var returnedWineId = service.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort) wine.Quantity, wine.Yeast);
            //Assert
            Assert.Equal(wine.Id, returnedWineId);
        }

        [Fact]
        public void TestWineRemoveById_ProvidingRemoveByIdCompleted_TestWineRemoveByID()
        {
            //Arrange
            var service = new WineService();
            service.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //Act
            service.DeleteWineFromList(wine.Id);
            var returnedWine = service.GetWineDetailsById(wine.Id);
            //Assert
            returnedWine.Should().BeNull();
        }

        [Fact]
        public void TestObjectDetailById_ProviddingObjectShowsDetails_ShowingObjectDetails()
        {
            //Arrange
            var service = new WineService();
            service.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //Act
            var returnedWine = service.GetWineDetailsById(wine.Id);
            //Assert
            returnedWine.Id.Should().Be(wine.Id);
            wine.Should().BeSameAs(returnedWine);
        }

        [Fact]
        public void TestUpdatesObjectDetailsById_ProviddingUpdatesObjectDetails_UpdatesObjectDetails()
        {
            //Arrange
            var service = new WineService();
            service.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //Act
            var wineId = service.UpdateWine(wine.Id, wine.Name, 5, 10);
            var returnedWine = service.GetWineDetailsById(wine.Id);
            //Assert
            returnedWine.Quantity.Should().Be(10);
            returnedWine.Blg.Should().Be(5);
        }

        //[Fact]
        //public void TestUpdatesObjectDetailsById_ProviddingNotUpdatesObjectDetails_NotUpdatesObjectDetails()
        //{
        //    //Arrange
        //    var service = new WineService();
        //    //service.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
        //    int newWineId = 20;
        //    //Act
        //    var wineId = service.UpdateWine(wine.Id, wine.Name, 5, 10);
        //    var returnedWine = service.GetWineDetailsById(wine.Id);
        //    //Assert
        //    returnedWine.Should().BeNull();
        //}

        [Fact]
        public void TestGetWineById_ProviddingGetWineDetailsById_DetailsWineById()
        {
            //Arrange
            Wine wine = new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus");
            var service = new WineService();
            service.AddNewWineToList(wine.Id, wine.Name, wine.TypeOfWine, (byte)wine.Blg, wine.YearProduction, (ushort)wine.Quantity, wine.Yeast);
            //Act

            var wine2 = service.GetWineDetailsById(wine.Id);
            //Assert
            wine2.Id.Should().Be(wine.Id);
            wine2.Quantity.Should().Be(wine.Quantity);
            wine2.Blg.Should().Be(wine.Blg);
        }

        [Fact]
        public void TestGetWineById_ProviddingNotGetWineDetailsById_DetailsWineByIdIsntShowed()
        {
            //Arrange
            var service = new WineService();
            int id = 2;
            //Act
            var wineTest = service.GetWineDetailsById(id);
            //Assert
            wineTest.Should().BeNull();
        }

        [Fact]
        public void TestGetAllWineObject_ProviddingGetAllWineObjects_GetAllWineObjects()
        {
            //Arrange
            Wine wineTest1 = new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus");
            Wine wineTest2 = new Wine(2, "apple", 2, 10, 2017, 23, "Tokay");
            var service = new WineService();
            service.AddNewWineToList(wineTest1.Id, wineTest1.Name, wineTest1.TypeOfWine, (byte)wineTest1.Blg, wineTest1.YearProduction, (ushort)wineTest1.Quantity, wineTest1.Yeast);
            service.AddNewWineToList(wineTest2.Id, wineTest2.Name, wineTest2.TypeOfWine, (byte)wineTest2.Blg, wineTest2.YearProduction, (ushort)wineTest2.Quantity, wineTest2.Yeast);
            //Act
            int id = service.GetAllWineObjects();
            //Assert
            id.Should().BeGreaterThan(0);
        }

        [Fact]
        public void TestGetNotAllWineObject_ProviddingGetNoOneWineObjects_GetNoOneWineObjects()
        {
            //Arrange
            var service = new WineService();
            //Act
            int id = service.GetAllWineObjects();
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
            var service = new WineService();
            //Act
            int neededSugar = service.SuggarForNewWine(addedSugar, litersOfWine, power);
            //Assert
            neededSugar.Should().BePositive();
        }

        [Fact]
        public void TestGetNumberOfSuggarToAdd_ProviddingWrongParametersToGetNumberSuggarIsWrong_NoSuggarAddToWine()
        {
            //Arrange
            int addedSugar = 5;
            int litersOfWine = 5;
            int power = 0;
            var service = new WineService();
            //Act
            int neededSugar = service.SuggarForNewWine(addedSugar, litersOfWine, power);
            //Assert
            neededSugar.Should().BeNegative();
        }
    }
}
