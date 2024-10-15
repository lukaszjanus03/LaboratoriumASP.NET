namespace WebApp.Models;

public class Birth
{
    public DateTime? Date { get; set; }
    public string? Name { get; set; }
    
    public bool IsValid()
    {
        return Date != null && Name != null && DateTime.Now>Date;
    }
    
    public int Calculate()
    {
        return (DateTime.Now - Date).Value.TotalDays / 365;
    }
}