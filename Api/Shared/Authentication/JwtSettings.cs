using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Authentication
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public double ExpirationSeconds { get; set; }
    }
}
