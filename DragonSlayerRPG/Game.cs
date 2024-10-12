﻿using System;
using System.Text.RegularExpressions;

namespace DragonSlayerRPG;
public class Game
{
    private Hero hero;
    private Boss finalBoss;
    private List<Dragon> dragons;



    public void CreateNewHero()
    {
        string name = string.Empty;
        int health = 100;
        int level = 1;
        int strength = 5;
        bool isInvalidInput;

        do
        {
            Console.Write("What is you'r character called?: ");
            name = Console.ReadLine()!.Trim();
            isInvalidInput = String.IsNullOrEmpty(name);

            if (isInvalidInput)
                Console.WriteLine("Name can't be empty! Try again...");
        }
        while (isInvalidInput);
        hero = new Hero(name, health, level, strength);


    }
    public void InitializeEnemies()
    {
        dragons = new List<Dragon>
        {
         new Dragon { Name = "Nerakthar", Health = 40, Level = 30, Strength = 10 },
         new Dragon { Name = "Thalorak ", Health = 50, Level = 60, Strength = 20 },
         new Dragon { Name = "Eryndor", Health = 60, Level = 90, Strength = 30 }
        };

        finalBoss = new Boss { Name = "Aldurak", Health = 20, Strength = 80 };
    }

    public void InitializeBossFight()
    {
        Random random = new Random();
        string[] bossAttackMessages =
        {
        "unleashes a torrent of fire, scorching the very ground beneath your feet!",
        "swipes its colossal claws, the force of the impact shaking the earth!",
        "roars with a fury that sends shockwaves through the air, attempting to crush your spirit!",
        "snaps its massive jaws, its teeth gleaming like obsidian, aiming to tear you apart!",
        "summons a storm of blazing meteors from the sky, raining destruction all around you!"
    };

        string[] bossHeroDamageMessages =
        {
        "You're thrown back by the force of Aldurak's attack, your armor barely holding against the onslaught!",
        "Aldurak’s fiery breath sears your skin, the pain nearly unbearable, but you stand firm!",
        "The sheer power of Aldurak’s strike sends shockwaves through your body, but your resolve holds!",
        "Your vision blurs as the dragon’s claw rakes across your side, but you grit your teeth and fight on!",
        "Aldurak's roar reverberates through your soul, weakening your will, but you refuse to falter!"
    };

        string[] bossDragonDamageMessages =
        {
        "Aldurak staggers momentarily, your strike drawing blood from the ancient beast!",
        "Your blade cuts through Aldurak’s hardened scales, the dragon growling in pain!",
        "With a mighty swing, your weapon crashes into Aldurak, sparks flying as steel meets scale!",
        "You land a direct hit, and for the first time, you see hesitation in Aldurak’s fiery gaze!",
        "Your blow strikes true, and Aldurak reels, his wings flaring in fury as he tries to regain balance!"
    };

        string[] bossVictoryMessages =
        {
        "With a final, earth-shattering roar, Aldurak falls. The immortal dragon is no more.\nVICTORY!!!",
        "As Aldurak's massive body crashes to the ground, the world seems to exhale, freed at last from his reign of terror.\nVICTORY!!!",
        "Aldurak’s flames flicker out, and the mighty beast crumbles before you. You have done the impossible—Aldurak is defeated.\nVICTORY!!!",
        "The ground stops trembling, and the sky clears. Aldurak’s reign of darkness has ended, and you stand as the world’s savior.\nVICTORY!!!",
        "The battle is over. Aldurak, the terror of ages, lies defeated at your feet. The world will never forget your name.\nVICTORY!!!"
    };

        string[] bossDefeatMessages =
        {
        "The world darkens as Aldurak's fire consumes you, your quest ending in flame and ruin.\nGAME OVER!!!",
        "Your strength fails you as Aldurak’s power overwhelms, and the world falls to shadow.\nGAME OVER!!!",
        "Aldurak’s final blow crushes your defenses, and darkness engulfs your vision. Your journey ends here.\nGAME OVER!!!",
        "As you fall, you see Aldurak standing victorious, his reign of terror destined to continue.\nGAME OVER!!!",
        "The ground swallows you in defeat, Aldurak's might too great to overcome. The world weeps in despair.\nGAME OVER!!!"
    };

        do
        {
            // Hjälten attackerar först
            int heroDmg = random.Next(1, 11);
            finalBoss.Health -= heroDmg;
            Console.WriteLine($"{bossDragonDamageMessages[random.Next(bossDragonDamageMessages.Length)]} and did {heroDmg} damage to Aldurak!");

            if (finalBoss.Health > 0)
                Console.WriteLine($"Aldurak's new health is now {finalBoss.Health}");

            // Kontrollera om bossen är död
            if (finalBoss.Health <= 0)
            {
                Console.WriteLine(bossVictoryMessages[random.Next(bossVictoryMessages.Length)]);
                Console.ReadKey();
                Environment.Exit(0);
            }

            // Bossen attackerar tillbaka
            int dragonDmg = random.Next(1, 11);
            hero.Health -= dragonDmg;
            Console.WriteLine($"Aldurak {bossAttackMessages[random.Next(bossAttackMessages.Length)]} and dealt {dragonDmg} damage to {hero.Name}!");

            if (hero.Health > 0)
                Console.WriteLine($"{hero.Name}'s new health is now {hero.Health}");

            // Kontrollera om hjälten är död
            if (hero.Health <= 0)
            {
                Console.WriteLine(bossDefeatMessages[random.Next(bossDefeatMessages.Length)]);
                Console.ReadKey();
                Environment.Exit(0);
            }

            // Vänta på att användaren ska trycka ner valfri knapp för att starta nästa runda 
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();

        } while (hero.Health > 0 && finalBoss.Health > 0);
    }

