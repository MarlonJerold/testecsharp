using System.ComponentModel.DataAnnotations.Schema;

namespace backend.models;

public class Usuario
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
