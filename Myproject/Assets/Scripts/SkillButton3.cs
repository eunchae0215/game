using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene3 : MonoBehaviour
{
    public string sceneName = "SkillButton3";

    public void ChangeScene()
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
