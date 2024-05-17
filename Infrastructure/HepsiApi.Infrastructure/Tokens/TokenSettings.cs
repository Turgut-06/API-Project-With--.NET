using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Infrastructure.Tokens
{
    public class TokenSettings //bunu oluşturarak appsettings üzerindeki kısımları configure edilebir hale getiriyorum
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string Secret { get; set; }
        public int TokenValidityInMunitues { get; set; }

    }
}
