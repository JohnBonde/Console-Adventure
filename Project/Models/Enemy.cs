using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Enemy : IEnemy
  {
    public string Name { get; set; }
    public string Weakness { get; set; }
    public Enemy(string name, string weakness)
    {
      Name = name;
      Weakness = weakness;
    }
  }
}