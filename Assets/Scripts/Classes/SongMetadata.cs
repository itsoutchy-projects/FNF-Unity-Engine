using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongMetadata
{
    public string version;
    public string songName;
    public string artist;
    public string charter;
    public string timeFormat;
    public TimeChange[] timeChanges;
    public PlayData playData;
    public string generatedBy;

    public SongMetadata(string version, string songName, string artist, string charter, string timeFormat, TimeChange[] timeChanges, PlayData playData, string generatedBy)
    {
        this.version = version;
        this.songName = songName;
        this.artist = artist;
        this.charter = charter;
        this.timeFormat = timeFormat;
        this.timeChanges = timeChanges;
        this.playData = playData;
        this.generatedBy = generatedBy;
    }
}

public struct PlayData
{
    public Dictionary<string, int> ratings;
    public string[] songVariations;
    public string[] difficulties;
    public SongCharacters characters;
    public string stage;
    public string noteStyle;
    public string album;
    public long previewStart;
    public long previewEnd;

    public PlayData(Dictionary<string, int> ratings, string[] songVariations, string[] difficulties, SongCharacters characters, string stage, string noteStyle, string album, long previewStart, long previewEnd)
    {
        this.ratings = ratings;
        this.songVariations = songVariations;
        this.difficulties = difficulties;
        this.characters = characters;
        this.stage = stage;
        this.noteStyle = noteStyle;
        this.album = album;
        this.previewStart = previewStart;
        this.previewEnd = previewEnd;
    }
}

public struct SongCharacters
{
    public string player;
    public string girlfriend;
    public string opponent;
    public string[] altInstrumentals;

    public SongCharacters(string player,  string girlfriend, string opponent, string[] altInstrumentals)
    {
        this.player = player;
        this.girlfriend = girlfriend;
        this.opponent = opponent;
        this.altInstrumentals = altInstrumentals;
    }
}

public struct TimeChange
{
    public long t;
    public int bpm;
    public int n;
    public int d;
    public int[] bt;

    public TimeChange(long t, int bpm, int n, int d, int[] bt)
    {
        this.t = t;
        this.bpm = bpm;
        this.n = n;
        this.d = d;
        this.bt = bt;
    }
}