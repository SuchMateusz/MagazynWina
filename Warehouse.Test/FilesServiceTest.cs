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
    public class FilesServiceTest
    {
        private List<Wine> listWine = new List<Wine>();
        private List<Beer> listBeer = new List<Beer>();

        [Fact]
        public void AddingFirstTestList_ProvidingTestListIsCompletedAdd_TheAdditionListIsCompleted()
        {
            //Arrange
            var mock = new Mock<FilesService>();
            var manager = new FilesService();
            //Act
            int iD = manager.AddingFirstTestList();
            //Assert
            iD.Should().BeGreaterThan(0);
        }

        [Fact]
        public void SavingToFile_ProvidingTestListSaveToFileIsCompleted_SaveListCompleted()
        {
            //Arrange
            listWine.Add(new Wine(1, "grape", 1, 15, 2017, 10, "Bayanus"));
            listWine.Add(new Wine(2, "redGrape", 1, 13, 2018, 35, "Bayanus"));
            listBeer.Add(new Beer(1, "FirstBeer", 2, 2020, 30, "yeast", "Pale Ale"));
            listBeer.Add(new Beer(2, "Second Beer", 5, 2020, 20, "yeast", "Special Biter"));
            var mock = new Mock<FilesService>();
            var manager = new FilesService();
            //Act
            string savedString = manager.SavingToFile(listWine, listBeer);
            //Assert
            savedString.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadWineFromFile_ProvidingTestListReadFromFileIsCompleted_ReadWineListIsCompleted()
        {
            //Arrange
            var mock = new Mock<FilesService>();
            var manager = new FilesService();
            //Act
            var readListWine = manager.ReadFromFileWine();
            //Assert
            readListWine.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadBeerFromFile_ProvidingTestListReadFromFileIsCompleted_ReadBeerListIsCompleted()
        {
            //Arrange
            var mock = new Mock<FilesService>();
            var manager = new FilesService();
            //Act
            var readListBeer = manager.ReadFromFileBeer();
            //Assert
            readListBeer.Should().NotBeEmpty();
        }
    }
}
