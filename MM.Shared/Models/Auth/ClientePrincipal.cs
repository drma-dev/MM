﻿using MM.Shared.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace MM.Shared.Models.Auth
{
    public class ClientePrincipal : PrivateMainDocument
    {
        public ClientePrincipal() : base(DocumentType.Principal)
        {
        }

        public string? UserId { get; set; }
        public string? IdentityProvider { get; set; }
        public string? UserDetails { get; set; }
        public string[] UserRoles { get; set; } = Array.Empty<string>();

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public override void Initialize(string userId)
        {
            base.Initialize(userId);
            UserId = userId;
        }

        public override bool HasValidData()
        {
            if (string.IsNullOrEmpty(UserId)) return false;
            if (string.IsNullOrEmpty(IdentityProvider)) return false;
            if (string.IsNullOrEmpty(UserDetails)) return false;
            if (!UserRoles.Any()) return false;
            if (UserId != Key) return false;

            return true;
        }
    }
}