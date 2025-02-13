using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartChange : MonoBehaviour
{
    public void StartSceneChange()
    {
        SceneManager.LoadScene("Lobby");

    }
}