using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class SongLoader : MonoBehaviour
{
    public float positionDivider = 7;
    public float scaleMultiplier = 1.3f;
    public List<GameObject> stageObjs = new List<GameObject>();

    public Vector2 stageOffset = new Vector2(10, 0);
    // Start is called before the first frame update
    void Start()
    {
        //Song song = Loader.LoadSong(Path.Combine(AssetPaths.GetSongPath(PersistentProperties.songName), $"{PersistentProperties.songName}-chart.json"));
        SongMetadata meta = Loader.LoadSongMetadata(Path.Combine(AssetPaths.GetSongPath(PersistentProperties.songName), $"{PersistentProperties.songName}-metadata.json"));

        #region Stage Preparation
        Stage stage = Loader.LoadStage(AssetPaths.GetStagePath(meta.playData.stage));
        foreach (StageSprite sprite in stage.props)
        {
            // its not downloading the texture
            // it gets it from the path defined by the stagesprite
            //UnityWebRequest texwww = UnityWebRequestTexture.GetTexture(AssetPaths.StageSpriteToPath(sprite, stage.directory));
            //texwww.SendWebRequest();
            var rawData = File.ReadAllBytes(AssetPaths.StageSpriteToPath(sprite, stage.directory));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(rawData);
            GameObject obj = new GameObject(sprite.name);
            SpriteRenderer renderer = obj.AddComponent<SpriteRenderer>();
            renderer.sortingOrder = sprite.zIndex;
            renderer.sprite = Sprite.Create(tex, new Rect(new Vector2(0, 0), new Vector2(tex.width, tex.height)), Vector2.zero);
            obj.transform.position = new Vector3((sprite.position[0] / positionDivider) + stageOffset.x, Camera.main.gameObject.transform.position.y - (sprite.position[1] / positionDivider) + stageOffset.y, sprite.scroll[0] + sprite.scroll[1]);
            obj.transform.localScale = new Vector3(sprite.scale[0], sprite.scale[1]) * scaleMultiplier;
            stageObjs.Add(obj);
            //Instantiate(obj);
        }
        #endregion
        #region Song Loading
        // HUGE BUG: GAME HANGS HERE
        //Task<AudioClip> taskInst = Loader.LoadSongAudio(Path.Combine(AssetPaths.GetSongMusicPath(meta.songName), "inst.ogg"));
        //taskInst.Wait();
        //GameObject inst = new GameObject("inst");
        //AudioSource audioSourceInst = inst.AddComponent<AudioSource>();
        //audioSourceInst.clip = taskInst.Result;

        //Task<AudioClip> taskVoices = Loader.LoadSongAudio(Path.Combine(AssetPaths.GetSongMusicPath(meta.songName), "Voices.ogg"));
        //taskVoices.Wait();
        //GameObject voices = new GameObject("Voices");
        //AudioSource audioSourceVoices = voices.AddComponent<AudioSource>();
        //audioSourceVoices.clip = taskVoices.Result;

        //audioSourceInst.Play();
        //audioSourceVoices.Play();

        // TODO: add notes.. will uhh be pretty difficult cant lie
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
