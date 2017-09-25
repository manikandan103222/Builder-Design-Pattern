using System;
namespace BuilderPattern
{
    class Program
    {
        //Identifying various parts with help of enums helper
        public enum OperatingSystem
        {
            Android,
            Symbian_OS,
            Windows_Phone,
            Windows_Mobile,
            Nokia_Asha,
            Aliyun_OS
        }
        public enum Battery
        {
            mAH_2500,
            mAH_4000,
            mAH_4500,
            mAH_5000
        }
        public enum InternalMemory
        {
            IM_250_MB, //Internal Memory 250 MB
            IM_4_GB,
            IM_8_GB,
            IM_16_GB
        }
        public enum Weight
        {
            W_100_g, //Weight 100 grams
            W_146_g,
            W_200_g,
            W_250_g
        }
        public enum WirelessCommunication
        {
            Bluetooth,
            WiFi_Hotspot
        }
        public enum Connectivity
        {
            GSM,
            CDMA,
            LTE,
            TDD
        }
        public enum ScreenType
        {
            Touch,
            Non_Touch
        }
        public enum Colour
        {
            Black,
            Green,
            Yellow,
            White,
            Gold
        }

        //'Product' Class
        class MobilePhone
        {
            public string ModelNumber { get; set; }
            public string PhoneName { get; set; }
            public OperatingSystem OperatingSystem { get; set; }
            public InternalMemory InternalMemory { get; set; }
            public Weight Weight { get; set; }
            public Battery Battery { get; set; }
            public string WirelessCommunication { get; set; }
            public string Connectivity { get; set; }
            public string Camera { get; set; }
            public Colour Colour { get; set; }
            public ScreenType ScreenType { get; set; }

            public void DisplayPhoneDetails()
            {
                Console.WriteLine(string.Format("Model Number : {0}\nPhone Name : {1}\nOperating System : {2}\n"
                    + "Internal Memory : {3}\nWeight : {4}\nBattery : {5}\nWireless Communication : {6}\n"
                    + "Connectivity : {7}\nCamera : {8}\nColour : {9}\nScreen Type : {10}", ModelNumber, PhoneName, OperatingSystem,
                    InternalMemory, Weight, Battery, WirelessCommunication, Connectivity, Camera, Colour, ScreenType));

            }
        }

        //'Builder' Interface
        interface IPhoneBuilder
        {
            void AddOS();
            void AddInternalMemory();
            void AddWeight();
            void AddBattery();
            void AddWirelessCommunication();
            void AddConnectivity();
            void AddCamera();
            void AddColour();
            void AddScreenType();

            MobilePhone GetPhone();
        }

        //'ConcreteBuilder' class - Implements builder interface
        class NormalPhoneBuilder : IPhoneBuilder
        {
            MobilePhone Phone = new MobilePhone();

            public NormalPhoneBuilder(string modelNumber, string phoneName)
            {
                Phone.ModelNumber = modelNumber;
                Phone.PhoneName = phoneName;
            }

            public void AddOS()
            {
                Phone.OperatingSystem = OperatingSystem.Symbian_OS;
            }

            public void AddInternalMemory()
            {
                Phone.InternalMemory = InternalMemory.IM_250_MB;
            }

            public void AddWeight()
            {
                Phone.Weight = Weight.W_100_g;
            }

            public void AddBattery()
            {
                Phone.Battery = Battery.mAH_2500;
            }

            public void AddWirelessCommunication()
            {
                Phone.WirelessCommunication = WirelessCommunication.Bluetooth.ToString();
            }

            public void AddConnectivity()
            {
                Phone.Connectivity = Connectivity.CDMA.ToString();
            }

            public void AddCamera()
            {
                Phone.Camera = "Not Available";
            }

            public void AddColour()
            {
                Phone.Colour = Colour.Black;
            }

            public void AddScreenType()
            {
                Phone.ScreenType = ScreenType.Non_Touch;
            }

            public MobilePhone GetPhone()
            {
                return Phone;
            }
        }

        //'ConcreteBuilder' class - Implements builder interface
        class SmartPhoneBuilder : IPhoneBuilder
        {
            MobilePhone Phone = new MobilePhone();

            public SmartPhoneBuilder(string modelNumber, string phoneName)
            {
                Phone.ModelNumber = modelNumber;
                Phone.PhoneName = phoneName;
            }

            public void AddOS()
            {
                Phone.OperatingSystem = OperatingSystem.Windows_Mobile;
            }

            public void AddInternalMemory()
            {
                Phone.InternalMemory = InternalMemory.IM_8_GB;
            }

            public void AddWeight()
            {
                Phone.Weight = Weight.W_200_g;
            }

            public void AddBattery()
            {
                Phone.Battery = Battery.mAH_4500;
            }

            public void AddWirelessCommunication()
            {
                Phone.WirelessCommunication = string.Format("{0},{1}", WirelessCommunication.Bluetooth.ToString(), WirelessCommunication.WiFi_Hotspot.ToString());
            }

            public void AddConnectivity()
            {
                Phone.Connectivity = string.Format("{0},{1},{2}",Connectivity.CDMA.ToString(), Connectivity.GSM.ToString(), Connectivity.LTE.ToString());
            }

            public void AddCamera()
            {
                Phone.Camera = "13 MP"; //13 Mega Pixcel
            }

            public void AddColour()
            {
                Phone.Colour = Colour.Gold;
            }

            public void AddScreenType()
            {
                Phone.ScreenType = ScreenType.Touch;
            }

            public MobilePhone GetPhone()
            {
                return Phone;
            }
        }

        //'Director' class - To constract mobile phone
        class MobilePhoneManufacturer
        {
            public void BuildMobilePhone(IPhoneBuilder phoneBuilder)
            {
                phoneBuilder.AddOS();
                phoneBuilder.AddInternalMemory();
                phoneBuilder.AddWeight();
                phoneBuilder.AddBattery();
                phoneBuilder.AddWirelessCommunication();
                phoneBuilder.AddConnectivity();
                phoneBuilder.AddConnectivity();
                phoneBuilder.AddCamera();
                phoneBuilder.AddColour();
                phoneBuilder.AddScreenType();
            }
        }

        static void Main(string[] args)
        {
            //Create 'Director'
            MobilePhoneManufacturer mobilePhoneManufacturer = new MobilePhoneManufacturer();

            //Build Normal Mobile Phone
            IPhoneBuilder normalPhoneBuilder = new NormalPhoneBuilder("Normal_001", "Nokia 1600");
            mobilePhoneManufacturer.BuildMobilePhone(normalPhoneBuilder);
            MobilePhone NormalMobilePhone = normalPhoneBuilder.GetPhone();

            //Display Details
            Console.WriteLine("----------------------Normal Mobile Phone Details-----------------");
            NormalMobilePhone.DisplayPhoneDetails();

            //Build Smart Phone
            Console.WriteLine("\n----------------------Smart Phone Details-----------------");
            IPhoneBuilder smartPhoneBuilder = new SmartPhoneBuilder("SmartPhone_001", "Nokia Asha");
            mobilePhoneManufacturer.BuildMobilePhone(smartPhoneBuilder);
            MobilePhone SmartPhone = smartPhoneBuilder.GetPhone();

            //Display Details
            SmartPhone.DisplayPhoneDetails();

            Console.Write("Press any key to exist...");

            Console.ReadKey();

        }
    }
}
