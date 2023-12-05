using AutoMapper;
using GA_ETS.Data;

namespace GA_ETS.Services;

public class UsuarioService
{
    private GAETSContext context;

    public UsuarioService(GAETSContext context)
    {
        this.context = context;
    }

    public IEnumerable<int> ObterTurmasDistintas()
    {
        using (context)
        {
            var turmas = context.Usuarios.Select(u => u.Turma).Distinct().ToList();
            return turmas;
        }
    }
}