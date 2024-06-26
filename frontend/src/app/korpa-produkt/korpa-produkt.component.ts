import { Component, OnInit } from '@angular/core';
import {
  KorpaProduktAllResponse,
  ProizvodIdResponse
} from "./korpa-produkt-all";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import { Router } from '@angular/router';
import {ProduktAll} from "../provjera-narudzbe/produkt-all";
import Swal from 'sweetalert2';


@Component({
  selector: 'app-korpa-produkt',
  templateUrl: './korpa-produkt.component.html',
  styleUrls: ['./korpa-produkt.component.css']
})
export class KorpaProduktComponent implements OnInit {
  proizvodi: { [key: string]: ProizvodIdResponse } = {};
  otvori=false;
  korpaProdukti: ProduktAll[] = [];

  constructor(private httpClient: HttpClient,private router: Router) {
  }

  proizvodID(id:string){
    const url = MojConfig.adresa_servera + `/Produkt/PretraziProduktPoId?ProduktId=${id}`;
    return this.httpClient.get<ProizvodIdResponse>(url).subscribe((x) => {
      this.proizvodi[id] = x;
    });
  }

  ngOnInit(): void {
    this.refreshCart();
    let url = MojConfig.adresa_servera + `/KorpaProdukt/GetSveKorpaProdukt`;
    this.httpClient.get<KorpaProduktAllResponse>(url).subscribe({
      next:(x: KorpaProduktAllResponse) => {
        this.korpaProdukti = x;
        for(let item of this.korpaProdukti) {
          this.proizvodID(item.produktId);
        }},error:x=>{
        alert("Greska "+ x.error)
      }
    });

  }

  goBack() {
    window.history.back();
  }

  deleteItem(produktId: string) {
    Swal.fire({
      title: 'Jeste li sigurni da želite obrisati proizvod iz korpe?',
      showCancelButton: true,
      confirmButtonText: 'Da, obriši',
      cancelButtonText: 'Ne, odustani'
    }).then((result) => {
      if (result.isConfirmed) {
        const deleteUrl = MojConfig.adresa_servera + `/KorpaProdukt/Obrisi?KorpaProduktId=${produktId}`;
        this.httpClient.delete(deleteUrl).subscribe(
          () => {
            this.ngOnInit();
            Swal.fire('Proizvod je uspješno obrisan!', '', 'success');
          },
          (error) => {
            Swal.fire('Došlo je do greške prilikom brisanja proizvoda.', '', 'error');
          }
        );
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Otkazano', 'Proizvod nije obrisan.', 'info');
      }
    });

  }

  refreshCart() {
    let url = MojConfig.adresa_servera + `/KorpaProdukt/GetSveKorpaProdukt`;
    this.httpClient.get<KorpaProduktAllResponse>(url).subscribe({
    next:(x: KorpaProduktAllResponse) =>
    {
      this.korpaProdukti = x;
    },error:x=>
      {
        alert("Greska "+ x.error)
      }

    });
  }

  getUkupnaCijena(): number {
    const total = this.korpaProdukti.reduce((total, item) => {
      const proizvod = this.proizvodi[item.produktId];
      if (proizvod) {
        total += proizvod.cijena;
      }
      return total;
    }, 0);
    return parseFloat(total.toFixed(2));
  }

  openModal() {
    this.otvori=true;
  }
}
