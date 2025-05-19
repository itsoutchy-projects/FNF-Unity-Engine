using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Utility to get the path to asset files
/// </summary>
public static class AssetPaths
{
    /// <summary>
    /// Returns the path to the stage's JSON file, you can use this with <see cref="Loader.LoadStage(string)"/>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetStagePath(string name)
    {
        if (!Application.isEditor)
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "assets", "data", "stages", $"{name}.json");
        } else
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "assets", "data", "stages", $"{name}.json");
        }
    }

    /// <summary>
    /// Returns the path to the song's folder, you can use this with <see cref="Loader.LoadSong(string)"/> if you're able to get the name of the chart you want
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetSongPath(string name)
    {
        if (!Application.isEditor)
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "assets", "data", "songs", $"{name}");
        } else
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "assets", "data", "songs", $"{name}");
        }
    }

    /// <summary>
    /// Returns the path to the sprite, you can use this with <see cref="File.ReadAllBytes(string)"/>
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetSpritePath(string name, bool shared = false)
    {
        if (!shared)
        {
            if (!Application.isEditor)
            {
                return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "assets", "images", $"{name}.png");
            }
            else
            {
                return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "assets", "images", $"{name}.png");
            }
        } else
        {
            if (!Application.isEditor)
            {
                return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "assets", "shared", "images", $"{name}.png");
            }
            else
            {
                return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "assets", "shared", "images", $"{name}.png");
            }
        }
    }

    /// <summary>
    /// Returns the path to the song's audio folder, you can use this with <see cref="Loader.LoadSong(string)"/> if you're able to get the name of the chart you want
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string GetSongMusicPath(string name)
    {
        if (!Application.isEditor)
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "assets", "songs", $"{name}");
        }
        else
        {
            return Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "assets", "songs", $"{name}");
        }
    }

    /// <summary>
    /// Builds a path from a <see cref="StageSprite"/>, might not be 100% correct because im trying to make this deal with VSlice assets properly
    /// <para>
    /// The path goes assets/<paramref name="directory"/>/images/<paramref name="sprite"/>.png
    /// (its absolute dw)
    /// </para>
    /// </summary>
    /// <param name="sprite">The sprite to use</param>
    /// <param name="directory">The path, it goes assets/<paramref name="directory"/>/images/<paramref name="sprite"/>.png
    /// <para>
    /// So for example, the path could be assets/<c>shared</c>/images/<c>stageback</c>.png
    /// </para>
    /// </param>
    /// <returns></returns>
    public static string StageSpriteToPath(StageSprite sprite, string directory)
    {
        if (!Application.isEditor)
        {
            return $"{Path.Combine(Directory.GetParent(Application.dataPath).FullName, "assets", directory, "images", sprite.assetPath)}.png";
        } else
        {
            return $"{Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Assets", "assets", directory, "images", sprite.assetPath)}.png";
        }
    }
}
