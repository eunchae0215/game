using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene4 : MonoBehaviour
{
    public string sceneName = "SkillButton4";

    public void ChangeScene()
    {
        
        SceneManager.LoadScene(sceneName);
    }
}