    public void StartNewGame()
    {
        Console.Clear();
        // Visa olika meddelande beroende på hur många drakar som har dödats
        int dragonsAlive = dragons.Where(dragon => dragon.IsAlive).Count();
        if (dragonsAlive == 3)
        {
            Console.WriteLine($"{hero.Name}!");
            Console.WriteLine();
            Console.WriteLine("Your journey to defeat the dreaded Aldurak begins now. But the path to his throne is fraught with danger. Three powerful dragon lieutenants stand between you and the final battle." +
                "Each of them carries the strength and fury of their master, and they guard his realm with relentless devotion.\r\n\r\nOnly by defeating these three beasts can you reach Aldurak himself and put" +
                " an end to the reign of terror. Choose your first opponent, and let the legendary battle begin!\n");
        }
        else if (dragonsAlive == 2)
        {
            Console.WriteLine("With a final, thunderous roar, the dragon collapses at your feet. Its massive body trembles one last time before falling silent, and the sky seems to clear, if only for a moment." +
                " You have emerged victorious, but this is just the beginning.\r\n\r\nThe power of the slain beast courses through you, strengthening your resolve, but in the distance, you feel the looming presence" +
                " of two more dragons. Each one fiercer, more deadly than the last. They have sensed their fallen kin, and now they prepare to exact their revenge.\r\n\r\nYour journey is far from over. Two challenges remain," +
                " and with each victory, the path to Aldurak draws nearer. Will you face the next beast now, or take time to gather your strength? The fate of the world rests on your decision.\n");
        }
        else if (dragonsAlive == 1)
        {
            Console.WriteLine("Another mighty dragon falls before your blade, its fiery breath silenced forever. The ground trembles as its lifeless form hits the earth, but even in victory, you feel the weight of the final battle" +
                " approaching. Only one remains.\r\n\r\nThe last of Aldurak’s servants, the most fearsome of them all, waits for you now. Its roar echoes across the land, shaking mountains and turning the sky black with rage. This is" +
                " the final guardian, the last obstacle standing between you and the ultimate confrontation with Aldurak.\r\n\r\nYou have come too far to turn back now. Every battle has brought you closer to your destiny. Gather your" +
                " strength, hero. One more beast must fall before you can face the ancient terror that has haunted this world for centuries. The final dragon awaits.");
        }
        else // Bossbattle
        {
            Console.WriteLine("The ground beneath your feet quakes, and the very air seems to burn with ancient fury. You have bested all of Aldurak’s servants, and now, the time has come to face the source of this terror. Deep within the shadowed" +
                " mountains, the final dragon awaits—the most feared and powerful of them all, Aldurak, the Immortal.\r\n\r\nThe sky above darkens as if the world itself fears what is about to unfold. Aldurak’s roar shakes the heavens, a sound so vast" +
                " and terrible that it seems to tear the earth asunder. This is no ordinary battle; this is the end of an era. Victory means the salvation of all, but defeat… defeat means the world will be consumed by flame and darkness forever." +
                "\r\n\r\nWith your sword in hand and the strength of all your victories behind you, you step forward into the abyss. There is no turning back now. The fate of the world rests on this final battle. Aldurak awaits.\r\n\r\nPrepare yourself, hero. The time has come.");

            Console.WriteLine("Press ANY key to enter the dungeon...");
            Console.ReadKey(true);
            InitializeBossFight();
        }


        // Lista alla levande drakar
        for (int i = 0; i < dragons.Count; i++)
        {
            if (dragons[i].IsAlive)
            {
                Console.WriteLine($"{i + 1}. {dragons[i].Name} (HP: {dragons[i].Health}, Strength: {dragons[i].Strength}, Level: {dragons[i].Level})");
            }
        }

        int input;
        bool isValidInput;

        // Loopa tills användaren anger ett giltigt heltal som ligger inom rätt intervall
        do
        {
            Console.Write($"\nSelect the dragon you want to fight: ");
            isValidInput = Int32.TryParse(Console.ReadLine(), out input);

            if (!isValidInput || input < 1 || input > dragons.Count)
            {
                Console.WriteLine($"Invalid input! Please enter a valid integer. Try again...");
                isValidInput = false; // Sätt till false så loopen fortsätter
            }

        } while (!isValidInput);

        // När ett giltigt heltal är inmatat, kör striden
        Battle(input - 1); // Eftersom drakindex börjar från 0 i listan, men användaren matar in från 1
    }


