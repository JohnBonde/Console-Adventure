using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; }
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
      Messages.Add(_game.CurrentRoom.Description);
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        Console.Clear();
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        System.Console.WriteLine(_game.CurrentRoom.Description);
      }
    }
    public void ClearInventory()
    {
      _game.Setup();
    }
    public void Help()
    {
      Console.WriteLine(@"You can type 'go (direction)', 'inventory', 'look', 'take (item name)', 'use (item name)', 'reset', or 'quit'.");
    }

    public void Inventory()
    {
      Console.Write("Inventory: ");
      foreach (Item item in _game.CurrentPlayer.Inventory)
      {
        Console.WriteLine(item.Name + " ");
      }
    }

    public void Look()
    {
      if (_game.CurrentRoom.Items.Count == 0)
      {
        System.Console.WriteLine("There appears to be nothing of use in the room.");
      }
      foreach (Item item in _game.CurrentRoom.Items)
      {
        Console.WriteLine("There is " + item.Description + " in the room.");
      }
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
      Console.WriteLine("You have taken the " + _game.CurrentRoom.Items[0].Name);
      _game.CurrentRoom.Items.Clear();
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      if (itemName == _game.CurrentRoom.Enemies[0].Weakness && itemName == "eggs")
      {
        _game.CurrentRoom.Enemies.Clear();
        Console.WriteLine("You throw the eggs at the Veganator, causing him to go into the fetal position, like a vegan. A door appears on the the southern wall.");
      }
      else if (itemName == _game.CurrentRoom.Enemies[0].Weakness && itemName == "flashlight")
      {
        Console.WriteLine("You turn on you flashlight, and in the corner you a brunette. She yells, 'High Ron!' You are immediatly captivated by her and Leslie is nowhere to be seen to snap you out of it.");
        Console.WriteLine(@"
      ___           ___           ___           ___                    ___                        ___           ___     
     /  /\         /  /\         /__/\         /  /\                  /  /\          ___         /  /\         /  /\    
    /  /:/_       /  /::\       |  |::\       /  /:/_                /  /::\        /__/\       /  /:/_       /  /::\   
   /  /:/ /\     /  /:/\:\      |  |:|:\     /  /:/ /\              /  /:/\:\       \  \:\     /  /:/ /\     /  /:/\:\  
  /  /:/_/::\   /  /:/~/::\   __|__|:|\:\   /  /:/ /:/_            /  /:/  \:\       \  \:\   /  /:/ /:/_   /  /:/~/:/  
 /__/:/__\/\:\ /__/:/ /:/\:\ /__/::::| \:\ /__/:/ /:/ /\          /__/:/ \__\:\  ___  \__\:\ /__/:/ /:/ /\ /__/:/ /:/___
 \  \:\ /~~/:/ \  \:\/:/__\/ \  \:\~~\__\/ \  \:\/:/ /:/          \  \:\ /  /:/ /__/\ |  |:| \  \:\/:/ /:/ \  \:\/:::::/
  \  \:\  /:/   \  \::/       \  \:\        \  \::/ /:/            \  \:\  /:/  \  \:\|  |:|  \  \::/ /:/   \  \::/~~~~ 
   \  \:\/:/     \  \:\        \  \:\        \  \:\/:/              \  \:\/:/    \  \:\__|:|   \  \:\/:/     \  \:\     
    \  \::/       \  \:\        \  \:\        \  \::/                \  \::/      \__\::::/     \  \::/       \  \:\    
     \__\/         \__\/         \__\/         \__\/                  \__\/           ~~~~       \__\/         \__\/    
");
        Console.WriteLine("'quit' or 'reset'");
      }
    }
  }
}