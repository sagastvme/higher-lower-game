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
        return list;
    }

    public Character FindCharacterById(string id)
    {
        var filter = Builders<Character>.Filter.Eq(c => c.Id, id);
        var foundCharacter = Characters.Find(filter).FirstOrDefault();

        // Check if the character was found or not
        if (foundCharacter == null)
        {
            // You can either return null or throw an exception, depending on your use case.
            // Returning null is more appropriate if not finding a character is a valid scenario.
            return null;
            // Alternatively, you can throw an exception if not finding a character is an exceptional scenario.
            // throw new ArgumentException("Character not found for the given ID.");
        }

        return foundCharacter;
    }

}