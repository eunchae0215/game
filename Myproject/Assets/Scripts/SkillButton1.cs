using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveScene1 : MonoBehaviour
{
    public string sceneName = "SkillButton1";

    public void ChangeScene()
    {
        Debug.Log("버튼 클릭됨! 씬 이동: " + sceneName); // 클릭 로그 추가
        SceneManager.LoadScene(sceneName);
    }
}
