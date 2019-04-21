namespace Atestados.Domain.Interfaces.Services
{
    public interface ICryptServices
    {
        string Criptografar(string caracteres);

        bool Equals(string crypt, string compare);
    }
}
