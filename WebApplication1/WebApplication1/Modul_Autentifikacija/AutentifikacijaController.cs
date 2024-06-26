
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;
using WebApplication1.Data;
using static WebApplication1.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;
using WebApplication1.Modul_Autentifikacija.ViewModels;
using WebApplication1.Helper;
using WebApplication1.Helper.Service;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.SignalR;
using System.Threading;

namespace FIT_Api_Examples.Modul0_Autentifikacija.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly MyEmailSenderService _myEmailSenderService;
        private readonly IHubContext<SignalRHub> _hubContext;

        public AutentifikacijaController(ApplicationDbContext dbContext, MyEmailSenderService myEmailSenderService, IHubContext<SignalRHub> hubContext)
        {
            this._dbContext = dbContext;
            _myEmailSenderService = myEmailSenderService;
           _hubContext = hubContext;
        }


        [HttpPost]
        public async Task<ActionResult<LoginInformacije>> Login([FromBody] LoginVM x, CancellationToken cancellationToken)
        {
            //1- provjera logina
            KorisnickiNalog logiraniKorisnik =await _dbContext.KorisnickiNalog
                .FirstOrDefaultAsync(k =>
                k.KorisnickoIme != null && k.KorisnickoIme == x.korisnickoIme && k.Lozinka == x.lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new LoginInformacije(null);
            }
            string email= logiraniKorisnik.Email;
            string? twoFKey = null;
            if (logiraniKorisnik.Is2FActive)
            {
                twoFKey = TokenGenerator.Generate(4);
                _myEmailSenderService.Posalji($"{email}", "2f", $"Vas 2f kljuc je {twoFKey}", false);

            }
            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                Vrijednost = randomString,
                KorisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now,
                TwoFKey = twoFKey
            };

             _dbContext.Add(noviToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _hubContext.Groups.AddToGroupAsync(x.SignalRConnectionID,
                 noviToken.KorisnickiNalog.KorisnickoIme,
                 cancellationToken);
            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }
        public class LogOutRequest
        {
            public string SignalRConnectionID { get; set; }
        }
        [HttpPost]
        public async Task<NoResponse> Logout([FromBody]  LogOutRequest x,CancellationToken cancellationToken)
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return new NoResponse();
            await _hubContext.Groups.AddToGroupAsync(x.SignalRConnectionID,
                 autentifikacijaToken.KorisnickiNalog.KorisnickoIme,
                 cancellationToken);

            _dbContext.Remove(autentifikacijaToken);
           await _dbContext.SaveChangesAsync();
            return new NoResponse();

        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }
    }
}