import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
const swal = require('sweetalert');
defineLocale('es', esLocale);

//Models
import { Evaluacion } from '../../../core/models/evaluacion.model';

//Services
import { EvaluacionService } from '../../../core/services/test-evaluacion.services';

//Idioma
import { defineLocale } from 'ngx-bootstrap/chronos';
import { esLocale } from 'ngx-bootstrap/locale';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-busqueda',
    templateUrl: './busqueda.component.html',
    styleUrls: ['./busqueda.component.scss']
})
export class BusquedaComponent implements OnInit {

    // RATINGS
    public x: number = 5;
    public y: number = 2;
    public maxRat: number = 10;
    public rate: number = 0;
    public rateEditar: number = 0;
    public intIdEvaluacion: number;
    public strCorreoElectronicoEditar: string;
    public isReadonly: boolean = false;
    public overStar: number;
    public percent: number;

    oEvaluacion: Evaluacion;
    valFormBusqueda: FormGroup;
    locale = 'es';

    // Datepicker
    bsValue = new Date();
    bsRangeValue: Date[];
    maxDate = new Date();
    lstEvaluacion;
    blOcultar: boolean = false;

    bsConfig = {
        containerClass: 'theme-test'
    }

    ngOnInit() {

    }

    constructor(
        fb: FormBuilder,
        private evaluacionService: EvaluacionService,
        private localeService: BsLocaleService, ) {

        this.maxDate.setDate(this.maxDate.getDate() + 7);
        this.bsRangeValue = [this.bsValue, this.maxDate];
        let correo = new FormControl('', Validators.compose([Validators.required, CustomValidators.email]));
        this.valFormBusqueda = fb.group({
            'frmCorreoElectronico': correo,
            'frmFecha': [null, Validators.required],
        });
        this.localeService.use(this.locale);
    }


    listarEvaluacionPorRangoFechas(){
        for (let c in this.valFormBusqueda.controls) {
            this.valFormBusqueda.controls[c].markAsTouched();
        }

        if (this.valFormBusqueda.valid) {
            let datePipe = new DatePipe('en-US');
            let strFechaInicio = '';
            let strFechaFin = '';
            if (this.valFormBusqueda.value.frmFecha != '' && this.valFormBusqueda.value.frmFecha != null) {
                let dtFechaDesde: Date = this.valFormBusqueda.value.frmFecha[0];
                let dtFechaHasta: Date = this.valFormBusqueda.value.frmFecha[1];

                strFechaInicio = datePipe.transform(dtFechaDesde, 'yyyy-MM-dd');
                strFechaFin = datePipe.transform(dtFechaHasta, 'yyyy-MM-dd');
            }

            this.evaluacionService.getListar(this.valFormBusqueda.value.frmCorreoElectronico, strFechaInicio, strFechaFin).subscribe(respuesta => {
                this.lstEvaluacion = respuesta.data;
                if(this.lstEvaluacion.length > 0){ this.blOcultar = true;}else{this.blOcultar = false;}
            }, error =>{
                swal('Error', error.error.Message,'error');
            });
        }
      
    }



    // RATINGS METHODS
    public hoveringOver(value: number): void {
        this.overStar = value;
        this.percent = 100 * (value / this.maxRat);
    };

    public resetStar(): void {
        this.overStar = void 0;
    }

}
