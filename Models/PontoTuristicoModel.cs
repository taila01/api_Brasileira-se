using System.ComponentModel.DataAnnotations.Schema;

namespace api_brasileira_se.Models;

[Table("PontoTuristico")]
public class PontoTuristico 
{
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    public string Nome { get; set; } = string.Empty;

    [Column("descricao")]
    public string Descricao { get; set; } = string.Empty;

    [Column("localizacao")]
    public string Localizacao { get; set; } = string.Empty;

    [Column("cidade")]
    public string Cidade { get; set; } = string.Empty;

    [Column("estado")]
    public string Estado { get; set; } = string.Empty;

    [Column("dt_inclusao")]
    public DateTime DataInclusao { get; set; }
}