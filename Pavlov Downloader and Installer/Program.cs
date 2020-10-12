using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Linq;

// hello github

namespace Pavlov_Downloader_and_Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient p = new WebClient();
            String pavlovURL = "http://cdn.pavlov-vr.com/PavlovShack_Build23_0.80.60.zip";
            Directory.CreateDirectory("C:/Program Files (x86)/ModernEra");
            Console.WriteLine("Checking for Pavlov...");
            if  (!Directory.Exists("C:/Program Files (x86)/ModernEra/pavlov"))
            {
                Console.WriteLine("Downloading Pavlov...");
                Uri pavlov = new Uri(pavlovURL);
                String filename = new string("C:/Program Files (x86)/ModernEra/pavlov.zip");
                p.DownloadFile(pavlov, filename);
                Console.WriteLine("Pavlov Downloaded! Unzipping...");
                ZipFile.ExtractToDirectory("C:/Program Files (x86)/ModernEra/pavlov.zip", "C:/Program Files (x86)/ModernEra/pavlov");
                Console.WriteLine("Pavlov unzipped! Starting installation...");
                if (File.Exists("C:/Program Files (x86)/ModernEra/pavlov/name.txt"))
                {
                    File.Delete("C:/Program Files (x86)/ModernEra/pavlov/name.txt");
                }
                Console.WriteLine("What do you want your name to be?");
                String name = Console.ReadLine();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:/Program Files (x86)/ModernEra/pavlov/name.txt", true))
                {
                    file.WriteLine(name);
                }
                string[] bruh = File.ReadLines("C:/Program Files (x86)/ModernEra/pavlov/install.bat").ToArray();
                int counter = 0;
                foreach (string line in bruh)
                {
                    if (line.StartsWith("set ADB="))
                    {
                        bruh[counter] = "set ADB = C:/Program Files (x86)/ModernEra/pavlov/platform-tools/win/adb.exe";
                    }
                    counter++;
                }
                File.Delete("C:/Program Files (x86)/ModernEra/pavlov/install.bat");
                System.IO.File.WriteAllLines("C:/Program Files (x86)/ModernEra/pavlov/install.bat", bruh);
                System.Diagnostics.Process.Start("C:/Program Files (x86)/ModernEra/pavlov/install.bat");
            } else
            {
                Console.WriteLine("You already have Pavlov downloaded! Do you want to redownload it (yes/no), delete it (delete) or install the game with it (install)?");
                String yeet = Console.ReadLine();
                yeet = yeet.ToLower();
                if (yeet.Equals("yes"))
                {
                    File.Delete("C:/Program Files (x86)/ModernEra/pavlov.zip");
                    Console.WriteLine("Downloading Pavlov...");
                    Uri pavlov = new Uri(pavlovURL);
                    String filename = new string("C:/Program Files (x86)/ModernEra/pavlov.zip");
                    p.DownloadFile(pavlov, filename);
                    Console.WriteLine("Pavlov Downloaded! Unzipping...");
                    ZipFile.ExtractToDirectory("C:/Program Files (x86)/ModernEra/pavlov.zip", "C:/Program Files (x86)/ModernEra/pavlov");
                    if (File.Exists("C:/Program Files (x86)/ModernEra/pavlov/name.txt"))
                    {
                        File.Delete("C:/Program Files (x86)/ModernEra/pavlov/name.txt");
                    }
                    Console.WriteLine("What do you want your name to be?");
                    String name = Console.ReadLine();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:/Program Files (x86)/ModernEra/pavlov/name.txt", true))
                    {
                        file.WriteLine(name);
                    }
                    Console.WriteLine("Pavlov unzipped! Starting installation...");
                    string[] bruh = File.ReadLines("C:/Program Files (x86)/ModernEra/pavlov/install.bat").ToArray();
                    int counter = 0;
                    foreach (string line in bruh)
                    {
                        if (line.StartsWith("set ADB="))
                        {
                            bruh[counter] = "set ADB = C:/Program Files (x86)/ModernEra/pavlov/platform-tools/win/adb.exe";
                        }
                        counter++;
                    }
                    File.Delete("C:/Program Files (x86)/ModernEra/pavlov/install.bat");
                    System.IO.File.WriteAllLines("C:/Program Files (x86)/ModernEra/pavlov/install.bat", bruh);
                    System.Diagnostics.Process.Start("C:/Program Files (x86)/ModernEra/pavlov/install.bat");

                }
                else if (yeet.Equals("delete"))
                {
                    if (Directory.Exists("C:/Program Files (x86)/ModernEra/pavlov"))
                    {
                        Directory.Delete("C:/Program Files (x86)/ModernEra/pavlov/", true);
                    }
                    if (File.Exists("C:/Program Files (x86)/ModernEra/pavlov.zip"))
                    {
                        File.Delete("C:/Program Files (x86)/ModernEra/pavlov.zip");
                    }
                    Console.WriteLine("All done! Press any key to exit.");
                }
                else if (yeet.Equals("install"))
                {
                    if (File.Exists("C:/Program Files (x86)/ModernEra/pavlov/name.txt"))
                    {
                        File.Delete("C:/Program Files (x86)/ModernEra/pavlov/name.txt");
                    }
                    Console.WriteLine("What do you want your name to be?");
                    String name = Console.ReadLine();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:/Program Files (x86)/ModernEra/pavlov/name.txt", true))
                    {
                        file.WriteLine(name);
                    }
                    Console.WriteLine("Starting installation...");
                    string[] bruh = File.ReadLines("C:/Program Files (x86)/ModernEra/pavlov/install.bat").ToArray();
                    int counter = 0;
                    foreach (string line in bruh)
                    {
                        if (line.StartsWith("set ADB="))
                        {
                            bruh[counter] = "set ADB = C:/Program Files (x86)/ModernEra/pavlov/platform-tools/win/adb.exe";
                        }
                        counter++;
                    }
                    File.Delete("C:/Program Files (x86)/ModernEra/pavlov/install.bat");
                    System.IO.File.WriteAllLines("C:/Program Files (x86)/ModernEra/pavlov/install.bat", bruh);
                    System.Diagnostics.Process.Start("C:/Program Files (x86)/ModernEra/pavlov/install.bat");
                } else
                {
                    Console.WriteLine("Ok then, see ya!");
                }
            }
            Console.ReadLine();
        }
    }
}
