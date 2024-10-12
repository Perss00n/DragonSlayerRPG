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
        Health = health;
        Level = level;
        Strength = strength;
    }


}
