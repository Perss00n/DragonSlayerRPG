namespace DragonSlayerRPG;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("In a time long forgotten by history, when dragons ruled the skies and land, the world was a place of constant darkness and fear. Fire-breathing beasts with eyes glowing like molten lava ravaged villages, annihilated cities, and" +
            " left nothing but ash and ruins in their wake. The people, tormented and desperate, turned to ancient legends that spoke of a savior—a hero whose destiny was to slay these monsters and free the world from their oppression.\r\n\r\nBut years passed," +
            " and no hero emerged. Until now.\r\n\r\nYou are that hero. Chosen by an ancient prophecy, you wield the enchanted sword—an artifact forged in the light of the stars and dipped in the blood of dragons themselves. But your journey is not just a battle" +
            " for glory or revenge; it is a fight for survival. The dragons have sensed your arrival, and they have gathered to crush all hope one final time. Each dragon is more powerful than the last, and in the deepest mountains slumbers the largest and most " +
            "fearsome of them all—an immortal being known as Aldurak, whom no human has seen and lived to tell the tale.\r\n\r\nWith your courage as your only shield and your sword as your only weapon, you now stand before a world filled with danger. For every dragon" +
            " you defeat, your strength will grow. But every blow against these monsters will test your body and soul. Will you rest to recover, or press onward in the heat of battle?\r\n\r\nYour journey begins here.\n");

        // Skapa ett nytt game och initialisera alla drakar samt bossen
        Game game = new Game();
        game.CreateNewHero();
        game.InitializeEnemies();
        game.Start();

        Console.ReadLine();
    }
}
