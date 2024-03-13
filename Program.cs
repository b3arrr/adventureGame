//adventure game

using adventure;

internal class Program
{
    private static void Main(string[] args)
    {

        startGame();
        

        void startGame()
        {
        initialize();
        Console.WriteLine("---Welcome to bears adventure game---");
        Player player1 = Player.makePlayer();
        ItemManager player1Inventory = Player.createInventory();
        player1.info(player1Inventory);
        }

        void initialize()
        {
        ItemManager itemManager = new ItemManager();
             // Add items to the item manager
        itemManager.addItem(new Item("Sword", "Cursed", 5, true));
        itemManager.addItem(new Item("Potion", "healing", 1, false));
        itemManager.addItem(new Item("Shield", "simple shield", 1, true));

        // Display all items
/*             Item cursedBow = new Item("Cursed Bow", "Cursed bow crafted from the kinship of dwarves and elves.", 1, true);
            Item goldenBow = new Item("Golden Bow", "Golden bow crafted by golden tears of trolls", 1, true); */
        }
    }
}




public class Player
{
    int health;
    string? name;
    List<Item> inventory;
    int amount;



    public static ItemManager createInventory()
    {
        ItemManager player1Inventory = new ItemManager();
        player1Inventory.addItem(new Item("Sword", "Cursed", 5, true));
        player1Inventory.addItem(new Item("Potion", "healing", 1, false));
        player1Inventory.addItem(new Item("Shield", "simple shield", 1, true));
        return player1Inventory;
    }

    public Player(string? name)
    {
        this.health = 100;
        this.name = name;
    }

    public static Player makePlayer()
    {
        Console.WriteLine("Please enter your name");
        string? name = Console.ReadLine();
        

        return new Player(name);
        
    }
    public void info(ItemManager inventory)
    {
        Console.WriteLine("---Character info---");
        Console.WriteLine($"Player name: {name}\nPlayer health: {health}");
        Console.Write("Player inventory: ");
        inventory.displayInventory();
    }

}


public class Room
{
    string? description;

}

public class Item
{
    string? name;
    int weight;
    string? description;
    bool isWeapon;

    public Item(string? name, string? description, int weight,  bool isWeapon)
    {
        this.name = name;
        this.weight = weight;
        this.description = description;
        this.isWeapon = isWeapon;
    }
    public string getItemInfo()
    {
        return $"Name: {name}\nDescription: {description}\nWeight: {weight}\nIs Weapon: {isWeapon}";
    }
    
    public void Info()
    {
        Console.WriteLine("--Item---");
        Console.WriteLine($"Name: {name}\nDescription: {description}\nWeight: {weight}");
    }


    
    public static void itemDescirption()
    {
        Console.WriteLine("---All items---");

    }

}
    public class ItemManager
    {

     List<Item> items;
        public ItemManager()
        {
           items = new List<Item>();
        }
        public void addItem(Item item)
        {
            items.Add(item);
        }
        

        public void displayInventory()
        {
            int x = 1;
            Console.WriteLine("--All Items---");
            foreach (Item item in items)
            {
            Console.WriteLine($"Item {x} {item.getItemInfo()}\n");
            x++;

            }
        }
    }
