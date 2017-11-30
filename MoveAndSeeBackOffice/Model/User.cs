using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveAndSeeBackOffice.Model
{
    class User : ObservableObject
    {
        [JsonProperty("Id")]
        public string IdUser { get; set; }

        [JsonProperty("UserName")]
        public string Pseudo { get; set; }
        
        private bool _isCertified;
        [JsonProperty("IsCertified")]
        public bool IsCertified {
            get { return _isCertified; }
            set {
                if (_isCertified == value) {
                    return;
                }
                _isCertified = value;
                RaisePropertyChanged(() => IsCertified);
            }
        }

        [JsonProperty("NameCertified")]
        public string NameCertified { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        [JsonProperty("IsMale")]
        public bool? IsMale { get; set; }

        [JsonProperty("BirthDate")]
        public DateTime? BirthDate { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
        
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        
        
    }
}