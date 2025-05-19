using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class Stage
{
    public StageSprite[] props;
    public float cameraZoom;
    public string version;
    public StageCharacters characters;
    public string name;
    public string directory;

    public Stage(StageSprite[] props, float cameraZoom, string version, StageCharacters characters, string name, string directory)
    {
        this.props = props;
        this.cameraZoom = cameraZoom;
        this.version = version;
        this.characters = characters;
        this.name = name;
        this.directory = directory;
    }

}

public struct StageCharacters
{
    public StageCharacter bf;
    public StageCharacter dad;
    public StageCharacter gf;

    public StageCharacters(StageCharacter bf, StageCharacter dad, StageCharacter gf)
    {
        this.bf = bf;
        this.dad = dad;
        this.gf = gf;
    }
}

public struct StageSpriteAnimation
{
    public float[] offsets;
    public bool flipY;
    public int frameRate;
    public string prefix;
    public string name;
    public bool looped;
    public bool flipX;
}

public struct StageCharacter
{
    public int zIndex;
    public float[] position;
    public float[] cameraOffsets;

    public StageCharacter(int zIndex, float[] position, float[] cameraOffsets)
    {
        this.zIndex = zIndex;
        this.position = position;
        this.cameraOffsets = cameraOffsets;
    }
}

public struct StageSprite
{
    public float danceEvery;
    public int zIndex;
    public float[] position;
    public float[] scale;
    public string animType;
    public string name;
    public bool isPixel;
    public string assetPath;
    public float[] scroll;
    public StageSpriteAnimation[] animations;

    public StageSprite(float danceEvery, int zIndex, float[] position, float[] scale, string animType, string name, bool isPixel, string assetPath, float[] scroll, StageSpriteAnimation[] animations)
    {
        this.danceEvery = danceEvery;
        this.zIndex = zIndex;
        this.position = position;
        this.scale = scale;
        this.animType = animType;
        this.name = name;
        this.isPixel = isPixel;
        this.assetPath = assetPath;
        this.scroll = scroll;
        this.animations = animations;
    }
}