using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SparrowV2Loader
{
    //public Texture2D[] SparrowDeserialize(Texture2D atlas, string xml)
    //{
    //    XmlSerializer xmls = new XmlSerializer(typeof(TextureAtlas));
    //    TextureAtlas textureAtlas = xmls.Deserialize(new StringReader(xml)) as TextureAtlas;
    //}
}

[XmlRoot]
public class TextureAtlas
{
    public string imagePath;
    public int width;
    public int height;

    //public List<SubTexture> subTextures;
}
public class SubTexture
{
    public string name;
    public int x;
    public int y;
    public int width;
    public int height;
    public int frameX;
    public int frameY;
    public int frameWidth;
    public int frameHeight;
}