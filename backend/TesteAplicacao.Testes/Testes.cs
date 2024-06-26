using AutoMapper;
using backend.Data;
using backend.Dtos;
using backend.models;
using backend.Repositorio;
using backend.Services;
using backend.Services.PostoServices;
using Moq;
using Xunit;

namespace TesteAplicacao.Testes;

public class Testes
{

     [Fact]
    public async Task AtualizarPosto_DeveAtualizarNomeCorretamente()
    {
        // Arrange
        var postoRepositoryMock = new Mock<IPostoRepository>();
        var postoContextMock = new Mock<PostoContext>(); 
        var mapperMock = new Mock<IMapper>(); 
        
        var postoService = new PostoService(postoRepositoryMock.Object, postoContextMock.Object, mapperMock.Object);

        var postId = Guid.NewGuid();
        var novoNome = "Novo Nome";

        postoRepositoryMock.Setup(repo => repo.UpdatePostoAsync(postId, novoNome))
                          .Returns(Task.CompletedTask);

        // Act
        await postoService.AtualizarPosto(postId, novoNome);

        // Assert
        postoRepositoryMock.Verify(repo => repo.UpdatePostoAsync(postId, novoNome), Times.Once);
    }

    [Fact]
    public async Task DeletePostoAsync_DeveExcluirPostoCorretamente()
    {
        // Arrange
        var postoRepositoryMock = new Mock<IPostoRepository>();
        var postoContextMock = new Mock<PostoContext>(); 
        var mapperMock = new Mock<IMapper>(); 
        
        var postoService = new PostoService(postoRepositoryMock.Object, postoContextMock.Object, mapperMock.Object);

        var postId = Guid.NewGuid();

        postoRepositoryMock.Setup(repo => repo.DeletePostoAsync(postId))
                          .Returns(Task.CompletedTask);

        // Act
        await postoService.DeletePostoAsync(postId);

        // Assert
        postoRepositoryMock.Verify(repo => repo.DeletePostoAsync(postId), Times.Once);
    }
     [Fact]
    public async Task ObterPostoPorId_DeveRetornarPostoCorreto()
    {
        // Arrange
        var postoRepositoryMock = new Mock<IPostoRepository>();
        var postoContextMock = new Mock<PostoContext>(); 
        var mapperMock = new Mock<IMapper>(); 
        
        var postoService = new PostoService(postoRepositoryMock.Object, postoContextMock.Object, mapperMock.Object);

        var postId = Guid.NewGuid();
        var postoEsperado = new Posto {
                Id = Guid.NewGuid(), 
                Name = "Posto de Saúde Central",
                Vacinas = new List<Vacina>
            {
                new Vacina { Id = Guid.NewGuid(), Name = "Vacina A" },
                new Vacina { Id = Guid.NewGuid(), Name = "Vacina B" }
            }
        };

        
        postoRepositoryMock.Setup(repo => repo.GetPostoByIdAsync(postId))
                          .ReturnsAsync(postoEsperado);

        // Act
        var resultado = await postoService.ObterPostoPorId(postId);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(postoEsperado.Id, resultado.Id);
        // Adicione mais asserts conforme necessário
    }
    [Fact]
    public async Task ObterTodosOsPostos_DeveRetornarListaDePostos()
    {
        // Arrange
        var postoRepositoryMock = new Mock<IPostoRepository>();
        var postoContextMock = new Mock<PostoContext>(); // Mock do contexto, se necessário
        var mapperMock = new Mock<IMapper>(); // Mock do AutoMapper, se necessário
        
        var postoService = new PostoService(postoRepositoryMock.Object, postoContextMock.Object, mapperMock.Object);

        var listaDePostos = new List<Posto>
        {
            new Posto { Id = Guid.NewGuid(), /* preencher com dados simulados */ },
            new Posto { Id = Guid.NewGuid(), /* preencher com dados simulados */ },
            new Posto { Id = Guid.NewGuid(), /* preencher com dados simulados */ }
        };

        postoRepositoryMock.Setup(repo => repo.GetPostosAsync())
                          .ReturnsAsync(listaDePostos);

        // Act
        var resultado = await postoService.ObterTodosOsPostos();

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(listaDePostos.Count, resultado.Count);
    }
        [Fact]
    public async Task Add_DeveAdicionarUsuario()
    {
        // Arrange
        var usuarioRepositoryMock = new Mock<IUsuarioRepository>(); 
        var usuarioService = new UsuarioService(usuarioRepositoryMock.Object); 

        var novoUsuario = new Usuario { Id = Guid.NewGuid(), Nome = "Usuário Teste" };

        usuarioRepositoryMock.Setup(repo => repo.AddUsuario(novoUsuario))
                             .Returns(Task.CompletedTask);

        // Act
        await usuarioService.Add(novoUsuario);

        // Assert
        usuarioRepositoryMock.Verify(repo => repo.AddUsuario(novoUsuario), Times.Once);
    }
    [Fact]
    public async Task GetUsuarioPorID_DeveRetornarUsuarioExistente()
    {
        // Arrange
        var usuarioRepositoryMock = new Mock<IUsuarioRepository>(); // Mock do repositório
        var usuarioService = new UsuarioService(usuarioRepositoryMock.Object); // Serviço a ser testado

        var usuarioExistente = new Usuario { Id = Guid.NewGuid(), Nome = "Usuário Teste" };

        usuarioRepositoryMock.Setup(repo => repo.GetUsuarioPorID(1))
                             .ReturnsAsync(usuarioExistente);

        // Act
        var resultado = await usuarioService.GetUsuarioPorID(1);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(usuarioExistente.Id, resultado.Id);
        Assert.Equal(usuarioExistente.Nome, resultado.Nome);
    }
}