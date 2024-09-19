using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    public TMPro.TMP_InputField pathInput;
    public int screenShotWidth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            takeScreenShot();
        }
    }

    public void takeScreenShot()
    {
        StartCoroutine(takeSnap());
    }

    private IEnumerator takeSnap()
    {
        yield return new WaitForEndOfFrame();
        Camera currCam = Camera.main;
        int totalWidth = currCam.pixelWidth;
        int totalHeight = currCam.pixelHeight;

        int outWidth = screenShotWidth;

        Texture2D ss = new Texture2D(outWidth, totalHeight, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, outWidth, totalHeight), 0, 0);
        ss.Apply();
        byte[] byteArray = ss.EncodeToPNG();
        string savePath = Path.GetFullPath(Application.persistentDataPath + "/AZThruster_" + DateTime.Now.ToFileTime() + ".png");

        TextEditor te = new TextEditor();
        te.content = new GUIContent(savePath);
        te.SelectAll();
        te.Copy();

        System.IO.File.WriteAllBytes(savePath, byteArray);
        pathInput.text = Path.GetFullPath(savePath);
        // Destroy texture to avoid memory leaks
        Destroy(ss);
    }
}
