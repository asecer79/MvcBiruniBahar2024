using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.CommonEntities
{
    public class UserOperationClaim
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("OperationClaimId")]
        public int OperationClaimId { get; set; }

        [ForeignKey("OperationClaimId")]
        public OperationClaim? OperationClaim { get; set; }
    }
}
