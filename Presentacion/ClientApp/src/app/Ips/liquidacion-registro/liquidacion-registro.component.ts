import { Component, OnInit } from '@angular/core';
import { Liquidacion } from '../models/liquidacion';
import { LiquidacionService } from 'src/app/services/liquidacion.service';

@Component({
  selector: 'app-liquidacion-registro',
  templateUrl: './liquidacion-registro.component.html',
  styleUrls: ['./liquidacion-registro.component.css']
})
export class LiquidacionRegistroComponent implements OnInit {

  liquidacion: Liquidacion;
  constructor(private LiquidacionService: LiquidacionService) { }

  ngOnInit(): void {
    this.liquidacion = new Liquidacion();
  }

  Registrar(){
    this.LiquidacionService.post(this.liquidacion).subscribe(p=>{
      if(p!=null){
        alert("Valor copago: "+p.valorCopago +p.tarifa.toPrecision(1));
        this.liquidacion = p;
      }
    })
  }

}
