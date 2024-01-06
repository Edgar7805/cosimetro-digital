


//funciones dedicadas hacer la lecturas del adc
float corriente();
float voltaje();

float corriente(){
       
    int16 suma = 0;
    float muestras = 0;
    float valor_adc_1 = 0;
    float corriente = 0; 
    //disable_interrupts(global);
    setup_adc(ADC_CLOCK_INTERNAL);
    setUP_adc_ports(AN0_TO_AN1);
  
    float promedio = 0;
    while (suma<=500){
      set_adc_channel(0);
       delay_us(20);
       valor_adc_1 = read_adc();
       corriente = valor_adc_1 * (0.7/1023.0);
       muestras +=  (corriente*100.0);
       suma++;
    } 
      
      promedio = muestras/500;
      //limpiar variables
       suma = 0;
       muestras = 0;
       valor_adc_1 = 0;
      corriente = 0; 
      setup_adc (ADC_OFF);
    
    enable_interrupts(INT_EXT);
    enable_interrupts(INT_EXT1);
    enable_interrupts(GLOBAL);
      return (promedio );     
}


float voltaje(){

   unsigned int lectura_1,lectura_2;
   unsigned int mayor= 0,mayor1 = 0;
   const float res1=4700;
   const float res2=1000;
   float voltaje;
   char cont;
   set_adc_channel(1);
  for (cont=0;cont<250;cont++)
  {
   lectura_1=read_adc(); //realiza primeralectura;
   delay_us(10);
   lectura_2=read_adc(); //realiza segundalectura;
   delay_us(10);
   if (lectura_2>lectura_1)  mayor=lectura_1;
    else mayor=lectura_2;
   if (mayor>mayor1) mayor1=mayor;
   }
   voltaje=mayor1*1.1/1023;          //calcula el voltaje

   voltaje=voltaje*((res1+res2)/res2);  //aplica el divisor resistivo

   voltaje=voltaje;              //suma caida en el puente rectificador
   voltaje=(voltaje+1.4)/1.4142;   // saca RMS
   return  voltaje*220;


}
