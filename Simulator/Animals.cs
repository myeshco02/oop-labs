namespace Simulator.Creatures;

public class Animals
{
    private string _description = "Unknown";

    public string Description
    {
        get => _description;
        init => _description = FormatDescription(value);
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";

    private static string FormatDescription(string? value)
    {
        var formatted = (value ?? string.Empty).Trim();

        if (formatted.Length > 15)
        {
            formatted = formatted[..15].TrimEnd();
        }

        if (formatted.Length < 3)
        {
            formatted = formatted.PadRight(3, '#');
        }

        if (formatted.Length > 0 && char.IsLetter(formatted[0]) && char.IsLower(formatted[0]))
        {
            formatted = char.ToUpperInvariant(formatted[0]) + formatted[1..];
        }

        return formatted;
    }
}
