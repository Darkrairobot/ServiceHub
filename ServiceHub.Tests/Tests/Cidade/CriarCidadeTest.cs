using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Moq;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Tests.Helpers;
using CriarCidadeHandler = ServiceHub.Api.Application.UseCase.Cidade.CriarCidade.Handler;
using CriarCidadeCommand = ServiceHub.Api.Application.UseCase.Cidade.CriarCidade.Command;



namespace ServiceHub.Tests.Tests.Cidade;

public class CriarCidadeTest
{
    [Fact]
    public async Task CriarCidade_RetornarFalha_QuandoNomeVazio()
    {
        
        //Arrange
        var repo = new Mock<ICidadeRepository>();
        var handler = new CriarCidadeHandler(repo.Object, FakeHttpContext.CriarHttpContextFake());
        var command = new CriarCidadeCommand(null, "SP", "14055660", "3543402");
        
        repo.Setup(x => x.ExisteCidadeAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        //Act
        var result = await handler.Handle(command);
        
        //Assert
        Assert.False(result.Success);
        Assert.Equal("E207", result.Error.Code);
    }
    
    [Fact]
    public async Task CriarCidade_RetornarFalha_QuandoUfVazio()
    {
        
        //Arrange
        var repo = new Mock<ICidadeRepository>();
        var handler = new CriarCidadeHandler(repo.Object, FakeHttpContext.CriarHttpContextFake());
        var command = new CriarCidadeCommand("Ribeirão Preto", null, "14055660", "3543402");
        
        repo.Setup(x => x.ExisteCidadeAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        //Act
        var result = await handler.Handle(command);
        
        //Assert
        Assert.False(result.Success);
        Assert.Equal("E208", result.Error.Code);
    }
    
    [Fact]
    public async Task CriarCidade_RetornarFalha_QuandoCepVazio()
    {
        
        //Arrange
        var repo = new Mock<ICidadeRepository>();
        var handler = new CriarCidadeHandler(repo.Object, FakeHttpContext.CriarHttpContextFake());
        var command = new CriarCidadeCommand("Ribeirão Preto", "SP", null, "3543402");
        
        repo.Setup(x => x.ExisteCidadeAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        //Act
        var result = await handler.Handle(command);
        
        //Assert
        Assert.False(result.Success);
        Assert.Equal("E209", result.Error.Code);
    }
    
    [Fact]
    public async Task CriarCidade_RetornarFalha_QuandoIbgeVazio()
    {
        
        //Arrange
        var repo = new Mock<ICidadeRepository>();
        var handler = new CriarCidadeHandler(repo.Object, FakeHttpContext.CriarHttpContextFake());
        var command = new CriarCidadeCommand("Ribeirão Preto", "SP", "14055660", null);
        
        repo.Setup(x => x.ExisteCidadeAsync(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        //Act
        var result = await handler.Handle(command);
        
        //Assert
        Assert.False(result.Success);
        Assert.Equal("E210", result.Error.Code);
    }
    
    

    [Fact]
    public async Task CriarCidade_RetornarFalha_QuandoCidadeExiste()
    {
        //Arrange
        var repo = new Mock<ICidadeRepository>();
        var handler = new CriarCidadeHandler(repo.Object, FakeHttpContext.CriarHttpContextFake());
        var command = new CriarCidadeCommand("Ribeirão Preto", "SP", "14055660", "3543402");
        
        repo.Setup(x => x.ExisteCidadeAsync("3543402"))
            .ReturnsAsync(true);
        
        
        //Act
        var result = await handler.Handle(command);
        
        //Assert
        Assert.False(result.Success);
    }

    [Fact]
    public async Task CriarCidade_RetornarSucesso_QuandoCidadeValida()
    {
        //Arrange
        var repo = new Mock<ICidadeRepository>();
        var handler = new CriarCidadeHandler(repo.Object, FakeHttpContext.CriarHttpContextFake());
        var command = new CriarCidadeCommand("Ribeirão Preto", "SP", "14055660", "3543402");
        
        repo.Setup(x => x.ExisteCidadeAsync("3543402"))
            .ReturnsAsync(false);
        
        //Act
        var result = await handler.Handle(command);
        
        //Assert
        Assert.True(result.Success);
    }
}