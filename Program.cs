/*
Adventure Game Documentation

This program is an adventure game where the player navigates through various rooms, collects items, and interacts with the environment.

Dependencies:
This program does not have any external dependencies and can be run independently.

Usage:
To play the game, run the program and follow the prompts to navigate through rooms, collect items, and interact with the environment.

*/


namespace adventure
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            // Start the game
            startGame();
            Console.ReadKey();
            player1.playerAttack();


        }

        private static void startGame()
        {
            initialize();
            Console.WriteLine("---Welcome to bears adventure game---");
            // Create a player
            Player player1 = Player.makePlayer();
            // Create an inventory for the player
            ItemManager player1Inventory = Player.createInventory();
            // Display player information and inventory
            player1.info(player1Inventory);
        }

        private static void initialize()
        {
            ItemManager itemManager = new ItemManager();
            // Add items to the item manager
            itemManager.addItem(new Item("Sword", "Cursed", 5, true));
            itemManager.addItem(new Item("Potion", "healing", 1, false));
            itemManager.addItem(new Item("Shield", "simple shield", 5, true));
            itemManager.addItem(new Item("Cursed Bow", "Cursed bow crafter from the kinship of dwarves and elves", 5, true));
            itemManager.addItem(new Item("Golden bow", "Golden bow crafted by golden tears of trolls", 1, true));
            itemManager.addItem(new Item("Goblins eye", "A wethered scorn goblin eye", 1, false));

            //add enemies
            Enemy troll = new Enemy(100, 30, "Cave Troll"); 
        }
    }




    public class Enemy
    {
        int health;
        int attackPower;
        string? name;
         // Static list to hold all enemy objects
        public static List<Enemy> allEnemies { get; } = new List<Enemy>();
        public Enemy(int health, int attackPower, string?name)
        {
            this.health = health;
            this.attackPower = attackPower;
            this.name = name;

            //adds the enemy created to allEnemies list
            allEnemies.Add(this);
        }
    } 

    public class Player
    {
        private string? description;
        private int health;
        private string? name;

        public void playerAttack (Player player1, List<ItemManager> enemy)
        {
            Random attackRoll = new Random();

            Console.WriteLine("Enemy attacks you");
            int attack = attackRoll.Next(0,20);
            player1.health -= attack;
            Console.WriteLine($"Enemy hit you for {attack}!");
        }

        public static ItemManager createInventory()
        {
            // Create an inventory for the player with predefined items
            ItemManager player1Inventory = new ItemManager();
            player1Inventory.addItem(new Item("Sword", "Cursed", 5, true));
            player1Inventory.addItem(new Item("Potion", "healing", 1, false));
            player1Inventory.addItem(new Item("Shield", "simple shield", 1, true));
            return player1Inventory;
        }

        public Player(string? name, string? description)
        {
            this.health = 100;
            this.name = name;
            this.description = description;
        }

        public static Player makePlayer()
        {
            // Prompt the player to enter their name and create a Player object
            Console.WriteLine("Please enter your name");
            string? name = Console.ReadLine();
            Console.WriteLine("Please tell em your backstory");
            string? description= Console.ReadLine();
            return new Player(name, description);
        }

        public void info(ItemManager inventory)
        {
            // Display player information and inventory
            Console.WriteLine("---Character info---");
            Console.WriteLine($"Player name: {name}\nPlayer health: {health}\nPlayer desscription: {description}");
            Console.Write("\n---Player inventory---\n");
            inventory.displayInventory();
        }
    }

    public class Item
    {
        private string? name;
        private int weight;
        private string? description;
        private bool isWeapon;

        public Item(string? name, string? description, int weight, bool isWeapon)
        {
            this.name = name;
            this.weight = weight;
            this.description = description;
            this.isWeapon = isWeapon;
        }

        public string getItemInfo()
        {
            // Retrieve information about an item
            return $"Name: {name}\nDescription: {description}\nWeight: {weight}";
        }

        public void Info()
        {
            // Display information about an item
            Console.WriteLine("--Item---");
            Console.WriteLine($"Name: {name}\nDescription: {description}\nWeight: {weight}");
        }
    }

    public class ItemManager
    {
        private List<Item> items;

        public ItemManager()
        {
            items = new List<Item>();
        }

        public void addItem(Item item)
        {
            // Add an item to the item manager's collection
            items.Add(item);
        }

        public void displayInventory()
        {
            // Display the contents of the player's inventory
            int x = 1;
            foreach (Item item in items)
            {
                Console.WriteLine($"Item {x} {item.getItemInfo()}\n");
                x++;
            }
        }
    }
}
