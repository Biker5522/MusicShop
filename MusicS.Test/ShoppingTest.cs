using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MusicS.DataAccess;
using MusicS.DataAccess.Repository;
using MusicS.DataAccess.Repository.IRepository;
using MusicS.Models;
using System;
using Xunit;
using MusicShop.Controllers;

namespace MusicS.Test.Unit
{
    public class ShoppingTest 
    {

        //private readonly Mock<ApplicationDbContext> db = new Mock<ApplicationDbContext>();

        //[Fact]
        //public void AddAlbumTest()
        //{
        //     Mock<IGenreRepository> gen = new Mock<IGenreRepository>();
        //    gen.Setup()
        //GenreRepository repository = new GenreRepository(db.Object);
        //    repository.Add(new MusicS.Models.Genre() { Name = "TEST" });
        //    repository.Add(new MusicS.Models.Genre() { Name = "TEST" });
        //    GenreController controllerTest = new GenreController(gen.Object);
        //    Genre newBook = new Genre() { Id = 10, Name = "NEW" };
        //    ActionResult<Genre> actionResult = controllerTest.AddBook(newBook);
        //    Assert.Equal("NEW", repository.GetFirstOrDefault(3).Name);

        //}




        //[Fact]
        //public void Test()
        //{
        //    Mock<IUnitOfWork> unitMock = new Mock<IUnitOfWork>();
        //    //Arrange
        //    GenreController controller = new GenreController(unitMock.Object);
        //    int testNum = 5;

        //    //Act
        //    var result = controller.Delete(5);


        //    //Assert
        //    Assert.IsType<BadRequestResult>(result);

        //}



        //[Fact]
        //public void IncrementShoppingCart()
        //{
        //    // Arrange
        //    GenreController controller = new GenreController();

        //    Genre expected = new Genre()
        //    {
        //        Name = "test"
        //    };

        //    //Act
        //    Genre actual = controller.TestGet(3).Value;


        //    //Assert
        //    Assert.Equal(expected.Name, actual.Name);

        //}


        //[Fact]
        //public void IncrementShoppingCart()
        //{
        //    // Arrange
        //    var dbContext = new Mock<ApplicationDbContext>();
        //    var albumsSet = new Mock<DbSet<Album>>();
        //    albumsSet.Setup(x => x.Add(It.IsAny<Album>()));
        //    dbContext.Setup(x => x.Albums).Returns(albumsSet.Object);

        //    var albumsService = new AlbumRepository(dbContext.Object);

        //    Album album = new Album
        //    {
        //        Id = 1,
        //        Title = "EXAMPLE",
        //        Band = "Examples",
        //        ListPrice = 20,
        //        Price = 18,
        //        Price3 = 8,
        //        ImageUrl = "xxx",
        //        GenreId = 1
        //    };
        ////Act

        //if (album != null)
        //        albumsService.Update(album);
        //    else
        //        throw new Exception();


        //    //Assert

        //}

        //[Theory]
        //public void UserLogin(string expectedEmail, string expectedName)
        //{

        //    //Arrange
        //    var obslugaAccountStub = new Mock<ApplicationDbContext>();
        //    obslugaAccountStub.Setup(x => x.ApplicationUsers.Add(It.IsAny<ApplicationUser>())).Returns((ApplicationUser u)=>u);
        //    ShoppingCartRepository _controller = new ShoppingCartRepository(obslugaAccountStub.Object);

        //    var usersService = new UsersService(userContextMock.Object);
        //    //Act
        //    var applicationUser = usersService.AddUser(expectedEmail, expectedName);


        //    //Assert

        //    Assert.Equal(expectedEmail, applicationUser.Email);
        //    Assert.Equal(expectedName, applicationUser.Name);


        //    userContextMock.Verify(x => x.SaveChanges(), Times.Once);
        //}

    }
}
