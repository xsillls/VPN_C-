using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using System.Threading.Tasks;

class Save_Config_User
{
    public string name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string rait { get; set; }
    public string time { get; set; }
}

namespace C_Menu_Test
{
    internal class File_User
    {
        private static int language;

        static public int Get_language()
        {
            return language;
        }
        static public void Set_language(int language_set)
        {
            language = language_set;
        }

        private const string path = @"Config.conf";
        private const string path_seting = @"Seting_conf.conf";
        static public bool File_Exists()
        {
            
            if (File.Exists(path))
                return true;
            return false;
             
        }
        static public bool File_Exists_Seting()
        {

            if (File.Exists(path_seting))
                return true;
            return false;

        }

        static public Save_Config_User Open_File_To_Read()
        {
            // Если файла нет  создаём новый с пустыми значениями
            if (!File.Exists(path))
            {
                Save_Config_User conf = new Save_Config_User
                {
                    name = "",
                    email = "",
                    password = "",
                    rait = "",
                    time = ""
                };

                string json = JsonConvert.SerializeObject(conf, Formatting.Indented);
                File.WriteAllText(path, json);
            }

            // Читаем файл и возвращаем объект
            string fileJson = File.ReadAllText(path);
            Save_Config_User result = JsonConvert.DeserializeObject<Save_Config_User>(fileJson);

            return result;
        }

        static public void Save_File(Save_Config_User conf)
        {
            // Если файла нет — создаём пустой
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "{}");
            }

            // Сериализация и запись
            string json = JsonConvert.SerializeObject(conf, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        static public string[] Open_File_To_Read_Seting()
        {
            string[] text = File.ReadAllLines(path_seting);
            return text;
        }
    }
}
 