using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginChange : MonoBehaviour
{
    public void LoginSceneChange()
    {
        SceneManager.LoadScene("Login_new");

    }
}