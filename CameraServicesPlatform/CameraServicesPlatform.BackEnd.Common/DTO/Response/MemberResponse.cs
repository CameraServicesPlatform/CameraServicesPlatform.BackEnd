using CameraServicesPlatform.BackEnd.Domain.Enum.Account;
using CameraServicesPlatform.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraServicesPlatform.BackEnd.Domain.Models;

namespace CameraServicesPlatform.BackEnd.Common.DTO.Response
{
    public class MemberResponse
    {
        public string MemberID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public JobStatus? Job { get; set; }
        public HobbyStatus? Hobby { get; set; }
        public Gender Gender { get; set; }
        public DateTime Dob { get; set; }
        public bool IsAdult { get; set; }
        public double Money { get; set; }
        public string? AccountID { get; set; }

        public AccountResponse Account { get; set; }

        public DateTime JoinedAt { get; set; }
        public string Img { get; set; } = null!;
    }
}
