using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Security.Principal;
using System.Windows.Forms;

namespace MyRMS
{
    internal static class Computer
    {
        //Instant C# Notes:
        //Calls to My.Computer.Clipboard have been redirected to System.Windows.Forms.Clipboard
        //Calls to My.Computer.FileSystem have been redirected to Microsoft.VisualBasic.FileIO.FileSystem
        //Calls to My.Computer.Registry have been redirected to Microsoft.Win32.Registry

        internal readonly static Audio Audio;
        internal readonly static Clock Clock;
        internal readonly static ComputerInfo Info;
        internal readonly static Keyboard Keyboard;
        internal readonly static Mouse Mouse;
        internal readonly static string Name;
        internal readonly static Network Network;
        internal readonly static Ports Ports;
        internal readonly static Screen Screen;

        static Computer()
        {
            Audio = new Audio();
            Clock = new Clock();
            Info = new ComputerInfo();
            Keyboard = new Keyboard();
            Mouse = new Mouse();
            Network = new Network();
            Ports = new Ports();
            Screen = Screen.PrimaryScreen;

            ServerComputer ThisServerComputer = new ServerComputer();
            Name = ThisServerComputer.Name;
        }
    }

    internal static class User
    {
        private static Microsoft.VisualBasic.ApplicationServices.User ThisUser = new Microsoft.VisualBasic.ApplicationServices.User();

        internal static IPrincipal CurrentPrincipal
        {
            get
            {
                return ThisUser.CurrentPrincipal;
            }
        }
        internal static bool IsAuthenticated
        {
            get
            {
                return ThisUser.IsAuthenticated;
            }
        }
        internal static string Name
        {
            get
            {
                return ThisUser.Name;
            }
        }
        internal static void InitializeWithWindowsUser()
        {
            ThisUser.InitializeWithWindowsUser();
        }
        internal static bool IsInRole(BuiltInRole ThisRole)
        {
            return ThisUser.IsInRole(ThisRole);
        }
        internal static bool IsInRole(string ThisRole)
        {
            return ThisUser.IsInRole(ThisRole);
        }
    }
}
