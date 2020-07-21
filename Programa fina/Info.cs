using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Programa_fina
{
    class Info{
        //Atributos:
        public string DateAndTime {get;private set;}
        public string Weather {get;private set;}

        //Métodos:
        public Info(string text){
            //Convertir a representacion de bits:
            long bigNumber;
            bool timeUpper = false;
            
            if(text.Contains('+')){
                text = text.Replace('+', ' ');
                timeUpper = true;
            }
            text = text.Replace(':', ' ');
            text = text.Replace('T', ' ');
            text = text.Replace('-', ' ');
            text = text.Replace('.', ' ');

            string[] columns = text.Split(',');
            string line = columns[0];
            int notThatBig;

            /***DateAndTime***/
            string value = ""; 

            //Year:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = notThatBig << 4;

            //Month:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 5;

            //Day:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 5;

            //hour:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 6;

            //Minute:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 6;

            //Seconds:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 10;

            //Milliseconds:
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 1;

            //TimeZone (Upper):
            if(timeUpper){
                notThatBig = 1;
            } else{
                notThatBig = 0;
            }
            bigNumber = bigNumber | notThatBig;
            bigNumber = bigNumber << 5;

            //TimeZone (hour):
            line = GetEachValue(line, out value);
            notThatBig = Convert.ToInt32(value);
            bigNumber = bigNumber | notThatBig;

            DateAndTime = bigNumber.ToString();

            /***Weather***/
            int secondValue;
            //MinTemp:
            line = columns[1]; 
            notThatBig = Convert.ToInt32(line);
            secondValue = notThatBig << 7;

            //MaxTemp:
            line = columns[2];
            notThatBig = Convert.ToInt32(line);
            secondValue = secondValue | notThatBig;
            secondValue = secondValue << 7;

            //Precipitation:
            line = columns[3];
            notThatBig = Convert.ToInt32(line);
            secondValue = secondValue | notThatBig;

            Weather = secondValue.ToString();
        }

        public string GetEachValue(string _line, out string _value){
            int index = _line.IndexOf(' ');
            _value = _line.Substring(0, index);
            _line = _line.Substring(index + 1);

            return _line;
        }

    }
}