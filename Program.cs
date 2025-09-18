using AutoUpdaterDotNET;

namespace GRandEddie
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string x = "Hello World";


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            AutoUpdater.ShowSkipButton = false;
            AutoUpdater.RunUpdateAsAdmin = true;
            //AutoUpdater.Start("https://raw.githubusercontent.com/EddieMac74/AllSideCratingSetup/main/E4C.txt");
           
            Application.Run(new MDIParent1(x));
        }
    }
}