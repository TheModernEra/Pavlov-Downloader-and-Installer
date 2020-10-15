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
            String filesFolder = Path.GetPathRoot(Environment.SystemDirectory);
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra");
            Console.WriteLine("Checking for Pavlov...");
            if  (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov"))
            {
                Console.WriteLine("You haven't downloaded Pavlov yet! Would you like to download and install it (download) or (exit)?");
                String hoefosho = Console.ReadLine();
                hoefosho = hoefosho.ToLower();
                if (hoefosho.Equals("download"))
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
                
                    // THIS IS BROKEN CAUSE ADB HAS NOT BEEN DOWNLOADED YET AND IM TOO LAZY TO TAKE IT OUT  
                } else if (hoefosho.Equals("options"))
                {
                    Console.WriteLine("Would you like to change your name (name), uninstall the game (uninstall), or set permissions (perms)?");
                    String ayodapizzahere = Console.ReadLine();
                    ayodapizzahere = ayodapizzahere.ToLower();
                    if (ayodapizzahere.Equals("name"))
                    {
                        Console.WriteLine("What do you want your name to be?");
                        String name = Console.ReadLine();
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt"))
                        {
                            File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt");
                        }
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt", true))
                        {
                            file.WriteLine(name);
                        }
                        Console.WriteLine("Setting name...");
                        Process process = new Process();
                        process = System.Diagnostics.Process.Start(adbLocation, "push " + filesFolder + "\\" + "\"Program Files (x86)\\ModernEra\\pavlov\\name.txt\"" + " /sdcard/pavlov.name.txt");
                        process.WaitForExit();
                        foreach (var bitch in Process.GetProcessesByName("adb"))
                        {
                            bitch.Kill();
                        }
                        Console.WriteLine("Name set! Press any key to exit.");
                    } else if (ayodapizzahere.Equals("uninstall"))
                    {
                        Console.WriteLine("Uninstalling Pavlov...");
                        Process process = new Process();
                        process = System.Diagnostics.Process.Start(adbLocation, "uninstall com.vankrupt.pavlov");
                        process.WaitForExit();
                        foreach (var bitch in Process.GetProcessesByName("adb"))
                        {
                            bitch.Kill();
                        }
                        Console.WriteLine("Pavlov uninstalled! Press any key to exit.");
                    } else if (ayodapizzahere.Equals("perms"))
                    {
                        Console.WriteLine("Setting permissions...");
                        Process process = new Process();
                        process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO");
                        process.WaitForExit();
                        process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE");
                        process.WaitForExit();
                        process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE");
                        process.WaitForExit();
                        foreach (var bitch in Process.GetProcessesByName("adb"))
                        {
                            bitch.Kill();
                        }
                        Console.WriteLine("Permissions set! Press any key to exit.");
                    }
                } else
                {
                    Console.WriteLine("Ok, you know where to find me if you need me I guess");
                }
            } else
            {
                Console.WriteLine("You already have Pavlov downloaded! Do you want to redownload it (redownload), delete it (delete), install to your Quest with it (install), change your name in-game (name), uninstall the game (uninstall), set permissions for the game (perms) or (exit)?");
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
                } else if (yeet.Equals("name"))
                {
                    Console.WriteLine("What do you want your name to be?");
                    String name = Console.ReadLine();
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt");
                    }
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\ModernEra\\pavlov\\name.txt", true))
                    {
                        file.WriteLine(name);
                    }
                    Console.WriteLine("Setting name...");
                    Process process = new Process();
                    process = System.Diagnostics.Process.Start(adbLocation, "push " + filesFolder + "\\" + "\"Program Files (x86)\\ModernEra\\pavlov\\name.txt\"" + " /sdcard/pavlov.name.txt");
                    process.WaitForExit();
                    foreach (var bitch in Process.GetProcessesByName("adb"))
                    {
                        bitch.Kill();
                    }
                    Console.WriteLine("Name set! Press any key to exit.");
                } else if (yeet.Equals("perms"))
                {
                    Console.WriteLine("Setting permissions...");
                    Process process = new Process();
                    process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO");
                    process.WaitForExit();
                    process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE");
                    process.WaitForExit();
                    process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE");
                    process.WaitForExit();
                    foreach (var bitch in Process.GetProcessesByName("adb"))
                    {
                        bitch.Kill();
                    }
                    Console.WriteLine("Permissions set! Press any key to exit.");
                } else if (yeet.Equals("uninstall"))
                {
                    Console.WriteLine("Uninstalling Pavlov...");
                    Process process = new Process();
                    process = System.Diagnostics.Process.Start(adbLocation, "uninstall com.vankrupt.pavlov");
                    process.WaitForExit();
                    foreach (var bitch in Process.GetProcessesByName("adb"))
                    {
                        bitch.Kill();
                    }
                    Console.WriteLine("Pavlov uninstalled! Press any key to exit.");
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
            process = System.Diagnostics.Process.Start(adbLocation, "uninstall com.vankrupt.pavlov");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "uninstall com.davevillz.pavlov");
            process.WaitForExit();
            String filesFolder = Path.GetPathRoot(Environment.SystemDirectory);
            String apkCommand = "install " + filesFolder + "\\" + "\"Program Files (x86)\\ModernEra\\pavlov\\Pavlov-Android-Shipping-arm64-es2.apk\"";
            process = System.Diagnostics.Process.Start(adbLocation, apkCommand);
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.RECORD_AUDIO");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.READ_EXTERNAL_STORAGE");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "-d shell pm grant com.vankrupt.pavlov android.permission.WRITE_EXTERNAL_STORAGE");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "-d shell mkdir /sdcard/Android/obb/com.vankrupt.pavlov");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "push " + filesFolder + "\\" + "\"Program Files (x86)\\ModernEra\\pavlov\\main.23.com.vankrupt.pavlov.obb\"" + " /sdcard/Android/obb/com.vankrupt.pavlov");
            process.WaitForExit();
            process = System.Diagnostics.Process.Start(adbLocation, "push " + filesFolder + "\\" + "\"Program Files (x86)\\ModernEra\\pavlov\\name.txt\"" + " /sdcard/pavlov.name.txt");
            process.WaitForExit();
            foreach (var bitch in Process.GetProcessesByName("adb"))
            {
                bitch.Kill();
            }
        }
    }
}
