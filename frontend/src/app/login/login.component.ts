import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
import {Login} from "./login-vm";
import {AutentifikacijaHelper} from "../helper/autentifikacija-helper";
import {AuthService} from "../services/AuthService";
import {SignalRService} from "../services/signalR.service";
import Swal from 'sweetalert2';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  prijava : Login = new Login();
  zapamtiMe : any;
  fieldText: any;
  validiranoKorisnickoIme: boolean = false;
  validiranaLozinka : boolean = false;
   otvori: boolean=false;
  kljuc: any;
  korisnikId:any;
  active:any;

  constructor(private httpKlijent : HttpClient, private router : Router,private autentifikacijaHelper: AutentifikacijaHelper,
              private authService:AuthService) {
  }

  ngOnInit(): void {
  }

  posaljiPodatke() {
    this.prijava.signalRConnectionID=SignalRService.ConnectionID;

    if (this.validiranoKorisnickoIme && this.validiranaLozinka) {
      this.httpKlijent.post(MojConfig.adresa_servera + '/Autentifikacija/Login', this.prijava)
        .subscribe((response: any) => {
            if (response.isLogiran) {
              response.isPermisijaGost = false;
              AutentifikacijaHelper.setLoginInfo(response, this.zapamtiMe);

              localStorage.setItem("loggedIn","true");
              localStorage.setItem("loggedOut","false");
              this.autentifikacijaHelper.loggedInEvent.emit(true);
              this.authService.setLogiraniKorisnik(response.autentifikacijaToken);
              if(this.authService.is2FActive())
              {
                this.otvori=true;
                this.loadKorisnik();
              }
              else {
                this.router.navigate(['/']);
                Swal.fire({
                  title: "Uspješno ste se logirali!",
                  icon: "success"
                });
              }

            } else {
              AutentifikacijaHelper.setLoginInfo(null);
              Swal.fire({
                title: "Oops...",
                text: "Pogrešno uneseni podaci za prijavu. Neispravno korisničko ime ili lozinka.",
                icon: "error"
              });
            }
          }
        );
    }
    else
      Swal.fire({
        title: "Neadekvatno ispunjena forma za prijavu",
        text: "Molimo ispunite sva obavezna polja, pa ponovo pokušajte.",
        icon: "error"
      });

  }

  loadKorisnik()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ `/Autentifikacija/Get`, MojConfig.http_opcije()).subscribe((x:any)=> {
      this.korisnikId=x.korisnickiNalogId??null;
    });
  }

  otkljucaj() {
    let url = MojConfig.adresa_servera + `/TwoFOtkljucaj/Otkljucaj`;
    this.httpKlijent.post(url, { Kljuc: this.kljuc }).subscribe(
      () => {
        this.promjenaVrijednosti();
        this.router.navigate(['/']);
      }
    );
  }
  //prikaziRegistraciju() {
   // this.router.navigate(['/registracija']);
  //}

  prikaziSakrij() {
    this.fieldText = !this.fieldText;
  }

  provjeriKorisnickoIme(polje : any) {
    if (polje.invalid && (polje.dirty || polje.touched)){
      if (polje.errors?.['required']){
        this.validiranoKorisnickoIme = false;
        return 'Niste popunili ovo polje!';
      }
      else {
        this.validiranoKorisnickoIme = true;
        return '';
      }
    }
    if (this.prijava.korisnickoIme != null && this.prijava.korisnickoIme.length > 0) this.validiranoKorisnickoIme = true;
    return 'Obavezno polje za unos';
  }

  provjeriLozinku(polje : any) {
    if (polje.invalid && (polje.dirty || polje.touched)){
      if (polje.errors?.['required']){
        this.validiranaLozinka = false;
        return 'Niste popunili ovo polje!';
      }
      else {
        this.validiranaLozinka = true;
        return '';
      }
    }
    if (this.prijava.lozinka != null && this.prijava.lozinka.length > 0) this.validiranaLozinka = true;
    return 'Obavezno polje za unos';
  }

promjenaVrijednosti()
{
  this.active={
    active:false,
  }
  let urlPost=MojConfig.adresa_servera + `/KorisnickiNalog/${this.korisnikId}/update-2fa-active`;
  this.httpKlijent.post(urlPost, this.active).subscribe(
    () => {
    });
}

}
