using MagazynWina.App;
using MagazynWina.App.AbstractInteface;
using MagazynWina.App.Concrete;
using MagazynWina.App.Manager;
using MagazynWina.Domain.Model;
using FluentAssertions;
using Moq;
using Xunit;


namespace Warehouse.Test
{
    public class UnitTest1
    {
        [Fact]
        public void testWineDetailById()
        {
            //Arrange
            Wine wine = new Wine();
            var mock = new Mock<IService<Wine>>();
            //new Mock<IService<Wine>>();
            mock.Setup(s => s.wineDetail(0)).Returns(wine);
            var manager = new WineAppControl(new MenuActionService(), mock.Object);
            //Act
            var returnedWine = manager.WineDetailId(wine.Id);
            //Assert
            Assert.Equal(wine, returnedWine);
        }

        [Fact]
        public void testWineRemoveById()
        {
            //Arrange
            Wine wine = new Wine();
            IService<Wine> wineService = new WineService();
            wineService.AddWine(wine);
            var manager = new WineAppControl(new MenuActionService(), wineService);
            //Act
            wineService.DeleteWine(wine);
            //Assert
            wineService.wineDetail(wine.Id).Should().BeNull();
        }

        [Fact]

        public void testUpdateWineById()
        {
            //Arrange
            Wine wine = new Wine();
            IService<Wine> wineService = new WineService();
            wineService.AddWine(wine);
            var manager = new WineAppControl(new MenuActionService(), wineService);
            
            //Act
            wineService.UpdateWineTestID(wine);
            //Assert
            var testWine = wineService.wineDetail(wine.Id);
            wineService.wineDetail(1).Should().BeNull();
            
            testWine.Id.Should().Be(10);
            testWine.Blg.Should().Be(10);
            testWine.Quantity.Should().Be(15);

        }
        [Fact]
        public void readFromFile()
        {
            //Arange
            var mock = new Mock<IService<Wine>>();
            var _listWineService = new ListWineService(mock.Object);

            //Act
            var listTest1 = _listWineService.readerFromFile();

            //Assert
            listTest1.Should().NotBeNull();
        }

        //[Fact]
        //public void saveToFile()
        //{
        //    //Arrange

        //    //Act
            
        //    //Assert

        //}

    }
}