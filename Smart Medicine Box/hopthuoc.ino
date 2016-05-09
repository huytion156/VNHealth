void setup() {
        Serial.begin(9600);     // mở serial với baudrate 9600
        pinMode(8,OUTPUT);
        pinMode(9,OUTPUT);
        pinMode(10,OUTPUT);
        pinMode(11,OUTPUT);
        pinMode(13,OUTPUT);
        pinMode(2,INPUT_PULLUP);
        pinMode(3,INPUT_PULLUP);
        pinMode(4,INPUT_PULLUP);
        pinMode(5,INPUT_PULLUP);
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
      digitalWrite(8,HIGH);
    }
  if(a=='2') 
    {
      if(hop2==1) return_data();
      digitalWrite(9,HIGH); 
    }
  if(a=='3') 
    {
      if(hop3==1) return_data();
      digitalWrite(10,HIGH);
    }
  if(a=='4') 
    {
      if(hop4==1) return_data();
      digitalWrite(11,HIGH);
    }
  
}
void loop() 
{
    hop1=digitalRead(2);
    hop2=digitalRead(3);
    hop3=digitalRead(4);
    hop4=digitalRead(5);
    //dang co dien =0
    //ngat dien =1
    if(Serial.available() > 0)
    {
        str = Serial.readStringUntil('\n');
        //Serial.println(str);
        /*if(str[4]=='a') digitalWrite(13,HIGH);
        else
          if(str[4]=='d') digitalWrite(13,LOW);*/
        if(str[4]=='a') xuli(str[5]);
        if(str[4]=='d')
        {
          digitalWrite(8,LOW);
          digitalWrite(9,LOW);
          digitalWrite(10,LOW);
          digitalWrite(11,LOW);
        }        
    }
}
