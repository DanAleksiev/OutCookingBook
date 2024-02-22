using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Data.Models
    {
    public class RecepiesUsers
        {
        [Required]
        public int RecepieId { get; set; }

        [ForeignKey(nameof(RecepieId))]
        public Recepie Recepie { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }

    }
