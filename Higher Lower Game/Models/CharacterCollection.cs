using MongoDB.Driver;
using System;
using System.Collections.Generic;

public class CharacterCollection
{
    private readonly IMongoCollection<Character> Characters;

    public CharacterCollection()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("Higher_lower");
        Characters = database.GetCollection<Character>("Characters");
    }

    public List<Character> FindAllCharacters()
    {
        List<Character> list = Characters.Find(p => true).ToList();
      

        foreach (Character charac in list) // Renamed 'character' to 'charac'
        {
            Console.WriteLine($"Character: {charac.Id} - Character Name: {charac.Name}, Character Image: {charac.Image}");
        }
        return list;
    }

    public Character FindCharacterById(string id)
    {
        var filter = Builders<Character>.Filter.Eq(c => c.Id, id);
        var foundCharacter = Characters.Find(filter).FirstOrDefault();
        if (foundCharacter != null)
        {
            Console.WriteLine($"Found Character: {foundCharacter.Id} - Character Name: {foundCharacter.Name}");
        }
        else
        {
            Console.WriteLine("Character not found.");
        }

        return foundCharacter;
    }
}