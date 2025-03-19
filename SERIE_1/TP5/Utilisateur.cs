using System.Text.Json.Serialization;

namespace TP5
{
    
        public class Utilisateur
        {
            [JsonPropertyName("login")]
            public string Login { get; set; }

            [JsonPropertyName("motDePasse")]
            public string MotDePasse { get; set; }

            [JsonPropertyName("estAdmin")]
            public bool EstAdmin { get; set; }

            public Utilisateur() { }

            public Utilisateur(string login, string motDePasse, bool estAdmin)
            {
                Login = login;
                MotDePasse = motDePasse;
                EstAdmin = estAdmin;
            }
        }
    
}
