using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GA_ETS.DTO;

public class DadosCadastroUsuario
{
    [Required(ErrorMessage = "Turma é um campo obrigatório")]
    [Range(1, 100, ErrorMessage = "Turma deve ser entre 1 e 100")]
    public int Turma { get; set; }

    [Required(ErrorMessage = "EDV é um campo obrigatório")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "EDV deve conter 8 números")]
    public string Edv { get; set; }

    [Required(ErrorMessage = "Nome é um campo obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Senha é um campo obrigatório")]
    [MinLength(6, ErrorMessage = "Senha deve possuir no mínimo 6 caracteres")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Cor é um campo obrigatório")]
    [RegularExpression(@"^[a-zA-Z0-9]{6}$", ErrorMessage = "Cor deve conter 6 caracteres")]
    public string Cor { get; set; }
}