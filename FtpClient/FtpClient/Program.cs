using System;
using System.Collections.Generic;

namespace FtpClient
{
    class Program
    {
        static string DIR_FOR_DOWNLOAD = "D://"; //where to download
        static string FTP_SERVER = "ftp://ftp.man.lodz.pl/"; //server address
        static string CURR_ADDRESS = "", PREV_ADDRESS = "";
        
        static void Main(string[] args)
        {
            Program program = new Program();
            String k;
            PREV_ADDRESS = CURR_ADDRESS = FTP_SERVER;
            Client cl;
            while (true)
            {
                Console.Clear();

                cl = new Client(CURR_ADDRESS, "", "");

                List<FileInformation> list = Function.GetFilesAndDirectories(cl);
                Console.WriteLine(cl.URI);
                Function.PrintFiles(list);

                //menu
                Console.WriteLine("1 - open directory");
                Console.WriteLine("2 - download file");
                Console.WriteLine("3 - exit");

                k = Console.ReadLine();

                if (k.Equals("1"))
                {
                    Console.WriteLine("\nEnter directory name:");
                    String name = Console.ReadLine();
                    if (name.Equals("...")) // return to the previous Directory
                    {
                        CURR_ADDRESS = PREV_ADDRESS;
                    }
                    else
                    {
                        PREV_ADDRESS = cl.URI;
                        CURR_ADDRESS = cl.URI + name + "/";
                    }
                }
                else if (k.Equals("2"))
                {
                    Console.WriteLine("\nEnter file name:");
                    String name = Console.ReadLine();
                    cl.DownloadFile(name, DIR_FOR_DOWNLOAD + name);
                }
                else if (k.Equals("3"))
                {
                    break;
                }
            }
        }

               
    }

   

    
}
