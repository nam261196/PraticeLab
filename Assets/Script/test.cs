using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Image))]

// only work at the cost of more processing (improve UX)
public class test : MonoBehaviour 
{
    UnityEngine.UI.Image _img;
    //http://www.pooyak.com/p/progjpeg/jpegload.cgi?o=1
    //http://bbshowcase.org/progressive/?r=4&progressive=330438&rate=0
    private string url = "http://bbshowcase.org/progressive/?r=4&progressive=330438&rate=0";
    private UnityWebRequest wr;
    private Texture2D texture;
    private Sprite sprite;
    private DownloadHandlerTexture texDl;
    private bool isPause = false;
    private void Start()
    {
        _img = GetComponent<UnityEngine.UI.Image>();

    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Download(url);
            StartCoroutine(Downloadupdate());
        }


        if (Input.GetKeyDown(KeyCode.B))
        {
            isPause = true;
            StartCoroutine(outViewUpdate());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isPause = false;
        }




    }


    public void Download (string _url)
    {

        texture = new Texture2D(2, 2);
        wr = new UnityWebRequest(_url);
        texDl = new DownloadHandlerTexture(true);
        wr.downloadHandler = texDl;
        wr.chunkedTransfer = true;
        wr.SendWebRequest();
        sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
        _img.sprite = sprite;
        //del_action += Downloadupdate;
    }

    IEnumerator Downloadupdate()
    {
        while (!wr.isDone)
        {
            while (isPause && !wr.isDone)
            {
                yield return null;
            }
            if (wr.downloadProgress > 0.1f)
            {
                texture.LoadImage(texDl.data); //need something else SLOW really SLOW
            }
            yield return null;
        }
        texture.LoadImage(texDl.data);
        texture = texDl.texture;
    }
    IEnumerator outViewUpdate()
    {
        while (!wr.isDone)
        {
            yield return null;
        }
        texture.LoadImage(texDl.data);

    }

}
