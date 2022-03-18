using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotSystem : MonoBehaviour
{
    public Camera cam;

    public int resWidth = 1920;
    public int resHeight = 1080;

    private string fileName;

    private RenderTexture rt;
    private Texture2D screenShot;

    public static string ScreenshotName()
    {
        return string.Format("{0}/Resources/Output/photo_{1}.png",
                             Application.dataPath,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void TakeScreen()
    {
        Debug.Log("screen");

        rt = new RenderTexture(resWidth, resHeight, 24);
        cam.targetTexture = rt;
        screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        cam.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        cam.targetTexture = null;
        RenderTexture.active = null;
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        fileName = ScreenshotName();
        System.IO.File.WriteAllBytes(fileName, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", fileName));
    }
}
