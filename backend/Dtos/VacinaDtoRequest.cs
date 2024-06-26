public class VacinaDtoRequest
{
    public string Name { get; set; }
    public string Lote { get; set; }
    public DateTime Validade { get; set; }
    public Guid PostoID { get; set; } 
}