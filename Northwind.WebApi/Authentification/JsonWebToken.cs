namespace Northwind.WebApi.Authentification
{
    public class JsonWebToken
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public int Éxpires_in { get; set; }
        public string Refresh_Token { get; set; }
    }
}