    public void Battle(int dragon)
    {
        // Om användaren eller draken inte lever, tillåt inte spelet att börja utan starta om och välj en levande drake
        if (hero.Health <= 0 || dragons[dragon].Health <= 0)
            StartNewGame();

        Random random = new Random();

        // Visa olika meddelande varje gång en drake eller hero attackerar eller blir attackerad
        string[] heroAttackMessages =
        {
        "launches a powerful blow",
        "swings the sword with fury",
        "delivers a crushing strike",
        "lunges forward with deadly precision",
        "unleashes a swift attack",
        "strikes with great force",
        "lands a direct hit",
        "slashes through the dragon's defenses",
        "pierces the dragon’s scales",
        "hits hard, leaving the dragon staggered"
    };

        string[] dragonAttackMessages =
        {
        "breathes fire with terrifying force",
        "swings its massive tail, crashing into you",
        "bites down with sharp fangs",
        "lashes out with deadly claws",
        "roars and charges at you",
        "spits venom in your direction",
        "slams you with its powerful wings",
        "lashes its tail in a sweeping motion",
        "snaps its jaws shut, trying to crush you",
        "rakes its claws across your armor"
    };

        string[] heroDamageMessages =
        {
        "is knocked back, wincing in pain",
        "staggers under the weight of the blow",
        "is burned by the dragon’s fire",
        "is slammed hard, struggling to stay upright",
        "dodges slightly but is still hit hard",
        "tries to block but the force is too much",
        "is gasping for air after the brutal strike",
        "suffers a deep wound, but still stands",
        "feels the sting of the dragon's claws",
        "barely withstands the fury of the attack"
    };

        string[] dragonDamageMessages =
        {
        "roars in pain as the attack connects",
        "stumbles backward, blood dripping from its scales",
        "lets out a furious growl, clearly wounded",
        "flinches as the weapon finds its mark",
        "snarls as your strike leaves a deep gash",
        "takes a hit and retreats momentarily",
        "shakes off the blow but its movements slow",
        "is visibly weakened by the attack",
        "reels in pain but is not finished yet",
        "is bleeding from the wound, growling fiercely"
    };

        Console.Clear();
        Console.WriteLine($"You are now fighting {dragons[dragon].Name}!");

        // Loopa tills antingen hjälten eller draken är död
        do
        {
            // Hjälten attackerar först
            int heroDmg = Convert.ToInt32(random.Next(1, 11) + (hero.Strength * 1.5));
            dragons[dragon].Health -= heroDmg;
            Console.WriteLine($"{hero.Name} {heroAttackMessages[random.Next(heroAttackMessages.Length)]} and did {heroDmg} damage to {dragons[dragon].Name}!");
            if (dragons[dragon].Health > 0)
                Console.WriteLine($"{dragons[dragon].Name}'s new health is now {dragons[dragon].Health}");

            // Kontrollera om draken är död
            if (dragons[dragon].Health <= 0)
            {
                Console.WriteLine($"{dragons[dragon].Name} has been defeated!");
                Console.ReadKey();
                break;
            }

            // Draken attackerar tillbaka
            int dragonDmg = random.Next(1, 11);
            hero.Health -= dragonDmg;
            Console.WriteLine($"{dragons[dragon].Name} {dragonAttackMessages[random.Next(dragonAttackMessages.Length)]} and dealt {dragonDmg} damage to {hero.Name}!");
            if (hero.Health > 0)
                Console.WriteLine($"{hero.Name}'s new health is now {hero.Health}");

            // Kontrollera om hjälten är död
            if (hero.Health <= 0)
            {
                Console.WriteLine($"{hero.Name} has been defeated!");
                Console.ReadKey();
                break;
            }

            // Vänta på att användaren ska trycka ner valfri knapp för att starta nästa runda 
            Console.WriteLine("\nPress any key to continue...\n");
            Console.ReadKey();

        } while (hero.Health > 0 && dragons[dragon].Health > 0);

        StartNewGame();
    }


}
