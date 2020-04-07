import { Component, OnInit } from '@angular/core';
import { Liquidacion } from '../models/liquidacion';
import { LiquidacionService } from 'src/app/services/liquidacion.service';

@Component({
  selector: 'app-liquidacion-consulta',
  templateUrl: './liquidacion-consulta.component.html',
  styleUrls: ['./liquidacion-consulta.component.css']
})
export class LiquidacionConsultaComponent implements OnInit {

  liquidaciones: Liquidacion[];
  constructor(private LiquidacionService: LiquidacionService) { }

  ngOnInit(): void {
    this.LiquidacionService.get().subscribe(result=>{
      this.liquidaciones = result;
    });
    
  }
  

}
