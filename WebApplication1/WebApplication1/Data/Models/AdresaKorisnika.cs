using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Data.Models
{
    public partial class AdresaKorisnika
    {
        //public AdresaKorisnika()
        //{
        //    Korisnici = new HashSet<Korisnik>();
        //}
        [Key]
        public int AdresaKorisnikaId { get; set; }
        public string NazivUlice { get; set; } = null!;
        [ForeignKey(nameof(Grad))]
        public int GradId { get; set; }
        public virtual Grad Grad { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Korisnik> Korisnici { get; set; }
    }
}
