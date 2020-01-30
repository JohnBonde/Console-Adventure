using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    private bool _running = true;
    public void Run()
    {
      System.Console.WriteLine($"Welcome to your worst nightmare Ron Swanson.");
      while (_running)
      {
        Print();
        GetUserInput();
      }
      System.Console.WriteLine("Until next time.");
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Print();
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          break;
        case "help":
          _gameService.Help();
          break;
        case "inventory":
          _gameService.Inventory();
          break;
        case "look":
          _gameService.Look();
          break;
        case "quit":
          _running = false;
          break;
        case "reset":
          Run();
          break;
        case "take":
          _gameService.TakeItem(option);
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        default:
          Console.WriteLine("You can't do that.");
          break;
      }

    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (var message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }
      _gameService.Messages.Clear();

    }

  }
}