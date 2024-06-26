import {Injectable} from "@angular/core";
import* as signalR from "@microsoft/signalr";
import {MojConfig} from "../moj-config";


@Injectable({providedIn: 'root'})
export class SignalRService {
  public static ConnectionID: string | null;

  otvori_ws_konekciju()
  {
    let connection= new signalR.HubConnectionBuilder()
      .withUrl(`${MojConfig.adresa_servera}/hub-putanja?loginTokenId=`)
      .build();
    connection.on("prijem_poruke_js", (p)=>{
      // @ts-ignore
      porukaWarning("Nova poruka"+ p);
    })
    connection
      .start()
      .then(()=> {
        SignalRService.ConnectionID=connection.connectionId;
        console.log("konekcija otvorena"+ connection.connectionId);
      });
  }
}
