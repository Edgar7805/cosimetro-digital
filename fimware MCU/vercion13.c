#include <18f4550.h>
#fuses PLL1,CPUDIV3,HSPLL,PUT,NOLVP,NOPROTECT,NODEBUG,NOWDT,NOLPT1OSC,USBDIV
#device adc=10
#use delay(clock=32MHz)
#define compensar 0.70
#define USB_CON_SENSE PIN_D0
#include <usb_cdc.h>
#PRIORITY INT_EXT1,INT_EXT  //interrupcion con prioridad
#include <medidas.h>   // medir corriente y voltaje

#include <math.h>
                                  
#define LCD_RS_PIN      PIN_D1                                   
#define LCD_RW_PIN      PIN_D2
#define LCD_ENABLE_PIN  PIN_D3  
#define LCD_DATA4       PIN_D4                                   
#define LCD_DATA5       PIN_D5                                  
#define LCD_DATA6       PIN_D6                                
#define LCD_DATA7       PIN_D7 
#include <lcd.c>

#define tau 6.28318     //valor de 2pi
#define REINICIA_TIMER 0
#define freq 50.0   //frecucnia de de red
float t1=0;   //valore del timer obtenidos por la interrupcion 
int1 cambio= 0;   //flag que indica que se ah reiniciado el timer
float  cos_fi =0 ;
float indice=0;//sgun el indice elije un valor dentro del stich case
float voltaje_rms=0;
//

int get_indice(float t1);
float roundDecimal(float num);
float corriente_rms =0;
void valores(void);  //contine el switch case con los valores calculador de cos_fi
#include <fusy.h>
int1 flag1 = 0;
//funciones de interrupcion
#INT_EXT
void RB0_ISR(){   //se�al corriente
   set_timer1(0);
}

#INT_ext1
void RB1_ISR(){  //se�al voltaje;
    
      //t1 = ((float)get_timer1()); ///divisor de tiempo no mover
      t1 = ((float)get_timer1()/1936.8); ///divisor de tiempo no mover
      
}



void main(){
    
    //config gpios
    set_tris_b(0b00000011);
    
    output_low(pin_b2);
    output_low(pin_b3);
    output_low(pin_b4);
    output_low(pin_b5);
    //iniciar lcd 
   lcd_init();
   usb_cdc_init();
    setup_timer_1(T1_INTERNAL|T1_DIV_BY_8 );  //desborde del timer 64ms  los valores equivalen a micro segundo
    //congigurar interrupcioes
    setup_adc(ADC_CLOCK_INTERNAL);
    setUP_adc_ports(AN0_TO_AN1);
    set_adc_channel(0);
    ext_int_edge(INT_EXT | H_TO_L);
    ext_int_edge(INT_EXT1 | H_TO_L);
    enable_interrupts(INT_EXT);
    enable_interrupts(INT_EXT1);
    enable_interrupts(GLOBAL);
    lcd_gotoxy(1,1);
   lcd_putc("iniciando...");
   delay_ms(1000);
   lcd_putc("\f");
        int i =0;
   while(true){
             usb_task();
            
            if(usb_enumerated()){
              Indice=get_indice(t1);
              valores();
              corriente_rms =corriente();
             // voltaje_rms=voltaje();  
              lcd_gotoxy(1,1);
              printf(lcd_putc,"pf=%.2f",cos_fi);
              lcd_gotoxy(1,2);
              lcd_putc("USB conn         ");
              printf(usb_cdc_putc,"\rpf=%.2f t=%.3f I(A)=%.1f V= %.1f\n ",cos_fi,t1,corriente_rms,voltaje_rms);
              delay_ms(10);
              //lcd_gotoxy(1,2);
              ///printf(lcd_putc,"A=%.2f",corriente_rms );
              difuso();
          }
          else{
              
              Indice=get_indice(t1);
              valores();
              corriente_rms =corriente();
              voltaje_rms=voltaje();         
              lcd_gotoxy(1,1);
              printf(lcd_putc,"pf=%.2f\n",cos_fi);
              lcd_gotoxy(1,2);
              printf(lcd_putc,"I(A)=%.1f\n",corriente_rms);
              lcd_gotoxy(7,2);
              printf(lcd_putc,"I(A)=%.1f\n",voltaje_rms);
          
          
          }
            }
            
   
}


int get_indice(float t1){
 
     int indice=0;
     indice= roundDecimal(t1*2);
     
     
     
     
     
     return indice;  //retorna el factor de potencia descrito en el arreglo
}


float roundDecimal(float num) {
    int entero = (int)num;
    float decimal = num - entero;

    // Redondear al entero m�s cercano
    if (decimal < 0.2) {
        return (float)entero;
    } else {
        return (float)(entero + 1);
    }
}



void valores(){

    switch((int)indice) {
        case 1:
            cos_fi=1.0;
            break;
        case 2:
            cos_fi=0.98;
            break;
        case 3:
            cos_fi=0.95;
            break;
        case 4:
           cos_fi=0.89;
            break;
        case 5:
            cos_fi=0.80;
            break;
        case 6:
            cos_fi=0.70;
            break;
        case 7:
            cos_fi=0.58;
            break;
        case 8:
            cos_fi=0.45;
            break;
        case 9:
            cos_fi=0.30;
            break;
        case 10:
            cos_fi=0.15;
            break;
        case 11:
             cos_fi=0.0;
             break;
        case 12:
            cos_fi=-0.15;
            break;
        case 13:
           cos_fi=-0.30;
            break;
        case 14:
            cos_fi=-0.45;
            break;
        case 15:
            cos_fi=-0.58;
            break;
        case 16:
            cos_fi=-0.70;
            break;
            
        case 17:
            cos_fi=-0.80;
            break;
        case 18:
            cos_fi=-0.89;
            break;
        case 19:
            cos_fi=-0.95;
            break;
        case 20:
            cos_fi=-0.98;
            break;
        case 21:
            cos_fi=-1.0;
            break;
        default:
            
            break;
    }
}    


