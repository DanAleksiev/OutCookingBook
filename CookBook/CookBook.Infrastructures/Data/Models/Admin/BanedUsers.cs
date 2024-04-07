using CookBook.Constants;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.Infrastructures.Data.Models.Admin
    {
    public class BanedUsers
        {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;

        public bool IsBaned { get; set; }

        [Required]
        [Description("The amount of DAYS the user will be baned for")]
        public int Lenght { get; set; }

        public DateTime BanDate { get; set; }

        [Required]
        [StringLength(LenghtParams.BanReasonMaxLenght, MinimumLength = LenghtParams.BanReasonMinLenght)]
        public string Reason { get; set; } = string.Empty;
        }
    }
