// See https://aka.ms/new-console-template for more information
using Luval.FourInARow;
using Luval.FourInARow.ConsoleApp;

var printer = new BoardPrinter(new Game());
printer.Start();
Console.ReadKey();