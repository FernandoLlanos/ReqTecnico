import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
const swal = require('sweetalert');

//Models
import { Evaluacion } from '../../../core/models/evaluacion.model';

//Services
import { SettingsService } from '../../../core/settings/settings.service';
import { EvaluacionService } from '../../../core/services/test-evaluacion.services';
import { HttpClient } from '@angular/common/http';


@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    
    
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

        oEvaluacion : Evaluacion;
        valFormRegistro: FormGroup;
        lstEvaluaciones;
        blOcultar: boolean = false;

        @ViewChild('btnCancelar', { static: true }) btnCancelar: ElementRef;
        
    constructor(
        private settings: SettingsService,
        private evaluacionService: EvaluacionService,
        fb: FormBuilder,) { 

        let correo = new FormControl('', Validators.compose([Validators.required, CustomValidators.email]));
        this.valFormRegistro = fb.group({
            'frmCorreoElectronico': correo,
            'frmNombreCompleto': [null, Validators.required],
            'frmRate': [null],
        });
    }

    ngOnInit() {

    }

    registrarCalificacion(){
        for (let c in this.valFormRegistro.controls) {
            this.valFormRegistro.controls[c].markAsTouched();
        }

        if(this.valFormRegistro.valid){
            if(this.rate == 0){
                swal('Validación','Debe marcar una calificación.','info'); 
                return;
            }
            const oEvaluacion = new Evaluacion();
            oEvaluacion.strCorreoElectronico = this.valFormRegistro.value.frmCorreoElectronico;
            oEvaluacion.strNombreCompleto    = this.valFormRegistro.value.frmNombreCompleto;
            oEvaluacion.intCalificacion      = this.rate;
            this.evaluacionService.postGrabar(oEvaluacion).subscribe(respuesta => {
                swal('Exito','La calificación se registró correctamente.','success');
                this.listarPorCorreoElectronico(this.valFormRegistro.value.frmCorreoElectronico);
                this.limpiarFormulario();
            }, error => {
                swal('Error',error.error.Message,'error'); 
            });
        }
    }

    actualizarCalificacion(){
        const oEvaluacion = new Evaluacion();
            oEvaluacion.intIdEvaluacion      = this.intIdEvaluacion;
            oEvaluacion.strCorreoElectronico = this.strCorreoElectronicoEditar;
            oEvaluacion.intCalificacion      = this.rateEditar;
            this.evaluacionService.putActualizar(oEvaluacion).subscribe(respuesta => {
                swal('Actualizado.!','La calificación fue actualizada correctamente.','success');
                this.listarPorCorreoElectronico(this.strCorreoElectronicoEditar);
                this.btnCancelar.nativeElement.click();
            }, error => {
                swal('Error',error.error.Message,'error'); 
            });
    }

    listarPorCorreoElectronico(strCorreoElectronico: string){
        this.evaluacionService.getListarPorCorreo(strCorreoElectronico).subscribe(respuesta => {
            this.lstEvaluaciones = respuesta.data;
            if(this.lstEvaluaciones.length > 0){ this.blOcultar = true;}else{this.blOcultar = false;}
        },error =>{
            swal('Error',error.error.Message,'error');
        });
    }

    limpiarFormulario(){
        this.valFormRegistro.reset();
        this.rate = 0;
    }

    setEditar(item:any){
        this.intIdEvaluacion = item.intIdEvaluacion; 
        this.strCorreoElectronicoEditar = item.strCorreoElectronico;
        this.rateEditar = item.intCalificacion; 
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
