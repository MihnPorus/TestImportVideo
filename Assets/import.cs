using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class import : MonoBehaviour
{
    public string FileName;

    public bool IsVideo;

    IEnumerator Start () {
        var path = Application.dataPath + "/" + FileName;

        Debug.Log("Importing file " + path);

        WWW www = new WWW("file://" + path);
        while (!www.isDone)
            yield return www;

        Debug.Log("File imported size: " + www.size);

        if (IsVideo)
        {
            Debug.Log("Movie ready to play");

            var image = GetComponent<RawImage>();
            image.texture = www.movie;

            while (!www.movie.isReadyToPlay)
                yield return www;

            www.movie.Play();

            Debug.Log("Movie played");
        }
        else
        {
            var image = GetComponent<RawImage>();
            image.texture = www.texture;
            Debug.Log("Texture loaded");
        }
    }
}
