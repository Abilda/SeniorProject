using System;
using System.Collections.Generic;

#nullable disable

namespace IdentityProvider.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
