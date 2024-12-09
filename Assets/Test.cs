using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public void OnButtonClick(string funcname)
    {
        SendMessage(funcname);
    }

    void UnloadUnusedAssets()
    {
        Resources.UnloadUnusedAssets();
    }
    void LoadResScene()
    {
        SceneManager.sceneLoaded+= OnSceneLoaded;
        SceneManager.LoadScene("ResScene", LoadSceneMode.Additive);
    }
    void DestroyImage(){
        var go = GameObject.Find("Image");
        if (go != null)
            Destroy(go);
    }
    void LoadImage2(){
        var sprite = Resources.Load<Sprite>("bigimage2");
        var go = GameObject.Find("Image2");
        go.GetComponent<Image>().sprite = sprite;
    }
    void DestroyImage2(){
        var go = GameObject.Find("Image2");
        if (go != null)
            Destroy(go);
    }
    void UnLoadImage(){
        Resources.UnloadAsset(GameObject.Find("Image").GetComponent<Image>().sprite);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        GameObject.Find("Image").GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>());
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
