using IES_CREA.CORE.Entidades;

namespace IES_CREA.CORE.Interfaces
{
    public class IAutenticacionServicio
    {
        Task<Usuario>? ValidarCredencialesAsync(string usuario_, string password_);
        string GenererToken(Usuario usuario_, List<string> roles_);
    }
}
