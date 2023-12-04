using AutoMapper;
using GA_ETS.Data;
using GA_ETS.DTO;
using GA_ETS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GA_ETS.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private GAETSContext context;
    private IMapper mapper;

    public UsuarioController(GAETSContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    /// <summary>
    /// Cadastra um novo usuário no banco de dados
    /// </summary>
    /// <param name="dadosCadastroUsuarioDTO">Dados necessários para criação de um Usuário</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Cadastro concluído com sucesso</response>
    [HttpPost]
    public IActionResult CadastrarUsuario([FromBody] DadosCadastroUsuario dadosCadastroUsuarioDTO )
    {
        try
        {
            Usuario usuario = mapper.Map<Usuario>(dadosCadastroUsuarioDTO);
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            return CreatedAtAction(nameof(DetalharUsuario), new { id = usuario.Id }, usuario);
        }
        catch (DbUpdateException e)
        {
            return BadRequest("EDV já cadastrado no banco de dados");
        }
        
    }

    [HttpGet("{id}")]
    public IActionResult DetalharUsuario([FromRoute] int id)
    {
        var usuario = context.Usuarios.FirstOrDefault(u => u.Id == id);

        if (usuario == null)
        {
            return NotFound();
        }

        var dadosUsuarioDTO = mapper.Map<DadosRetornoUsuario>(usuario);
        return Ok(dadosUsuarioDTO);
    }
}