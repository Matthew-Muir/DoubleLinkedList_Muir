using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public static class DeployCSVFile
    {

        public static void VerifyPathForInstall()
        {
            if (Directory.Exists(@"C:\tmp")) // If directory exists... Does the file exist... If ! then create file
            {
                if (!File.Exists(@"C:\tmp\yob2019.txt"))
                {
                    File.WriteAllText(@"C:\tmp\yob2019.txt", Resource1.yob2019);
                }
                
            }
            else //The directory doesn't exist so create it... Add file to it.
            {
                Directory.CreateDirectory(@"C:\tmp");
                File.WriteAllText(@"C:\tmp\yob2019.txt", Resource1.yob2019);

            }
        }

    }
}
