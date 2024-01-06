

//directivas fusy
#define infi 10000.0 
#define quitar  -1
#define mantener 0
#define anadir +1


//variables logica difusa
float regDifusas[3][3] = {{anadir  ,anadir ,anadir},    
                          {anadir   ,mantener  ,quitar},  
                          {mantener  ,mantener  ,quitar}}; 
                          
float FPActual = cos_fi;  // Ajusta este valor según tu aplicación
float uError[3];
//float uError[3],uDerror[3];
float sumaPOND,sumaPERT;
int p,q;
float salida;

//Operaciones Funciones de membrecias(logica difusa)
void difuso(void);
float triang(float x, float a, float m, float b);
float trapz (float x,float a,float b,float c,float d);
float fuzzyAND(float r,float s);


void difuso() {
   //Universo Difuso = Error (FPActual)
  float uError[3];
  uError[0] = trapz(FPActual, -infi, -infi, 0.5, 0.9);     // FPActual=Bajo
  uError[1] = triang(FPActual, 0.8, 0.93, 0.96);            // FPActual=Medio
  uError[2] = trapz(FPActual, 0.95, 0.97, infi, infi);       // FPActual=Alto
  //Universo DerivadaError Desfase
  
  // Inferencia
  sumaPOND = 0.0;
  sumaPERT = 0.0;

  for (p = 0; p < 3; p++) {
    for (q = 0; q < 3; q++) {
      sumaPOND += regDifusas[p][q] * fuzzyAND(uError[p], uError[q]);
      sumaPERT += fuzzyAND(uError[p], uError[q]);
    }
  }

  if (sumaPERT == 0.0) {
    salida = 0;
  } else {
    salida = sumaPOND / sumaPERT;
  }

  // Ajustar el resultado a la operación que desees realizar (añadir, mantener, quitar condensadores)
  if (salida > 0) {
      output_high(PIN_B5);
      delay_ms(500); // Ajusta el retardo según tus necesidades
      if (cos_fi < 0.97) {
         output_high(PIN_B4);
         delay_ms(500);
      }
      if (cos_fi< 0.97) {
         output_high(PIN_B3);
         delay_ms(500);
      }
      if (cos_fi< 0.97) {
         output_high(PIN_B2);
      }
    // Realiza las operaciones necesarias para la acción de "añadir"
  } else if (salida == 0) {
    // Mantener condensadores
    // No hacer nada ni activar nada
  } else {
    output_low(PIN_B5);
      delay_ms(500); // Ajusta el retardo según tus necesidades
      if (cos_fi >= 0.97) {
         output_low(PIN_B2);
         delay_ms(500);
      }
      if (cos_fi >= 0.97) {
         output_low(PIN_B3);
         delay_ms(500);
      }
      if (cos_fi>= 0.97) {
         output_low(PIN_B4);
      }
      if (cos_fi>= 0.97) {
         output_low(PIN_B5);
         delay_ms(500);
      }
    // Realiza las operaciones necesarias para la acción de "quitar"
  }
}

//Operaciones Funciones de membrecias
float triang(float x, float a, float m, float b){
  if(x<a || x>=b)
    return 0; 
  if(x>=a && x<m)
    return(x-a)/(m-a);
  if(x>=m && x<b)
    return(b-x)/(b-m);    
    
}
float trapz (float x,float a,float b,float c,float d){
  if(x<a || x>=d)
    return 0;
  if(x>=a && x<b)
    return(x-a)/(b-a);
  if(x>=b && x<c)
    return 1;
  if(x>=c && x<d)
    return (d-x)/(d-c);

}

float fuzzyAND(float r,float s){
  if(r<s)
    return r;
  else
    return s;
}
     






