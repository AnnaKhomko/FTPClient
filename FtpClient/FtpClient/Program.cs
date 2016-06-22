using System;
using System.Collections.Generic;

namespace FtpClient
{
    class Program
    {
        static string pathToDownload = "D://"; //where to download
        static string ftpServer = "ftp://ftp.man.lodz.pl/"; //server address
        static string currAddress = "", prevAddress = "";
        
        static void Main(string[] args)
        {
            int k = Convert.ToInt32(Console.ReadLine());
            Program program = new Program();
            prevAddress = currAddress = ftpServer;
            Client cl;
            while (true)
            {
                Console.Clear();

                cl = new Client(currAddress, "", "");

                List<FileInformation> list = Function.GetFilesAndDirectories(cl);
                Console.WriteLine(cl.URI);
                Function.PrintFiles(list);

                //menu
                cl.ShowMenu();

                switch (k)
                {
                    case 1:
                        Console.WriteLine("\nEnter directory name:");
                        String dirName = Console.ReadLine();
                        if (dirName.Equals("...")) // return to the previous Directory
                        {
                            Program.currAddress = prevAddress;
                        }
                        else
                        {
                            prevAddress = cl.URI;
                            currAddress = cl.URI + dirName + "/";
                        }
                        break;
                    case 2:
                        Console.WriteLine("\nEnter file name:");
                        String fileName = Console.ReadLine();
                        cl.DownloadFile(fileName, pathToDownload + fileName);
                        break;
                    case 3: break;
                }

            }
        }

               
    }

   

    
}
