namespace DragonSlayerRPG;
public class Hero
{

    public string Name { get; set; }
    public int Level { get; set; }
    public int Strength { get; set; }
    private int _health;
    private bool _isAlive;



    public int Health
    {
        get { return _health >= 0 ? _health : 0; }
        set { _health = value >= 0 ? value : 0; }
    }

    public bool IsAlive
    {
        get { return Health > 0; }
        set { _isAlive = value; }
    }

    public Hero(string name, int health, int level, int strength)
    {
        Name = name;
        Health = health + (level * 10) + (strength * 2); // Skapa startvärden för hjältens liv baserat på level och strength
        Level = level;
        Strength = strength;
    }

    public void LevelUp()
    {
        Level += 1; // Öka hjältens level med 1
        Strength += 5; // Öka styrkan med 5
        Health += (10 + (Strength * 3)); // Öka livet på hjälten
        Console.WriteLine($"{Name} has leveled up to Level {Level}! New health is {Health} and new strength is {Strength}.");
    }
}