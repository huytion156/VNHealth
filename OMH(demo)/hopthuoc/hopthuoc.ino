void setup() {
        Serial.begin(9600);     // mở serial với baudrate 9600
        pinMode(2,OUTPUT);
        pinMode(3,OUTPUT);
        pinMode(4,OUTPUT);
        pinMode(5,OUTPUT);
        pinMode(13,OUTPUT);
        pinMode(8,INPUT_PULLUP);
        pinMode(9,INPUT_PULLUP);
        pinMode(10,INPUT_PULLUP);
        pinMode(11,INPUT_PULLUP);
}
int hop1,hop2,hop3,hop4;
String str;
void return_data()
{
  Serial.println(1);
}
void xuli(char a)
{
  //Serial.print(a);
  tone(12, 3951,200);
  if(a=='1') 
    {
      if(hop1==1) return_data();
      digitalWrite(2,HIGH);
    }
  if(a=='2') 
    {
      if(hop2==1) return_data();
      digitalWrite(3,HIGH); 
    }
  if(a=='3') 
    {
      if(hop3==1) return_data();
      digitalWrite(4,HIGH);
    }
  if(a=='4') 
    {
      if(hop4==1) return_data();
      digitalWrite(5,HIGH);
    }
  
}
void loop() 
{
    hop1=digitalRead(8);
    hop2=digitalRead(9);
    hop3=digitalRead(10);
    hop4=digitalRead(11);
    //dang co dien =0
    //ngat dien =1
    if(Serial.available() > 0)
    {
        digitalWrite(13,HIGH);
        str = Serial.readStringUntil('\n');
        //Serial.println(str);
        /*if(str[4]=='a') digitalWrite(13,HIGH);
        else
          if(str[4]=='d') digitalWrite(13,LOW);*/
        if(str[4]=='a') xuli(str[5]);
        if(str[4]=='d')
        {
          digitalWrite(2,LOW);
          digitalWrite(3,LOW);
          digitalWrite(4,LOW);
          digitalWrite(5,LOW);
        }  
        digitalWrite(13,LOW);      
    }
}
