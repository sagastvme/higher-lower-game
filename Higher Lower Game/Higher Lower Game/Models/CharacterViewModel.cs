using System.ComponentModel.DataAnnotations;

namespace Higher_Lower_Game.Models;

public class CharacterViewModel
{
    [Key] public int Id { get; set; }
    public string? Name { get; set; }
    public int Views { get; set; }

    public CharacterViewModel(int id, string? name, int views)
    {
        Id = id;
        Name = name;
        Views = views;
    }
}