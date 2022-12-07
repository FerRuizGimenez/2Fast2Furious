using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image fade;
    public string[] scenes;

    private void Start() 
    {
        fade.CrossFadeAlpha(0, 0.5f, false);        
    }

    public void FadeOut(int s)
    {
        fade.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(SceneChange(scenes[s]));
    }
    IEnumerator SceneChange(string scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    } 
}
