using System.ComponentModel.DataAnnotations.Schema;

namespace api_brasileira_se.Models;

[Table("Estados")]
public class Estado 
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("sigla")]
    public string Sigla { get; set; } = string.Empty;
}