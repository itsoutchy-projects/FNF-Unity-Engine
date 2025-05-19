using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song
{
    public string version;
    public Dictionary<string, float> scrollSpeed;
    public Event[] events;
    public Note[][] notes; // an array of arrays of notes
    public string generatedBy;

    public Song(string version, Dictionary<string, float> scrollSpeed, Event[] events, Note[][] notes, string generatedBy)
    {
        this.version = version;
        this.scrollSpeed = scrollSpeed;
        this.events = events;
        this.notes = notes;
        this.generatedBy = generatedBy;
    }
}

public struct Event
{
    public long t;
    public string e;
    public Dictionary<string, dynamic> v;

    public Event(long t, string e, Dictionary<string, dynamic> v)
    {
        this.t = t;
        this.e = e;
        this.v = v;
    }
}

public struct Note
{
    public long t;
    public int d;
    public long? l;

    public Note(long t, int d, long? l)
    {
        this.t = t;
        this.d = d;
        this.l = l;
    }
}