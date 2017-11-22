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
        [JsonProperty("IdUser")]
        public long IdUser { get; set; }

        [JsonProperty("Pseudo")]
        public string Pseudo { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }


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

        [JsonProperty("IsAdmin")]
        public bool IsAdmin { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}