namespace backend.Dtos;

public record LoginDto
{
    public string Email {get; set;}
    public string Senha {get; set;}
}
