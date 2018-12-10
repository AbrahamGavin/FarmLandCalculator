using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmLand_Calculator
    //By Gavin Abraham
{
    class Program
    {
        enum Croptype
        {
            Beans,
            Corn,
            Wheat,
            Potatoes,
            Rice,
            Peas,



        }
        static void Main(string[] args)
        {


            DisplayOpeningScreen();
            DisplayMainMenu();
            DisplayClosingScreen();
        }

        /// <summary>
        /// application loop with menu
        /// </summary>
        static void DisplayMainMenu()
        {
            string menuChoice;
            bool applicationLoopRunning = true;
            List<FarmItem> inventory;
            

            

            //
            // initialize inventory
            //
            inventory = InitializeInventory();

            while (applicationLoopRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine();

                Console.WriteLine("\t1) Display Land Items");
                Console.WriteLine("\t2) Add Land/Crop Items");
                Console.WriteLine("\t3) Pull up Information for Corn");
                Console.WriteLine("\tE) Exit");
                Console.WriteLine();
                Console.Write("Enter Choice:");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        DisplayInventory(inventory);
                        break;

                    case "2":
                        DisplayAddFarmItem(inventory);
                        break;

                    case "3":
                        //DisplayDataTable();
                        DisplayStandardMoistureTable();
                        break;

                    case "e":
                    case "E":
                        applicationLoopRunning = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private static void DisplayStandardMoistureTable()
        {
            DisplayHeader("Corn Information Screen");
            Console.WriteLine("Average Corn Moistures Range Between 20-25% at best harvest times");

            DisplayContinuePrompt();
        }



        /// <summary>
        /// display inventory
        /// </summary>
        static void DisplayInventory(List<FarmItem> inventory)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Clear();
            DisplayHeader("Inventory");
            double grandTotal=0;
            double areaAmountage = 0;
            double total = 0;
            Console.WriteLine("Name: Location".PadRight(30) + "Length Of Field".PadLeft(10) + "Width Of Field".PadLeft(15) + "Total Acreage".PadLeft(20) + "Grand Total Bushels".PadLeft(25));
            Console.WriteLine("--------------".PadRight(30) + "---------------".PadLeft(10) + "--------------".PadLeft(15) + "-------------".PadLeft(20) + "-------------------".PadLeft(25));
            foreach (FarmItem item in inventory)
            {
                total = item._bushels + total;
                areaAmountage = item.AreaAmount + areaAmountage;
                grandTotal = areaAmountage * total;

                Console.WriteLine(item.DisplayCropLocationName().PadRight(30) + item._Length.ToString().PadLeft(10) + item._width.ToString().PadLeft(15) + item.AreaAmount.ToString().PadLeft(30) + grandTotal.ToString().PadLeft(25));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Bushels/Acre");
                Console.WriteLine("------------");
                Console.WriteLine(item._bushels.ToString());
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Total Bushels/Acre");
            Console.WriteLine("------------------");
            Console.WriteLine(total);
            Console.WriteLine();
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        /// <summary>
        /// add a house item
        /// </summary>
        static void DisplayAddFarmItem(List<FarmItem> inventory)
        {

            double length;
            double width;
            double percentMoisture;
            double numberEars;
            
            double earWeight;
            
            double resultBa;double resultA;double resultBb;double resultFinalA;
            DisplayHeader("Add a New Farm Item");

            //
            // create house item object
            //

            FarmItem item = new FarmItem();


            //
            // set the house item object's properties
            //

            Console.Write("Enter Land Name:");
            item.Name = Console.ReadLine();
            Console.WriteLine("Enter Crop Type");
            item.cropName = Console.ReadLine();
            Console.WriteLine("Enter Land Area (LENGTH) in feet");
            double.TryParse(Console.ReadLine(), out length);
            item._Length = length;
            Console.WriteLine("Enter Land Area (WIDTH) in feet");
            double.TryParse(Console.ReadLine(), out width);
            item._width = width;
            item.AreaAmount = length * width / 43560;
            Console.WriteLine("Enter Number of Ears per 17 foot section");
            double.TryParse(Console.ReadLine(), out numberEars);
            Console.WriteLine("Enter Average Ear weight in pounds");
            double.TryParse(Console.ReadLine(), out earWeight);
            resultA = numberEars * earWeight;
            Console.WriteLine("Enter Average Grain Moisture(Percentage as whole number)");
            double.TryParse(Console.ReadLine(), out percentMoisture);
            resultBa = percentMoisture * 1.411;
            resultBb = resultBa + 46.2;
            resultFinalA = resultA / resultBb;
            item._bushels = resultFinalA * 1000;
            



            
            
            
            
                
            

            Console.WriteLine("---------------------------------------------------------------");
           






            //
            // add house item object to inventory list
            //
            inventory.Add(item);

            //
            // confirm house item added to inventory
            //
            Console.WriteLine($"{item.Name} had been added to your inventory");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// intialize list of inventory with list of house items
        /// </summary>
        static List<FarmItem> InitializeInventory()
        {
            List<FarmItem> inventory = new List<FarmItem>();

            //
            // create (instantiate) farm item objects
            //
            //------------------------------------------------------------------------------
            FarmItem item1 = new FarmItem();

            //------------------------------------------------------------------------------
            //
            // add stuff objects to inventory list
            //


            return inventory;
        }

        /// <summary>
        /// clear screen and display header
        /// </summary>
        static void DisplayHeader(string header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + header);
            Console.WriteLine();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display opening screem
        /// </summary>
        static void DisplayOpeningScreen()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tFarm Crop Calculator");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using our application.");
            Console.WriteLine();

            DisplayContinuePrompt();
        }
    }

    /// <summary>
    /// class of Farm Items
    /// </summary>
    class FarmItem
    {
        #region FIELDS

        private string LandName;
        private double LandArea;
        private string Crop;
        private double Length;
        private double Width;
        
        private double Bushels;
        private double percentMoisture;
        private double itemBushels2;
        #endregion

        #region PROPERTIES


        public string Name
        {
            get { return LandName; }
            set { LandName = value; }
        }
        public double AreaAmount
        {
            get { return LandArea; }
            set { LandArea = value; }
        }
        public string cropName
        {
            get { return Crop; }
            set { Crop = value; }
        }
        public double _Length
        {
            get { return Length; }
            set { Length = value; }
        }
        public double _width
        {
            get { return Width; }
            set { Width = value; }
        }
        public double _bushels
        {
            get { return Bushels; }
            set { Bushels = value; }
        }
        public double percentmoisture
        {
            get { return percentMoisture; }
            set { percentMoisture = value; }
        }
        public double bushels2
        {
            get { return itemBushels2; }
            set { itemBushels2 = value; }
        }














        #endregion

        #region METHODS
        public string DisplayCropLocationName()
        {
            string cropLocationName;
            cropLocationName = LandName + ": " + Crop;
            return cropLocationName;

        }

        //internal object AreaAmount()
        //{
        //    throw new NotImplementedException();
        //}



        #endregion

        #region CONSTRUCTORS



        #endregion
    }
}

