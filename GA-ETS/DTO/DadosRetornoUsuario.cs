using System.ComponentModel.DataAnnotations;

namespace GA_ETS.DTO;

public class DadosRetornoUsuario
{
    public int Id { get; set; }
    public int Turma { get; set; }
    public string Edv { get; set; }
    public string Nome { get; set; }
    public string Cor { get; set; }
}