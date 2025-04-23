using Bogus;
using FluentAssertions;
using Leilao.API.Communication.Requests;
using Leilao.API.Contracts;
using Leilao.API.Entities;
using Leilao.API.Services;
using Leilao.API.UseCases.Auctions.GetCurrent;
using Leilao.API.UseCases.Offers.CreateOffer;
using Moq;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //Arrange
        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 500)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        //Act
        var act = () => useCase.Execute(itemId, request);

        //Assert
        act.Should().NotThrow();
    }
}
