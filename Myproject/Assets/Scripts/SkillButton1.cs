using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillChange : MonoBehaviour
{
    public void SkillScene1Change()
    {
        SceneManager.LoadScene("SkillButton1");

    }
}