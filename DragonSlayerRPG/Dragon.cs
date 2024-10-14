namespace DragonSlayerRPG;
public class Dragon
{

    public string? Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public int Strength { get; set; }
	private bool _isAlive;

	public bool IsAlive
	{
		get { return Health > 0; }
		set { _isAlive = value; }
	}


}
