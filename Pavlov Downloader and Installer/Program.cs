﻿using System;
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
            String adbLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\platform-tools\\win\\adb.exe";
            Console.WriteLine(adbLocation);
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
                // add individual adb commands here
                String command = "devices";
                System.Diagnostics.Process.Start(adbLocation, command);
            } else
            {
                Console.WriteLine("You already have Pavlov downloaded! Do you want to redownload it (yes/no), delete it (delete) or install the game with it (install)?");
                String yeet = Console.ReadLine();
                yeet = yeet.ToLower();
                if (yeet.Equals("yes"))
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
                    String command = "devices";
                    System.Diagnostics.Process.Start(adbLocation, command);
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
                    String command = "devices";
                    System.Diagnostics.Process.Start(adbLocation, command);
                } else
                {
                    Console.WriteLine("Ok then, see ya!");
                }
            }
            Console.ReadLine();
        }
    }
}
