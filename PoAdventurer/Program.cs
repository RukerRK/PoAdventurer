using System;

namespace PoAdventurer
{
    class Program
    {
        static void Main(string[] args)
        {
            PotatoMC potatoKun = new PotatoMC("PotatoKun", 10, 0);
            PlantNPC npc1 = new PlantNPC("SunWor");
            PlantNPC npc2 = new PlantNPC("Cactos");
            PlantNPC npc3 = new PlantNPC("Coconot");
            Aneow enemy1 = new Aneow("NeowVillager", 2, 1);
            Aneow enemy2 = new Aneow("NeowFarmer", 4, 1);
            KingAneow boss1 = new KingAneow("King of Neower", 15, 2);
            Weapons gun1 = new Weapons("Sunflower Gun", 1);
            Weapons gun2 = new Weapons("Cactus Spike", 2);
            Weapons gun3 = new Weapons("Big Coconut", 999);

            Random random = new Random();

            int countOfGame = 0;


            while (countOfGame == 0)
            {
                int meetNPC1 = 0, meetNPC2 = 0, meetNPC3 = 0, defeatEnemy = 0, battleRound = 1, check = 0, skillCount = 0, attack = 0, dodge = 0;
                char startGame, walk, attackOrDodge, playAgain;

                while (countOfGame == 0)
                {
                    Console.WriteLine("*HOW TO PLAY GAME*");
                    Console.WriteLine();
                    Console.WriteLine("press W or w to walk forward went you don't have fight or another event.");
                    Console.WriteLine(
                        "press A or a to Attack and press D or d to Dodge a enemies attack went have fight.");
                    Console.WriteLine("when you attack 5 time you use your skill auto if you have skill.");
                    Console.WriteLine();

                    while (check == 0)
                    {
                        Console.WriteLine("Press S or s to start.");
                        startGame = Convert.ToChar(Console.ReadLine());
                        switch (startGame)
                        {
                            case 's':
                            case 'S':
                                Console.WriteLine("-Game Start-");
                                Console.WriteLine();
                                check++;
                                break;
                            default:
                                Console.WriteLine("You put wrong key, try again.");
                                Console.WriteLine();
                                break;
                        }
                    }

                    potatoKun.Appear();
                    while (defeatEnemy < 5)
                    {
                        while (check == 1)
                        {
                            Console.WriteLine("press W or w to walk.");
                            walk = Convert.ToChar(Console.ReadLine());
                            switch (walk)
                            {
                                case 'w':
                                case 'W':
                                    potatoKun.Walk();
                                    Console.WriteLine();
                                    check++;
                                    break;
                                default:
                                    Console.WriteLine("You put wrong key, try again.");
                                    Console.WriteLine();
                                    break;
                            }
                        }

                        if (defeatEnemy == 0 && meetNPC1 == 0)
                        {
                            npc1.Appear();
                            npc1.Talk();
                            potatoKun.Talk();
                            npc1.Gift();
                            potatoKun.Collect();
                            potatoKun.Damage = gun1.Damage;
                            Console.WriteLine();
                            meetNPC1++;
                        }

                        int foundEvent = random.Next(1, 3);
                        if (foundEvent == 1)
                        {
                            int meetEvent = random.Next(1, 2);
                            if (meetEvent == 1 && meetNPC2 == 0)
                            {
                                npc2.Appear();
                                npc2.Talk();
                                potatoKun.Talk();
                                npc2.Gift();
                                potatoKun.Collect();
                                potatoKun.Damage = gun2.Damage;
                                Console.WriteLine();
                                meetNPC2++;
                            }
                            else if (meetEvent == 2 && meetNPC3 == 0)
                            {
                                npc3.Appear();
                                npc3.Talk();
                                potatoKun.Talk();
                                npc3.Gift();
                                potatoKun.Collect();
                                Console.WriteLine();
                                meetNPC3++;
                            }
                        }
                        else if (foundEvent == 2)
                        {
                            int battleEvent = random.Next(1, 2);
                            if (battleEvent == 1)
                            {
                                enemy1.Appear();
                                Console.WriteLine("Time to battle!");
                                battleRound = 1;
                                while (battleRound <= 20)
                                {
                                    while (check == 2)
                                    {
                                        Console.WriteLine("press A or a to Attack and press D or d to Dodge");
                                        Console.WriteLine("select 1 thing Attack or Dodge");
                                        attackOrDodge = Convert.ToChar(Console.ReadLine());
                                        switch (attackOrDodge)
                                        {
                                            case 'a':
                                            case 'A':
                                                potatoKun.Attack();
                                                Console.WriteLine();
                                                check++;
                                                attack++;
                                                break;
                                            case 'd':
                                            case 'D':
                                                potatoKun.Dodge();
                                                Console.WriteLine();
                                                check++;
                                                dodge++;
                                                break;
                                            default:
                                                Console.WriteLine("You put wrong key, try again.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }
                                    
                                    int enemyAction = random.Next(1, 2);
                                    if (enemyAction == 1 && attack == 1)
                                    {
                                        enemy1.Attack();
                                        Console.WriteLine();
                                        if (skillCount == 5)
                                        {
                                            enemy1.HP =- gun3.Damage;
                                            skillCount = 0;
                                        }
                                        else
                                        {
                                            enemy1.HP -= potatoKun.Damage;
                                        }
                                        potatoKun.HP -= enemy1.Damage;
                                        potatoKun.Damaged();
                                        Console.WriteLine();
                                        enemy1.Damaged();
                                        Console.WriteLine();
                                        skillCount++;
                                        battleRound++;
                                        attack = 0;
                                    }
                                    else if (enemyAction == 2 && attack == 1)
                                    {
                                        enemy1.Stand();
                                        Console.WriteLine();
                                        if (skillCount == 5)
                                        {
                                            enemy1.HP -= gun3.Damage;
                                            skillCount = 0;
                                        }
                                        skillCount++;
                                        battleRound++;
                                        attack = 0;
                                    }
                                    else if (enemyAction == 1 && dodge == 1)
                                    {
                                        enemy1.Attack();
                                        Console.WriteLine();
                                        battleRound++;
                                        dodge = 0;
                                    }
                                    else if (enemyAction == 2 && dodge == 1)
                                    {
                                        enemy1.Stand();
                                        Console.WriteLine();
                                        battleRound++;
                                        dodge = 0;
                                    }

                                    if (enemy1.HP <= 0)
                                    {
                                        enemy1.Dead();
                                        Console.WriteLine();
                                        battleRound = 21;
                                        defeatEnemy++;
                                        check = 1;
                                        enemy1.HP = 2;
                                    }
                                    else if (potatoKun.HP <= 0)
                                    {
                                        potatoKun.Dead();
                                        defeatEnemy = 10;
                                        countOfGame++;
                                    }
                                }
                            }
                            else if (battleEvent == 2)
                            {
                                enemy2.Appear();
                                Console.WriteLine("Time to battle!");
                                battleRound = 1;
                                while (battleRound <= 20)
                                {
                                    while (check == 2)
                                    {
                                        Console.WriteLine("press A or a to Attack and press D or d to Dodge");
                                        Console.WriteLine("select 1 thing Attack or Dodge");
                                        attackOrDodge = Convert.ToChar(Console.ReadLine());
                                        switch (attackOrDodge)
                                        {
                                            case 'a':
                                            case 'A':
                                                potatoKun.Attack();
                                                Console.WriteLine();
                                                check++;
                                                attack++;
                                                break;
                                            case 'd':
                                            case 'D':
                                                potatoKun.Dodge();
                                                Console.WriteLine();
                                                check++;
                                                dodge++;
                                                break;
                                            default:
                                                Console.WriteLine("You put wrong key, try again.");
                                                Console.WriteLine();
                                                break;
                                        }
                                    }


                                    int enemyAction = random.Next(1, 2);
                                    if (enemyAction == 1 && attack == 1)
                                    {
                                        enemy2.Attack();
                                        Console.WriteLine();
                                        if (skillCount == 5)
                                        {
                                            enemy2.HP -= gun3.Damage;
                                            skillCount = 0;
                                        }
                                        else
                                        {
                                            enemy2.HP -= potatoKun.Damage;
                                        }
                                        potatoKun.HP -= enemy2.Damage;
                                        potatoKun.Damaged();
                                        Console.WriteLine();
                                        enemy2.Damaged();
                                        Console.WriteLine();
                                        battleRound++;
                                        skillCount++;
                                        attack = 0;
                                    }
                                    else if (enemyAction == 2 && attack == 1)
                                    {
                                        enemy2.Stand();
                                        Console.WriteLine();
                                        if (skillCount == 5)
                                        {
                                            enemy2.HP -= gun3.Damage;
                                            skillCount = 0;
                                        }
                                        battleRound++;
                                        skillCount++;
                                        attack = 0;
                                    }
                                    else if (enemyAction == 1 && dodge == 1)
                                    {
                                        enemy2.Attack();
                                        Console.WriteLine();
                                        battleRound++;
                                        dodge = 0;
                                    }
                                    else if (enemyAction == 2 && dodge == 1)
                                    {
                                        enemy2.Stand();
                                        Console.WriteLine();
                                        battleRound++;
                                        dodge = 0;
                                    }

                                    if (enemy2.HP <= 0)
                                    {
                                        enemy2.Dead();
                                        Console.WriteLine();
                                        battleRound = 21;
                                        defeatEnemy++;
                                        check = 1;
                                        enemy2.HP = 4;
                                    }
                                    else if (potatoKun.HP <= 0)
                                    {
                                        potatoKun.Dead();
                                        defeatEnemy = 10;
                                        countOfGame++;
                                    }
                                }
                            }
                        }
                    }

                    while (countOfGame == 0)
                    {
                        potatoKun.HP = 20;
                        Console.WriteLine("Your HP up to 20");
                        Console.WriteLine("Boss is coming");
                        boss1.Appear();
                        Console.WriteLine("Time to fight");
                        break;

                        while (battleRound == 0)
                        {
                            while (check == 1)
                            {
                                Console.WriteLine("press A or a to Attack and press D or d to Dodge");
                                Console.WriteLine("select 1 thing Attack or Dodge");
                                attackOrDodge = Convert.ToChar(Console.ReadLine());
                                switch (attackOrDodge)
                                {
                                    case 'a':
                                    case 'A':
                                        potatoKun.Attack();
                                        Console.WriteLine();
                                        check++;
                                        attack++;
                                        break;
                                    case 'd':
                                    case 'D':
                                        potatoKun.Dodge();
                                        Console.WriteLine();
                                        check++;
                                        dodge++;
                                        break;
                                    default:
                                        Console.WriteLine("You put wrong key, try again.");
                                        Console.WriteLine();
                                        break;
                                }
                            }


                            int enemyAction = random.Next(1, 2);
                            if (enemyAction == 1 && attack == 1)
                            {
                                boss1.Attack();
                                Console.WriteLine();
                                if (skillCount == 5)
                                {
                                    boss1.HP -= gun3.Damage;
                                    skillCount = 0;
                                }
                                else
                                {
                                    boss1.HP -= potatoKun.Damage;
                                }
                                potatoKun.HP -= boss1.Damage;
                                potatoKun.Damaged();
                                Console.WriteLine();
                                boss1.Damaged();
                                Console.WriteLine();
                                attack = 0;
                            }
                            else if (enemyAction == 2 && attack == 1)
                            {
                                boss1.Dash();
                                if (skillCount == 5)
                                {
                                    boss1.HP -= gun3.Damage;
                                    skillCount = 0;
                                }
                                Console.WriteLine();
                                attack = 0;
                            }
                            else if (enemyAction == 1 && dodge == 1)
                            {
                                boss1.Attack();
                                Console.WriteLine();
                            }
                            else if (enemyAction == 2 && dodge == 1)
                            {
                                boss1.Dash();
                                Console.WriteLine();
                            }

                            if (boss1.HP <= 0)
                            {
                                boss1.Dead();
                                Console.WriteLine();
                                Console.WriteLine("You victory!");
                                battleRound = 21;
                                defeatEnemy++;
                                check = 1;
                                boss1.HP = 15;
                                countOfGame++;
                            }
                            else if (potatoKun.HP <= 0)
                            {
                                potatoKun.Dead();
                                defeatEnemy = 10;
                                countOfGame++;
                            }
                        }
                    }
                }
                
                while (countOfGame == 1)
                {
                    Console.WriteLine("You want to play again? if yes, press Y or y. if no, press N or n.");
                    playAgain = Convert.ToChar(Console.ReadLine());

                    switch (playAgain)
                    {
                        case 'y':
                        case 'Y':
                            Console.WriteLine();
                            countOfGame = 0;
                            break;
                        case 'n':
                        case 'N':
                            Console.WriteLine("Good bye!");
                            countOfGame++;
                            break;
                    }
                }
            }
        }
    }
}