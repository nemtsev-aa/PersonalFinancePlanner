using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class CategoryData {
    public CategoryData(string name, Sprite icon, float limit, float value) {
        Name = name;
        Limit = limit;
        CurrentExpense = value;

        Icon = icon;
        IconData = Icon.texture.EncodeToPNG();
    }

    [JsonConstructor]
    public CategoryData(string name, float limit, float value, byte[] iconData) {
        Name = name;
        Limit = limit;
        CurrentExpense = value;

        IconData = iconData;
        Icon = CreateSpriteFromData(IconData);
    }

    public string Name { get; private set; }
    public float Limit { get; private set; }
    public float CurrentExpense { get; private set; }
    public byte[] IconData { get; private set; }
    
    [JsonIgnore]
    public Sprite Icon { get; private set; }
    

    public void SetValue(float value) {
        if (value < 0)
            throw new ArgumentNullException($"Invalid Value number");

        CurrentExpense += value;

    }

    public void SetLimit(float value) {
        if (value <= 0)
            throw new ArgumentNullException($"Invalid Limit number");

        Limit = value;
    }

    private Sprite CreateSpriteFromData(byte[] iconData) {
        Texture2D texture = new Texture2D(512, 512);
        texture.LoadImage(iconData);

        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        
        sprite.name = $"{Name}Icon";
        var newRect = sprite.rect;
        newRect.size = new Vector2(512, 512);
        sprite = Sprite.Create(sprite.texture, newRect, sprite.pivot, 100.0f);
        

        return sprite;
    }
}
