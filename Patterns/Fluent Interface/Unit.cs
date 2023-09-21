
public class Unit 
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Weapon weapon { get; set; }
    public int BaseDamage { get; set; }

    public override string ToString()
    {
        var line = $"User: {Name}\nDescription: {Description}\nWith weapon: {weapon.Id}\nBase damage: {BaseDamage}";

        return line ;
    }
}
