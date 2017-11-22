using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace OOPLab10
{
    
    class Program
    {
        static void Main(string[] args)
        {

            string[] month = { "January", "Fabryary", "March", "April", "June","May", "Jule","August","September","October","November", "December" };

            int n = 5;
            IEnumerable<string> monthLenght = from i in month
                                         where i.Length == n
                                         select i;

            IEnumerable<string> Summer = from i in month
                                         where i.Equals("August") || i.Equals("June")|| i.Equals("Jule")

                                         select i;

            IEnumerable<string> Winter = month.Where(i => i.Equals("December") || i.Equals("January") || i.Equals("Fabryary"))
                                              .Select(i=>i);

            IEnumerable<string> Sort = month.OrderBy(s => s)
                                            .Select(s=>s);

            IEnumerable<string> U = month.Where(s=>s.Length>=4)
                                         .Where(s=>s.Contains("u"))
                                         .Select(s => s);


            foreach (string j in monthLenght)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("------------------");
            foreach (string j in Summer)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("------------------");
            foreach (string j in Winter)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("------------------");
            foreach (string j in Sort)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("------------------");
            foreach (string j in U)
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("------------------");
            Console.WriteLine("=====================================================================");
            List<Phone> PHONE = new List<Phone>();

            Phone Phone1 = new Phone("Petrov", "Anatoliy", "Vladimirovich",new Time(23,22,2), new Time(0, 5, 33));
            Phone Phone2 = new Phone("Ivanov", "Boris", "Vitalevich", new Time(22, 23, 7), new Time(23, 22, 2));
            Phone Phone3 = new Phone("Sidorov", "Vladimir", "Vladimirovich", new Time(76, 6, 0), new Time(3, 11, 0));
            Phone Phone4 = new Phone("Smirnov", "Alexandr", "Smirnov", new Time(0, 0, 0), new Time(0, 0, 0));

            PHONE.Add(Phone1);
            PHONE.Add(Phone2);
            PHONE.Add(Phone3);
            PHONE.Add(Phone4);
            Time time = new Time(3,11,0);
            IEnumerable<Phone> PhoneCalls = from s in PHONE
                                            where s.SityCalls.CompareTo(time)==1
                                            select s;

            Time timeDis = new Time(0, 0, 0);

            IEnumerable<Phone> PhoneDisCalls = from s in PHONE
                                               where s.SityCalls.CompareTo(timeDis) == 1
                                               select s;

            IEnumerable<Phone> SortAb = from s in PHONE
                                               orderby s.FAMILY
                                               select s;


            foreach (Phone i in PhoneCalls)
            {
                i.Show();
            }
            Console.WriteLine("------------------");
            foreach (Phone i in PhoneDisCalls)
            {
                i.Show();
            }
            Console.WriteLine("------------------");
            foreach (Phone i in SortAb)
            {
                i.Show();
            }
            Console.WriteLine("------------------");

            Console.ReadKey();
        }

        public class Time: IComparable<Time>
        {
            public int Hours;
            public int Minutes;
            public int Seconds;
            public Time()
            {

            }
            public Time(int h, int m, int s)
            {
                Hours = h;
                Minutes = m;
                Seconds = s;
            }
            public  bool Equals(Time t)
            {
                if(Hours == t.Hours &&
                Minutes == t.Minutes &&
                Seconds == t.Seconds)
                return true;
                return false;
            }
            public string Show()
            {
                return (Hours+"."+ Minutes + "." + Seconds);
            }
            public int CompareTo(Time t)
            {
                if(Hours>t.Hours )
                return 1;
                else if(Minutes>t.Minutes)
                    return 1;
                else if(Seconds>t.Seconds) return 1;
                else if(Equals(t)) return 2;
                return 0;
            }

        }
        public class Phone
        {
           
            string Family;
            string Name;
            string Fatherland;
            string Address;
            string CreditCardNumber;
            int? Debit;
            int? Credit;
            Time DistanceCalls = new Time();
            public Time SityCalls = new Time();
            const string PoleConst = "Const";
            public override bool Equals(object obj)
            {

                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                Phone Obj = (Phone)obj;
                return (
                    this.NAME == Obj.NAME &&
                    this.FAMILY == Obj.FAMILY &&
                    this.FATHERLAND == Obj.FATHERLAND &&
                    this.ADDRESS == Obj.ADDRESS &&
                    this.CREDITCARD == Obj.CREDITCARD &&
                    this.DEBIT == Obj.DEBIT &&
                    this.CREDIT == Obj.CREDIT &&
                    this.SITYCALLS == Obj.SITYCALLS
                    );

            }
            public override int GetHashCode()
            {
                return (Family + Name + Fatherland).GetHashCode(); ;
            }
            public Phone(string f, string n, string fa,  Time D, Time S)
            {
                Family = f;
                Name = n;
                Fatherland = fa;
                DistanceCalls = D;
                SityCalls = S;
            }
            
            public string NAME
            {
                get
                {
                    return Name;
                }
                set
                {
                    Name = value.ToString();
                }
            }
            public string FAMILY
            {
                get
                {
                    return Family;
                }
                set
                {
                    Family = value.ToString();
                }
            }
            public string FATHERLAND
            {
                get
                {
                    return Fatherland;
                }
                set
                {
                    Fatherland = value.ToString();
                }
            }
            public string ADDRESS
            {
                get
                {
                    return Address;
                }
                set
                {
                    Address = value.ToString();
                }
            }
            public string CREDITCARD
            {
                get
                {
                    return CreditCardNumber;
                }
                set
                {
                    CreditCardNumber = value.ToString();
                }
            }
            public int? DEBIT
            {
                get
                {
                    return Debit;
                }
                set
                {
                    Debit = value;
                }
            }
            public int? CREDIT
            {
                get
                {
                    return Credit;
                }
                set
                {
                    Credit = value;
                }
            }
           
            public Time SITYCALLS
            {
                get
                {
                    return SityCalls;
                }
               
            }                     
            
            public void Show()
            {
                Console.WriteLine(FAMILY);
                Console.WriteLine(NAME);
                Console.WriteLine(FATHERLAND);
                Console.WriteLine(DistanceCalls.Show());
                Console.WriteLine(SityCalls.Show());
                Console.WriteLine("+++++++++++++");
            }
        }
    }
}
