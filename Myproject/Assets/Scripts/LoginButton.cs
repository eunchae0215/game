using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignChange : MonoBehaviour
{
    public void SignSceneChange()
    {
        SceneManager.LoadScene("Sign");

        Debug.LogError("잘못된 씬 요청: " );

    }
}