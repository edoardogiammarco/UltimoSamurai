using UnityEngine;

public class  wav : MonoBehaviour
{
    private void Start()
    {
        // Create a new texture with a size of 16x16
        Texture2D texture = new Texture2D(16, 16);
        
        // Fill the texture with a solid green color
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                texture.SetPixel(x, y, Color.green);
            }
        }

        // Draw a clover shape in the center of the texture
        int cloverSize = 6;
        int centerX = texture.width / 2;
        int centerY = texture.height / 2;
        for (int x = centerX - cloverSize; x <= centerX + cloverSize; x++)
        {
            for (int y = centerY - cloverSize; y <= centerY + cloverSize; y++)
            {
                float distance = Vector2.Distance(new Vector2(centerX, centerY), new Vector2(x, y));
                if (distance <= cloverSize)
                {
                    texture.SetPixel(x, y, Color.white);
                }
            }
        }
        
        // Apply the changes to the texture
        texture.Apply();

        // Create a sprite from the texture
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 16, 16), Vector2.one * 0.5f);

        // Add a SpriteRenderer component to the game object
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();

        // Assign the sprite to the SpriteRenderer component
        spriteRenderer.sprite = sprite;
    }
}