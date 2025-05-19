using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SetupSprite : MonoBehaviour
{
    public string imageName; // name of sprite to load

    // Start is called before the first frame update
    void Start()
    {
        byte[] imgData = File.ReadAllBytes(AssetPaths.GetSpritePath(imageName));
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(imgData);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = Sprite.Create(tex, new Rect(transform.position, new Vector2(tex.width, tex.height)), new Vector2(0.5f, 0.5f));
    }
}
