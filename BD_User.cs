using C_Menu_Test;
using LiteDB;       // Для работы с LiteDB
using System;       // Для Console.WriteLine
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

// ----------------------------
// 1. Создаём класс "User" - это наша "таблица пользователей"
// ----------------------------
public class User
{
    public int Id { get; set; }          // Уникальный идентификатор пользователя
    public string Username { get; set; } // Имя пользователя
    public string Password { get; set; } // Пароль пользователя
    public string Email { get; set; }    // Почта пользователя
    public int Rait { get; set; }
    public int Time { get; set; }

}

// ----------------------------
// 2. Основная программа
// ----------------------------
class BD_Clietn
{
    static LiteDatabase db;
    static public LiteDatabase Open_Base(string name_base)
    {

        db = new LiteDatabase("VPNUsers.db");

        return db;
    }
    static public ILiteCollection<User> GetUsers()
    {
        return db.GetCollection<User>("users");
    }
    static public ILiteCollection<User> GetUsers(LiteDatabase db)
    {
        return db.GetCollection<User>("users");
    }


    static public void Add_User(string UserName, string Password, string Email)
    {
        ILiteCollection<User> users = GetUsers();
        var user1 = new User
        {
            Username = UserName,
            Password = Password,
            Email = Email
            //Rait = 0,
            //Time = 0

        };
        users.Insert(user1);
    }
    static public uint Add_User(ILiteCollection<User> users, string User_Name, string Password_User, string Email_User)
    {
        //1 - Error_name
        //2 - Error_Email
        //3 - Good
        var exists_Name = users.FindOne(u => u.Username == User_Name);
        if (exists_Name != null)
            return 1;

        var exists_Email = users.FindOne(u => u.Email == Email_User);
        if (exists_Email != null)
            return 2;

        var user1 = new User
        {
            Username = User_Name,
            Password = Password_User,
            Email = Email_User,
            Rait = 0,
            Time = 0

        };
        users.Insert(user1);
        return 3;
    }
    static public bool CheckLogin(ILiteCollection<User> users, string username, string password)
    {
        
        var user = users.FindOne(u => u.Username == username && u.Password == password);

        
        return user != null;
    }


    static public void Close_BD()
    {
        db.Dispose();
    }
    static public void Close_BD(LiteDatabase base_custom)
    {
        base_custom.Dispose();
    }

}
