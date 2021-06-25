using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace VaccineChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string PersonJsonFilename  = "";
            string CentersJsonFilename = "";

            if (args.Length == 0)
            {
                PersonJsonFilename = AppDomain.CurrentDomain.BaseDirectory + "people.txt";
                CentersJsonFilename = AppDomain.CurrentDomain.BaseDirectory + "centers.txt";
            }
            else
            {
                if (args.Length > 1)
                {
                    PersonJsonFilename = AppDomain.CurrentDomain.BaseDirectory + args[0];
                    CentersJsonFilename = AppDomain.CurrentDomain.BaseDirectory + args[1];
                }
                else
                {
                    Console.WriteLine("Arguments is missing, Please provide data files");
                    return;
                }
            }


            Console.WriteLine("-Begin read the file :" + PersonJsonFilename);
            List<Person> personsList = LoadPersonsDataFromJson(PersonJsonFilename);
            Console.WriteLine("-Loading Completed with total of " + personsList.Count + " Persons");
            Console.WriteLine("-Begin read the file :" + CentersJsonFilename);
            List<VaccineCenter> centersList = LoadCentersDataFromJson(CentersJsonFilename);
            Console.WriteLine("-Loading Completed with total of " + centersList.Count + " Centers");
            
            if (personsList.Count() != 0 && centersList.Count() !=0)
            {
             
                //Get Nearest Center from the person
                foreach (var person in personsList)
                {
                    person.NearestCenter = Calculations.GetNearestCenter(person.Lat, person.Longt, centersList);
                }

                DisplayData(personsList);
            }

            Console.WriteLine("------------------------------------------------------------------");

            Console.WriteLine("Press Any key to exit");
            Console.ReadKey();
        }

        /// <summary>
        /// Load Vaccination Center Array from Json File
        /// <param name="JsonFilePath">Json file path which contains the Centers data</param>
        /// <returns>list of vaccine center objects</returns>
        /// </summary>
        static List<VaccineCenter> LoadCentersDataFromJson(string JsonFilePath)
        {
            List<VaccineCenter> centersList = new List<VaccineCenter>();
            try
            {
                if (File.Exists(JsonFilePath))
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    using (StreamReader sr = new StreamReader(JsonFilePath))
                    {
                        sb.Append(sr.ReadToEnd());
                    }
                    centersList = JsonConvert.DeserializeObject<List<VaccineCenter>>(sb.ToString());
                    GC.Collect();
                }
                else
                {
                    Console.WriteLine("Vaccine Centers File Is not Found in Path:" + JsonFilePath);
                }
                return centersList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Vaccine Centers File Format is invalid");
                //
                return centersList;
            }
        }

        /// <summary>
        /// Load Person's Array from Json File
        /// </summary>
        /// <param name="JsonFilePath">Json file path which contains the persons data</param>
        /// <returns>list of persons objects</returns>
        public static List<Person> LoadPersonsDataFromJson(string JsonFilePath)
        {
            List<Person> personsList = new List<Person>();

            try
            {
                if (File.Exists(JsonFilePath))
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    using (StreamReader sr = new StreamReader(JsonFilePath))
                    {
                        sb.Append(sr.ReadToEnd());
                    }
                    personsList = JsonConvert.DeserializeObject<List<Person>>(sb.ToString());
                    GC.Collect();
                }
                else
                {
                    Console.WriteLine("Persons Data File Is not Found in Path:" + JsonFilePath);
                }

                return personsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Persons Data File Format is invalid");
                //
                return personsList;
            }
        }

        /// <summary>
        /// Display the persons data on screen
        /// </summary>
        /// <param name="personsList">Persons list</param>
        private static void DisplayData(List<Person> personsList)
        {
            //group Data by the nearest branch
            var resultGrouping = from person in personsList
                                 group person by person.NearestCenter
                                     into centergroup
                                 select centergroup;
            Console.WriteLine("-Distribution To The Vaccination Centers :");

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-40} \t {1,-10}", "Center Name", "Number Of Persons"));
            Console.WriteLine(String.Format("{0,-40} \t {1,-10}", "-----------", "----------------- "));
            foreach (var centergroup in resultGrouping)
            {
                Console.WriteLine(String.Format("{0,-40} \t {1,-10}", centergroup.Key, centergroup.Count()));
            }
           

            int countCenters = 1;
            foreach (var centergroup in resultGrouping)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine((countCenters).ToString() + ") Center Name : {0} ", centergroup.Key);
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,-30} \t {1,-10} \t {2,-30}", "Name", "Age", "Contact"));
                Console.WriteLine(String.Format("{0,-30} \t {1,-10} \t {2,-30}", "----", "---- ", "------"));
                //Display Data After Ordering by Age Descending
                foreach (var _person in centergroup.OrderByDescending(x => x.Age))
                {
                    Console.WriteLine(String.Format("{0,-30} \t {1,-10} \t {2,-30}", _person.Name, _person.Age, _person.Contact));
                }
                countCenters++;
                Console.WriteLine();
            }


        }
    }
}