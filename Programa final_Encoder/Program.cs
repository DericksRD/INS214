using System;
using System.IO;
using System.Text;

namespace Programa_final_Encoder
{
    class Program
    {
        //Atributos:
        public static string dateAndTime = "";
        static void Main(string[] args)
        {
            string[] text = File.ReadAllLines("output.csv");
            for(int i = 1; i < text.Length; i++){
                string[] columns = text[i].Split(',');
                long helper = Convert.ToInt64(columns[0]);
                dateAndTime = Convert.ToString(helper, 2);
                string value = "",
                       aux = "";

                aux = GetOnlyOneValue("11"); //year.
                value += aux + "-";

                aux = GetOnlyOneValue("4"); //month.
                value += aux + "-";

                aux = GetOnlyOneValue("5"); //day.
                value += aux + "T";

                aux = GetOnlyOneValue("5"); //hour.
                value += aux + ":";

                aux = GetOnlyOneValue("6"); //min.
                value += aux + ":";

                aux = GetOnlyOneValue("6"); //sec.
                value += aux + ".";

                aux = GetOnlyOneValue("10"); //milli.
                value += aux;

                aux = GetOnlyOneValue("1"); //tmz.
                if(aux == "1"){
                    value += "+";
                }else{
                    value += "-";
                }

                aux = GetOnlyOneValue("5"); //tmz.
                value += aux + ":00";

                helper = Convert.ToInt64(columns[1]);
                dateAndTime = Convert.ToString(helper, 2);

                aux = GetOnlyOneValue("5");
                value += "," + aux;

                aux = GetOnlyOneValue("7");
                value += "," + aux;

                aux = GetOnlyOneValue("7");
                value += "," + aux;

                File.AppendAllText("newInput.csv", "\n" + value);
                Console.WriteLine("Linea guardada exitosamente!");
            }
        }

        public static string GetOnlyOneValue(string index){
            int i = Convert.ToInt32(index);
            string onlyOneValue = dateAndTime.Substring(0, i);
            string _aux = Convert.ToInt32(onlyOneValue, 2).ToString();
            dateAndTime = dateAndTime.Substring(i);
            return _aux;
        }
    }
}
