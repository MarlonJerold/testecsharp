using System.ComponentModel.DataAnnotations.Schema;

namespace backend.models;

public class Vacina
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Lote {get;set;}
    public DateTime Validade { get; set;}
    public Guid PostoId { get; set; }
    public Posto Posto { get; set; }

     
    public bool IsDataValidadeValida()
    {
        return Validade > DateTime.Today;
    }

    public void SetValidade(DateTime validade)
    {
        if (validade <= DateTime.Today)
        {
            throw new ArgumentException("A data de validade deve ser no futuro.");
        }
        Validade = validade;
    }
}
