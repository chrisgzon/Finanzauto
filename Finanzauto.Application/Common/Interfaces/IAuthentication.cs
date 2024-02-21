namespace Finanzauto.Application.Common.Interfaces
{
    public interface IAuthentication
    {
        string Authenticate(string identificationStudent, string name);
    }
}