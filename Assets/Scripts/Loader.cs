using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System;

public static class Loader
{
    /// <summary>
    /// Loads the <see cref="Stage"/> at <paramref name="path"/>
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The <see cref="Stage"/> at <paramref name="path"/></returns>
    public static Stage LoadStage(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<Stage>(json);
    }

    /// <summary>
    /// Loads the <see cref="Song"/> at <paramref name="path"/>
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The <see cref="Song"/> at <paramref name="path"/></returns>
    public static Song LoadSong(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<Song>(json);
    }


    /// <summary>
    /// Gets all the songs that have been added. May be slow since it has to deserialize loads of json files
    /// </summary>
    /// <returns></returns>
    public static Song[] CollectSongs()
    {
        List<Song> songs = new List<Song>();
        string songsDir = Directory.GetParent(AssetPaths.GetSongPath("dadbattle")).FullName; // we know dadbattle will always exist.. i hope
        foreach (string s in Directory.GetDirectories(songsDir))
        {
            songs.Add(LoadSong(Path.Combine(AssetPaths.GetSongPath(Path.GetFileName(s)), $"{Path.GetFileName(s)}-chart.json")));
        }
        return songs.ToArray();
    }

    /// <summary>
    /// Loads the <see cref="AudioClip"/> at <paramref name="path"/>
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The <see cref="AudioClip"/> at <paramref name="path"/></returns>
    public async static Task<AudioClip> LoadSongAudio(string path)
    {
        UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip($"file:///{path}", AudioType.OGGVORBIS);
        req.timeout = 20;
        await req.SendWebRequest();
        return DownloadHandlerAudioClip.GetContent(req);
    }

    /// <summary>
    /// Loads the <see cref="SongMetadata"/> at <paramref name="path"/>
    /// </summary>
    /// <param name="path"></param>
    /// <returns>The <see cref="SongMetadata"/> at <paramref name="path"/></returns>
    public static SongMetadata LoadSongMetadata(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<SongMetadata>(json);
    }
}

public class UnityWebRequestAwaiter : INotifyCompletion
{
    private UnityWebRequestAsyncOperation asyncOp;
    private Action continuation;

    public UnityWebRequestAwaiter(UnityWebRequestAsyncOperation asyncOp)
    {
        this.asyncOp = asyncOp;
        asyncOp.completed += OnRequestCompleted;
    }

    public bool IsCompleted { get { return asyncOp.isDone; } }

    public void GetResult() { }

    public void OnCompleted(Action continuation)
    {
        this.continuation = continuation;
    }

    private void OnRequestCompleted(AsyncOperation obj)
    {
        continuation();
    }
}

public static class ExtensionMethods
{
    public static UnityWebRequestAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
    {
        return new UnityWebRequestAwaiter(asyncOp);
    }
}
