using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class SparrowV2Loader
{
    /// <summary>
    /// Gets a list of <see cref="SparrowAnimation[]"/> from <paramref name="atlas"/> and <paramref name="xml"/>
    /// </summary>
    /// <param name="atlas">The spritesheet to deserialize</param>
    /// <param name="xml">The xml, this assumes you already have the xml loaded into a string</param>
    /// <returns>A list of <see cref="SparrowAnimation"/>s</returns>
    public SparrowAnimation[] SparrowDeserialize(Texture2D atlas, string xml)
    {
        XmlSerializer xmls = new XmlSerializer(typeof(TextureAtlas));
        TextureAtlas textureAtlas = xmls.Deserialize(new StringReader(xml)) as TextureAtlas;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xml);
        // important thing to note:
        // imagePath is ignored, this function expects you to have the atlas ready to be deserialized
        XmlNode texat = xmlDoc.GetElementsByTagName("TextureAtlas")[0];
        List<SubTexture> subTextures = new List<SubTexture>();
        List<string> animNames = new List<string>();
        Dictionary<string, List<SubTexture>> anims = new Dictionary<string, List<SubTexture>>();
        foreach (XmlNode node in texat.ChildNodes)
        {
            // parse all the subtextures
            SubTexture curr = new SubTexture();
            curr.name = node.Attributes["name"].Value;
            string currAnimName = new string(curr.name.Where(char.IsLetter).ToArray());
            if (!animNames.Contains(currAnimName))
            {
                animNames.Add(currAnimName);
                if (!anims.ContainsKey(currAnimName))
                {
                    List<SubTexture> currAnimm = new List<SubTexture>();
                    currAnimm.Add(curr);
                    anims.Add(currAnimName, currAnimm);
                } else
                {
                    anims[currAnimName].Add(curr);
                }
            }
            // set all the properties
            curr.x = int.Parse(node.Attributes["x"].Value);
            curr.y = int.Parse(node.Attributes["y"].Value);
            curr.width = int.Parse(node.Attributes["width"].Value);
            curr.height = int.Parse(node.Attributes["height"].Value);
            curr.frameX = int.Parse(node.Attributes["frameX"].Value);
            curr.frameY = int.Parse(node.Attributes["frameY"].Value);
            curr.frameWidth = int.Parse(node.Attributes["frameWidth"].Value);
            curr.frameHeight = int.Parse(node.Attributes["frameHeight"].Value);

            subTextures.Add(curr);
        }
        List<SparrowAnimation> sparrowanims = new List<SparrowAnimation>();
        foreach (string nameAnim in  animNames)
        {
            SparrowAnimation anim = new SparrowAnimation(nameAnim);
            foreach (SubTexture subTexture in anims[nameAnim])
            {
                // crop atlas
                Color[] atlasPixels = atlas.GetPixels(subTexture.x, subTexture.y, subTexture.width, subTexture.height);
                Texture2D currFrame = new Texture2D(subTexture.width, subTexture.height);
                currFrame.SetPixels(atlasPixels);
                currFrame.Apply();
                anim.frames.Add(currFrame);
            }
            sparrowanims.Add(anim);
        }
        return sparrowanims.ToArray();
    }
}

public struct SparrowAnimation
{
    public string name;
    public List<Texture2D> frames;

    public SparrowAnimation(string name)
    {
        this.name = name;
        frames = new List<Texture2D>();
    }
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