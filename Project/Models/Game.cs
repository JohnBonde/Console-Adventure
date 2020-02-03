using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public Game()
    {
      Setup();
    }

    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      CurrentPlayer = new Player();
      CurrentPlayer.Name = "Ron Swanson";
      CurrentPlayer.Inventory = new List<Item>();
      #region Rooms
      Room Room1 = new Room("Room1", "There is a door to the South.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room2 = new Room("Room2", "There is a door to the South, East, and North.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room3 = new Room("Room3", "There is a door to the West.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room4 = new Room("Room4", "There is a door to the West and North.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room5 = new Room("Room5", "There is a door to the South and East.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room6 = new Room("Room6", "There is a door to the West, East, and North.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room7 = new Room("Room7", "The room is very dark. You hear a high pitched cackle that brings chills to your spine as if you've heard it before.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room8 = new Room("Room8", "There is a door to the South and West.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room9 = new Room("Room9", "In the middle of the room is a tall, normal looking human in very good shape. He runs up to you and whispers in your ear, 'I'm a vegan'. You look around and see there is no way out.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      Room Room10 = new Room("Room10", "Congratulations, you are in heaven! There is an unlimited supply of bacon, eggs, steak, and Lagavulin.", new List<Item>(), new Dictionary<string, IRoom>(), new List<Enemy>());
      #endregion
      #region Exits
      Room1.Exits.Add("south", Room2);
      Room1.Exits.Add("east", Room10);
      Room2.Exits.Add("north", Room1);
      Room2.Exits.Add("east", Room3);
      Room2.Exits.Add("south", Room4);
      Room3.Exits.Add("west", Room2);
      Room4.Exits.Add("north", Room2);
      Room4.Exits.Add("west", Room5);
      Room5.Exits.Add("east", Room4);
      Room5.Exits.Add("south", Room6);
      Room6.Exits.Add("north", Room5);
      Room6.Exits.Add("west", Room7);
      Room6.Exits.Add("east", Room8);
      Room7.Exits.Add("east", Room6);
      Room8.Exits.Add("west", Room6);
      Room8.Exits.Add("south", Room9);
      Room9.Exits.Add("south", Room10);
      #endregion
      #region Items
      Item flashlight = new Item("Flashlight", "a flashlight");
      Item eggs = new Item("Eggs", "a dozen eggs");
      Room3.Items.Add(flashlight);
      Room5.Items.Add(eggs);
      #endregion
      #region Enemies
      Enemy vegan = new Enemy("The Veganator", "eggs");
      Room9.Enemies.Add(vegan);
      Enemy tammy = new Enemy("Tammy 2", "flashlight");
      Room7.Enemies.Add(tammy);
      #endregion
      CurrentRoom = Room1;
    }
  }
}