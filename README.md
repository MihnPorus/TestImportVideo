# TestImportVideo
Reproduce the Unity's issue 761548 (https://issuetracker.unity3d.com/issues/movietexture-fmod-error-when-trying-to-play-video-using-www-class)

Hello,
When i am trying to load a video with WWW("file://" + path)
I'm getting the following errors:

> LoadMoveData got NULL!

> UnityEngine.WWW:get_movie()

> <Start>c__Iterator0:MoveNext() (at Assets/import.cs:13)

And 

> Error: Cannot create FMOD::Sound instance for resource (null), (An invalid parameter was passed to this function. )

> UnityEngine.WWW:get_movie()

> <Start>c__Iterator0:MoveNext() (at Assets/import.cs:13)


With the following code :

```C#
public class import : MonoBehaviour
{
    public string FileName;

    IEnumerator Start () {
        var path = Application.dataPath + "/" + FileName;

        WWW www = new WWW("file://" + path);
        while (!www.isDone)
            yield return www;
        
        var image = GetComponent<RawImage>();
        image.texture = www.movie;

        while (!www.movie.isReadyToPlay)
            yield return www;

        www.movie.Play();
    }
}
```

If i try with a simple image everything works fine.
The video is correctly encoded as .ogg in Theora format as stated in the [documentation](https://docs.unity3d.com/ScriptReference/WWW-movie.html)

I found the following [bug (issue 761548)](https://docs.unity3d.com/ScriptReference/WWW-movie.html) in the issue tracker but it still exist in **5.4.0b22**, **5.4.0b18**, **5.3.4f1** and **5.3.2f1** 


I made a small project that reproduce this issue, you can find it on github [here](https://github.com/ludo6577/TestImportVideo)

I really need help on this one...
Thank you
