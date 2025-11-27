public class Elf : Creature 
{
    public int Agility { get; set; } = 1;
    public void Sing() => Console.WriteLine($"{Name} is singing.");

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }


    public Elf() : base("Uknown Elf", 1)
    {
        Agility = 1;
    }
}