using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AgendaTelefonica.Services
{

    public interface ICryptographyService
    {
        public string createHash(string value);
    }
    public class CryptographyService : ICryptographyService
    {
        private IConfiguration _configuration { get; set; }
        private readonly string _saltKey;
        public CryptographyService(IConfiguration configuration)
        {
            _configuration = configuration;
            _saltKey = _configuration.GetValue<string>("Secret:saltKey");
        }
        public string createHash(string value)
        {
            var textTempered = value + _saltKey;

            var md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(textTempered);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}