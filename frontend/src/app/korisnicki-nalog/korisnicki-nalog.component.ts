import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-korisnicki-nalog',
  templateUrl: './korisnicki-nalog.component.html',
  styleUrls: ['./korisnicki-nalog.component.css']
})
export class KorisnickiNalogComponent implements OnInit {
  korisnik: any;
  otvoriModal: boolean = false;
  korisnikModal: any;
  adresa: any;
  korisnikID: any;
  gradovi: any;
  otvoriModalLozinka: boolean = false;
  korisnikLozinka: any;
  novaLozinka: any;


  constructor(private httpClient: HttpClient) {
  }

  loadKorisnik() {
    this.httpClient.get(MojConfig.adresa_servera + `/Autentifikacija/Get`, MojConfig.http_opcije())
      .subscribe((response: any) => {
        this.korisnik = response.korisnickiNalog;
        this.korisnikID = response.korisnickiNalogId
        this.httpClient.get(MojConfig.adresa_servera + `/AdresaKorisnika/GetAdresaKroisnikaID/${this.korisnikID}`, MojConfig.http_opcije())
          .subscribe((response: any) => {
            this.adresa = response;
          });
      });
  }

  getGradovi() {
    this.httpClient.get(MojConfig.adresa_servera + `/Grad/GetSviGradovi`, MojConfig.http_opcije())
      .subscribe((response: any) => {
        this.gradovi = response;

      });
  }

  ngOnInit(): void {
    this.loadKorisnik();
    this.getGradovi();
  }

  otvori(korisnik: any) {
    this.otvoriModal = true;
    this.korisnikModal = {
      id: korisnik.id,
      ime: korisnik.ime,
      prezime: korisnik.prezime,
      korisnickoIme: korisnik.korisnickoIme,
      email: korisnik.email,
      brojTelefona: korisnik.brojTelefona,
      nazivUlice: this.adresa.nazivUlice,
      gradId: this.adresa.gradId,
      slika: korisnik.slika,
      lozinka: korisnik.lozinka,
    }
  }

  sacuvaj(korisnikModal: any) {
    this.otvoriModal = false;
    Swal.fire({
      title: 'Da li želite sačuvati izmjene?',
      showCancelButton: true,
      confirmButtonText: 'Da',
      cancelButtonText: 'Ne',
      icon: 'question',
    }).then((result) => {
      if (result.isConfirmed) {
        this.httpClient.put(MojConfig.adresa_servera + `/Korisnik/UpdateKorisnik/${korisnikModal.id}`, korisnikModal, MojConfig.http_opcije())
          .subscribe((response: any) => {
            this.loadKorisnik();
            Swal.fire({
              icon: 'success',
              title: 'Uspješno ste uredili podatke!',
              showConfirmButton: false,
              timer: 1500
            });
          });
      }
    });
  }

  otvoriLozinka(korisnik: any) {
    this.otvoriModalLozinka = true;
    this.korisnikLozinka = {
      id: korisnik.id,
      ime: korisnik.ime,
      prezime: korisnik.prezime,
      korisnickoIme: korisnik.korisnickoIme,
      email: korisnik.email,
      brojTelefona: korisnik.brojTelefona,
      nazivUlice: this.adresa.nazivUlice,
      gradId: this.adresa.gradId,
      slika: korisnik.slika,
      lozinka: '',
    }
  }


  sacuvajLozinku(korisnikLozinka: any) {
    this.otvoriModalLozinka = false;
    if(korisnikLozinka.lozinka!='') {
      Swal.fire({
        title: 'Da li želite sačuvati izmjene?',
        showCancelButton: true,
        confirmButtonText: 'Da',
        cancelButtonText: 'Ne',
        icon: 'question',
      }).then((result) => {
        if (result.isConfirmed) {
          this.httpClient.put(MojConfig.adresa_servera + `/Korisnik/UpdateKorisnik/${korisnikLozinka.id}`, korisnikLozinka, MojConfig.http_opcije())
            .subscribe((response: any) => {
              this.loadKorisnik();
              Swal.fire({
                icon: 'success',
                title: 'Uspješno ste uredili podatke!',
                showConfirmButton: false,
                timer: 1500
              });
            });
        }
      });
    }
  }
  // Inside your component class
  getGradNaziv(gradId: any): string {
    if (gradId && this.gradovi) {
      const grad = this.gradovi.find((grad: any) => grad.gradId === gradId);
      return grad ? grad.imeGrada : 'Nepoznato';
    }
    return 'Nepoznato';
  }

}
