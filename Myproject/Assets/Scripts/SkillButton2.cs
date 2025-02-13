using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene2 : MonoBehaviour
{
    public string sceneName = "SkillButton2";

    public void ChangeScene()
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
