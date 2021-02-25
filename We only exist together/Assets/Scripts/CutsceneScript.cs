using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CutsceneScript : MonoBehaviour
{
    public float delay = 21f;
    public string NewLevel = "Level1";
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }


}
