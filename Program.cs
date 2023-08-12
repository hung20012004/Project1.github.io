using System;
using System.Data;
using System.Text;
using Project1.GUI;
using Project1.BUS;
using Project1.DAL;
using Project1;

Console.WindowWidth = 93;
Console.WindowHeight = 29;
Console.CursorVisible = false;
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

DBHelper.GetConnection();
DBHelper.OpenConnection();

LoginController.updateView();

DBHelper.CloseConnection();
