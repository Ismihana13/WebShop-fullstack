
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Models;
using WebApplication1.Endpoints.Korisnik.Controllers;
using WebApplication1.Helper.AutentifikacijaAutorizacija;
using WebApplication1.SignalR;
using WebApplication5.KorisnikModul.ViewModels;


namespace WebApplication5.KorisnikModul.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class KorisnikController:ControllerBase
  {
    private ApplicationDbContext _dbContext;
    private readonly IHubContext<SignalRHub> _hubContext;
    public KorisnikController(ApplicationDbContext dbContext, IHubContext<SignalRHub> hubContext)
    {
      _dbContext = dbContext;
      _hubContext = hubContext;
    }
    [HttpPost]
    public ActionResult Add([FromBody]RegistracijaVM registracijaVM)
    {
      var noviKorisnik = new Korisnik()
      {
        Ime = registracijaVM.Ime,
        Prezime = registracijaVM.Prezime,
        Email = registracijaVM.Email,
          AdresaKorisnikaId = registracijaVM.AdresaKorisnikaId,
          AdresaZaDostavuId = registracijaVM.AdresaZaDostavuId,
        KorisnickoIme = registracijaVM.Username,
        Lozinka = registracijaVM.Password,
          
      };
      _dbContext.Korisnik.Add(noviKorisnik);
      _dbContext.SaveChanges();
      return Ok(noviKorisnik.Id);
    }


        //    [HttpPost("{id}")]
        //    public ActionResult AddProfileImage(int id, [FromForm] KorisnikAddSlikaVM x)
        //    {
        //        Korisnik korisnik = _dbContext.Korisnik.FirstOrDefault(s => s.Id == id);

        //        if (korisnik == null)
        //            return BadRequest("neispravan korisnik ID");
        //        if (x.slika.Length > 300 * 1000)
        //            return BadRequest("max velicina fajla je 300 KB");

        //        string ekstenzija = Path.GetExtension(x.slika.FileName);

        //        var filename = $"{Guid.NewGuid()}{ekstenzija}";

        //        x.slika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
        //        korisnik.Slika = Config.SlikeURL + filename;
        //        _dbContext.SaveChanges();

        //        return Ok(korisnik);

        //    }

       
        [HttpGet]
        public List<Korisnik> GetAll()
        {
            return _dbContext.Korisnik.ToList();
        }

        //[HttpPost]
        //public ActionResult UpdateSlika([FromForm] KorisnikAddSlikaVM korisnikAddSlikaVM)
        //{

        //    if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
        //        return BadRequest("nije logiran");

        //    Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

        //        if (korisnikAddSlikaVM.slikaKorisnika != null && korisnik != null)
        //        {
        //            if (korisnikAddSlikaVM.slikaKorisnika.Length > 250 * 1000)
        //                return BadRequest("max velicina fajla je 250 KB");

        //            string ekstenzija = Path.GetExtension(korisnikAddSlikaVM.slikaKorisnika.FileName);

        //            var filename = $"{Guid.NewGuid()}{ekstenzija}";

        //            korisnikAddSlikaVM.slikaKorisnika.CopyTo(new FileStream(Config.SlikeFolder + filename, FileMode.Create));
        //            korisnik.Adresa = Config.SlikeURL + filename;
        //            _dbContext.SaveChanges();
        //        }

        //        return Ok(korisnik);

        //}


        [HttpPost]
        public ActionResult Update([FromBody] KorisnikUpdateVM korisnikUpdateVM)
        {
            if (!HttpContext.GetLoginInfo().isPermsijaKorisnik)
                return BadRequest("nije logiran");

            Korisnik korisnik = HttpContext.GetLoginInfo().korisnickiNalog.Korisnik;

            korisnik.Ime = korisnikUpdateVM.Ime;
            korisnik.Prezime = korisnikUpdateVM.Prezime;
            korisnik.Email = korisnikUpdateVM.Email;
            korisnik.AdresaKorisnikaId = korisnikUpdateVM.AdresaKorisnikaId;
            korisnik.AdresaZaDostavuId = korisnikUpdateVM.AdresaZaDostavuId;
            korisnik.KorisnickoIme = korisnikUpdateVM.KorisnickoIme;
            korisnik.Lozinka = korisnikUpdateVM.Lozinka;
            

            _dbContext.SaveChanges();
            return Ok(korisnik);
        }
        public class KorisnikUpdateDto
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string KorisnickoIme { get; set; }
            public string Email { get; set; }
            public string BrojTelefona { get; set; }
            public string NazivUlice { get; set; }
            public string Slika { get; set; }
            public int GradId { get; set; }
            public string Lozinka { get; set; }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKorisnik(int id, [FromBody] KorisnikUpdateDto korisnikDto, CancellationToken cancellationToken)
        {
            if (id != korisnikDto.Id)
            {
                return BadRequest();
            }

            var korisnik = await _dbContext.Korisnik
                .Include(k => k.AdresaKorisnika)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (korisnik == null)
            {
                return NotFound();
            }

            // Ažuriranje korisničkih podataka
            korisnik.Ime = korisnikDto.Ime;
            korisnik.Prezime = korisnikDto.Prezime;
            korisnik.KorisnickoIme = korisnikDto.KorisnickoIme;
            korisnik.Email = korisnikDto.Email;
            korisnik.BrojTelefona = korisnikDto.BrojTelefona;
            korisnik.Slika = korisnikDto.Slika;
            // Ažuriranje adrese korisnika
            if (korisnik.AdresaKorisnika == null)
            {
                korisnik.AdresaKorisnika = new AdresaKorisnika();
            }

            korisnik.AdresaKorisnika.NazivUlice = korisnikDto.NazivUlice;
            korisnik.AdresaKorisnika.GradId = korisnikDto.GradId;
            if (!string.IsNullOrEmpty(korisnikDto.Lozinka))
            {
                korisnik.Lozinka = korisnikDto.Lozinka;
            }
            _dbContext.Entry(korisnik).State = EntityState.Modified;
            await _hubContext.Clients.Groups("admin").SendAsync("prijem_poruke_js",  korisnik.Id + " ID, korisnik je promjenio svoje podatke.",
                 cancellationToken: cancellationToken);

             await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }

}
