using System;
using System.IO;
using System.Net;
using System.IO.Compression;
using System.Diagnostics;
// hello github

namespace Pavlov_Downloader_and_Installer
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var process in Process.GetProcessesByName("adb"))
            {
                process.Kill();
            }
            WebClient p = new WebClient();
            String adbLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\platform-tools\\win\\adb.exe";
            String pavlovURL = "http://cdn.pavlov-vr.com/PavlovShack_Build23_0.80.60.zip";
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra");
            Console.WriteLine("Checking for Pavlov...");
            if  (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov"))
            {
                Console.WriteLine("Downloading Pavlov...");
                Uri pavlov = new Uri(pavlovURL);
                String filename = new string(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov.zip");
                p.DownloadFile(pavlov, filename);
                Console.WriteLine("Pavlov Downloaded! Unzipping...");
                ZipFile.ExtractToDirectory(filename, Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov");
                Console.WriteLine("Pavlov unzipped! Starting installation...");
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt");
                }
                Console.WriteLine("What do you want your name to be?");
                String name = Console.ReadLine();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt", true))
                {
                    file.WriteLine(name);
                }
                adbCommands();
                Console.WriteLine("Install complete! Press any key to exit.");
            } else
            {
                Console.WriteLine("You already have Pavlov downloaded! Do you want to redownload it (redownload), delete it (delete), install to your Quest with it (install) or (exit)?");
                String yeet = Console.ReadLine();
                yeet = yeet.ToLower();
                if (yeet.Equals("redownload"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov.zip");
                    Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov", true);
                    Console.WriteLine("Downloading Pavlov...");
                    Uri pavlov = new Uri(pavlovURL);
                    String filename = new string(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov.zip");
                    p.DownloadFile(pavlov, filename);
                    Console.WriteLine("Pavlov Downloaded! Unzipping...");
                    ZipFile.ExtractToDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov.zip", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov");
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt");
                    }
                    Console.WriteLine("What do you want your name to be?");
                    String name = Console.ReadLine();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt", true))
                    {
                        file.WriteLine(name);
                    }
                    Console.WriteLine("Pavlov unzipped! Starting installation...");
                    adbCommands();
                    Console.WriteLine("Install complete! Press any key to exit.");
                }
                else if (yeet.Equals("delete"))
                {
                    if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov"))
                    {
                        Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov", true);
                    }
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov.zip"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov.zip");
                    }
                    Console.WriteLine("All done! Press any key to exit.");
                }
                else if (yeet.Equals("install"))
                {
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt");
                    }
                    Console.WriteLine("What do you want your name to be?");
                    String name = Console.ReadLine();
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt", true))
                    {
                        file.WriteLine(name);
                    }
                    Console.WriteLine("Starting installation...");
                    adbCommands();
                    Console.WriteLine("Install complete! Press any key to exit.");
                } else if (yeet.Equals("exit"))
                {
                    Console.WriteLine("Ok then, see ya!");
                } else
                {
                    Console.WriteLine("I don't know what that means, be more specific. Better luck next time! :)");
                }
            }
            Console.ReadLine();
        }
        static void adbCommands()
        {
            String adbLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\platform-tools\\win\\adb.exe";
            Process process = new Process();
            process = System.Diagnostics.Process.Start(adbLocation, "uninstall com.yuh.pavlov");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "uninstall com.davevillz.pavlov");
            process.WaitForExit();
            String apkCommand = "install " + @Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\Pavlov-Android-Shipping-arm64-es2.apk";
            Console.WriteLine(apkCommand);
            System.Diagnostics.Process.Start(adbLocation, apkCommand);
            process.WaitForExit();
        }
    }
}
