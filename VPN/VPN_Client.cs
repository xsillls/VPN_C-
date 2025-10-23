using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Menu_Test.VPN
{

    internal class VPN_Client
    {
        static Process myProcess;
        static bool Start_VPN()
        {
            var psi = new ProcessStartInfo
            {
                FileName = @"bin/openvpn.exe", 
                Arguments = "dsd",          // ключи
                UseShellExecute = false,        // без оболочки Windows
                CreateNoWindow = true           // без консольного окна
            };

            // Запускаем процесс и сохраняем его в переменную myProcess
            myProcess = Process.Start(psi);

            // Можно проверить, что процесс действительно стартанул
            if (myProcess != null)
            {
                Console.WriteLine("Процесс успешно запущен!");
            }
            return false;
        }
    
    }
}
