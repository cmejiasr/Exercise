﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Exercise.Data_Structures.Shapes;
using Exercise.Functions;

namespace Exercise
{
    class Program
    {
        private static Methods methods;
        static void Main(string[] args)
        {
           methods = new Methods();
           PrintMenu();
        }

        static void PrintMenu()
        {
            //Read Menu.txt to display the menu
            PrintFromFile("Resources\\Menu.txt");
            var menuSelection = Console.ReadLine();
            if (menuSelection == "6" || menuSelection == "Exit" || menuSelection == "exit")
            {
                Environment.Exit(0);
            }
            CheckSelection(menuSelection);
        }

        static void CheckSelection(string selection)
        {
            switch (selection)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Available Shapes:");
                    Console.WriteLine("Circle");
                    Console.WriteLine("Square");
                    Console.WriteLine("Rectangle");
                    Console.WriteLine("Triangle");
                    Console.WriteLine("Donut");
                    Console.WriteLine();
                    Console.WriteLine("Enter to return to the menu...");
                    Console.ReadKey();
                    PrintMenu();
                    break;
                case "2":
                    Console.WriteLine("Insert a new shape");
                    Console.WriteLine("Please enter a valid shape format:");
                    var shape = Console.ReadLine();
                    Console.WriteLine(methods.ValidateShape(shape));
                    Console.ReadKey();
                    PrintMenu();
                    break;
                case "3":
                    Console.WriteLine("Insert Shape from file");
                    Console.WriteLine("Please enter a valid file path:");
                    var path = Console.ReadLine();
                    ReadFile(path);
                    Console.ReadKey();
                    PrintMenu();
                    break;
                case "4":
                    Console.WriteLine("Enter a X Y point to search shapes");
                    Console.ReadLine();
                    break;
                case "5":
                    PrintHelp();
                    break;
                default:
                    PrintMenu();
                    break;
            }
        }

        static void PrintFromFile(string path)
        {
            var file = StreamReader.Null;
            try
            {
                Console.Clear();
                file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error reading the file: {0}", ex.Message));
            }
            finally
            {
                file.Close();
            }
            
        }

        static void PrintHelp()
        {
            PrintFromFile("Resources\\HelpInsertShape.txt");
            var goback = Console.ReadLine();
            if (goback == "back" || goback == "Back" || goback == "0")
            {
                PrintMenu();
            }
            else
            {
                PrintHelp();
            }
        }

        static void ReadFile(string path)
        {
            var file = StreamReader.Null;
            try
            {
                string line;
                file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(methods.ValidateShape(line));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Error reading the file: {0}", ex.Message));
            }
            finally
            {
                file.Close();
            }
        }
    }
}