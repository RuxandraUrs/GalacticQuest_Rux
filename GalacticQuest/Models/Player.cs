namespace GalacticQuest
{
    public class Item
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Value { get; set; }

        public Item(string name, int attack, int value)
        {
            Name = name;
            Attack = attack;
            Value = value;
        }
    }
    public class Player
    {
        public int Hp { get; private set; } = 100;
        public int Attack { get; private set; } = 10;

        public int Credits { get; private set; } = 0;
        public List<Item> Items { get; private set; } = new List<Item>();
        public Player(int hp, int attack, List<Item> items, int credits)
        {
            Hp = hp;
            Attack = attack;
            Items = items;
            Credits = credits;
        }

        public Player(int hp, int attack)
        {
            Hp = hp;
            Attack = attack;
        }

        public Player(int hp)
        {
            Hp = hp;
        }

        public Player()
        {
        }

        public void UpdateHp(int hp)
        {
            Hp += hp;

            if (Hp <= 0)
            {
                Hp = 0;
                OnDeath();
            }
        }
        private void OnDeath()
        {
           
            Console.WriteLine("YOU HAVE DIED. GAME OVER");
            return;
        }
        public void UpdateCredits(int amount)
        {
            Credits += amount;
            Console.WriteLine($"Credits updated. Current Balance: {Credits}");
        }
        public void AddItem(Item newItem)
        {
            Items.Add(newItem);
            Console.WriteLine($"You obtained: {newItem.Name}!");
        }
        public void RemoveItem(Item itemToRemove)
        {
            if (Items.Contains(itemToRemove))
            {
                Items.Remove(itemToRemove);
                Console.WriteLine($"You removed: {itemToRemove.Name}");
            }
        }
        public void ShowProfile()
        {
            Console.WriteLine("Displaying Player Profile:");

            Console.WriteLine($"Player HP: {Hp}");
            Console.WriteLine($"Player Credits: {Credits}"); 
            Console.Write("\n");

            Console.WriteLine("Player Items: ");
            for (int index = 0; index < Items.Count; ++index)
            {
                Console.WriteLine($"Item -> Name: {Items[index].Name} | Attack: {Items[index].Attack} | Value: {Items[index].Value}");
            }
            Console.Write("\n");

            Console.WriteLine($"Player Attack: {Attack}");
            int playerTotalAttack = Attack;
            for (int index = 0; index < Items.Count; ++index)
            {
                playerTotalAttack += Items[index].Attack;
            }
            Console.WriteLine($"Player Attack (Combined With Items Attack): {playerTotalAttack}");
            Console.Write("\n");
        }
    }
}