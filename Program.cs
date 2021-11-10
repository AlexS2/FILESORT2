using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePr
{
    class Program
    {
        struct recordsItm {public int NumID; public  string Item; public  double price; }
  
        static void Main(string[] args)
        {

            string  Str_Record, AllFile1;           
            int delta1=1,delta2=101;
            string[] arrString;
            string[,] arrString2;
            arrString = new string[1000];
             arrString2 = new string[100,100];
            var AllFile= new string[]{};

            //инициализ. массив списков
            SortedList[] mas = new SortedList[12];
            for (int i=0;i<mas.Length;i++) {mas[i] = new SortedList(); }
            Console.WriteLine("Cоздаем список,пишем в  файл...\n");
            if (!File.Exists("All_prod.txt")) File.WriteAllText("All_prod.txt","");
            if (File.Exists("All_prod.txt")) {    File.Delete("All_prod.txt"); File.WriteAllText("All_prod.txt",""); }
           
           Console.WriteLine("Файл создан\nНажмите Enter\n"); 
            recordsItm Record1;

            for (int i = 0; i < 1001; i++)
                {
                    Random rand=new Random();
                    var rand_numD=rand.NextDouble();
                    var rand_num=rand.Next(1001);
                     Record1.NumID=i;
                     Record1.Item="Товар";
                     Record1.price= Math.Round(rand_num+rand_numD, 2);
                     Str_Record=i + ";Товар"+i+";"+Record1.price.ToString()+"\n";
                     File.AppendAllText("All_prod.txt", Str_Record);
                }
           
            AllFile1 = File.ReadAllText("All_prod.txt");
           
//рассортировать прочитанный файл по спискам
           
            SortedList SL = new SortedList();
             string[] lines = File.ReadAllLines("All_prod.txt");
                     int j=0;
                                               foreach (string s in lines)
                  {
                       //сортировка по спискам
                     //цена
                    int m=s.LastIndexOf(";");
                    var str1=s.Substring(m+1);
                    var prD=Convert.ToDouble(str1);
                 
                 //порядковый номер
                    m=s.IndexOf(";");
                    str1=s.Substring(0,m);
                    var ID=Convert.ToInt16(str1);
                    var str2=s.Substring(m);
                    delta1=1;
                    delta2=101;
                        //сортировка по порядковому номеру
                        for (int numList=0; numList <11; numList++ )
                            {
                                if ((prD>delta1)&(prD<delta2)) {  mas[numList].Add(ID,str2); }
                                delta2=delta2+100; delta1=delta1+100;
                                //Console.WriteLine(delta2 +" "+ delta1+"\n");
                             }
                   
                      SL.Add(Convert.ToDouble(str1),str2); //сортировка по цене всего файла
                       j++;
                         
                     }
                //сортируем для первого файла
                   
             Console.WriteLine("=-=-=-=-=-=-=-=-=-=\n");      
             Console.ReadKey();
             
             
             //mas[9].Sort();
            // File.WriteAllLines("List1.txt", mas[9]);
            

    //стираем старые файлы если есть
for (int i = 0; i < 10; i++)
    {
     if (File.Exists("List"+Convert.ToString(i)+".txt")) {    File.Delete("List"+Convert.ToString(i)+".txt");  }
    }     

            //запись по файлам
            
    for (int i = 0; i < 11; i++)
    {
        
   
             foreach(DictionaryEntry de in mas[i])  {   
                //   Console.WriteLine("{0};{1}", de.Key, de.Value); 
             
              
              string tmp_str;
              tmp_str= Convert.ToString(de.Key) + de.Value+"\n";
              File.AppendAllText("List"+Convert.ToString(i)+".txt", tmp_str); 
              }
     }

          //  Console.WriteLine("Sorted LIST1\n");
          
            // foreach(DictionaryEntry de in mas[0])  {    Console.WriteLine("{0};{1}", de.Key, de.Value); }

 
            Console.WriteLine("Файлы сформированы\n");
             Console.WriteLine("Файлы сформированы\n");
          
          
           
        }
    }
}
