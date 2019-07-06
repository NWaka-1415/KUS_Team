using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManger : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) OnclickMoveToGameScene();
    }

    public void OnclickMoveToGameScene()
    {
        SceneManager.LoadSceneAsync("Sample");
    }
}
