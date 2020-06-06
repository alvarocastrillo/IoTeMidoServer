using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ENTIDADESDLL.Auth
{
    [Table("UserClaim")]
    public class AppUserClaim
    {
        [Required()]
        [Key()]
        public Guid ClaimId { get; set; }

        [Required()]
        public Guid UserId { get; set; }

        [Required()]
        public string ClaimType { get; set; }

        [Required()]
        public string ClaimValue { get; set; }
    }
}
