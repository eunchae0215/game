using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene1 : MonoBehaviour
{
    public string sceneName = "SkillButton1";

    public void ChangeScene()
    {
       
        SceneManager.LoadScene(sceneName);
    }
}
