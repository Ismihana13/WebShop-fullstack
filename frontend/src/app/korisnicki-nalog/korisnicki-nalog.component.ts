import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-korisnicki-nalog',
  templateUrl: './korisnicki-nalog.component.html',
  styleUrls: ['./korisnicki-nalog.component.css']
})
export class KorisnickiNalogComponent implements OnInit {
   korisnik: any;


  constructor(private httpClient: HttpClient) { }
  loadKorisnik() {
    this.httpClient.get(MojConfig.adresa_servera + `/Autentifikacija/Get`, MojConfig.http_opcije())
      .subscribe((response: any) => {
              this.korisnik = response.korisnickiNalog;

        });
  }

  ngOnInit(): void {
    this.loadKorisnik();
  }

}
