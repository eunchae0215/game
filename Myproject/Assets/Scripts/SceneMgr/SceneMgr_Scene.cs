using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum eSCENE
{
    eSCENE_TITLE,
    eSCENE_LOGIN,
    eSCENE_LOBBY,
    eSCENE_BATTLE,
    eSCENE_MAX  // 씬 개수 제한용
}

public partial class SceneMgr : MonoBehaviour
{
    private eSCENE nextScene = eSCENE.eSCENE_MAX;
    public eSCENE currentScene = eSCENE.eSCENE_TITLE;

    /// <summary>
    /// 씬 변경 요청 메서드
    /// </summary>
    public void ChangeScene(eSCENE targetScene, bool useLoading = false)
    {
        if (currentScene == targetScene)
        {
            Debug.Log("현재 씬과 동일하여 변경하지 않습니다.");
            return;
        }

        if (useLoading)
        {
            nextScene = targetScene;
            SceneManager.LoadScene("Loading");
            return;
        }
        else
        {
            currentScene = targetScene;
        }

        LoadScene(targetScene);
    }

    /// <summary>
    /// 로딩 씬 완료 후 호출될 메서드 (로딩 씬에서 호출)
    /// </summary>
    public void CheckLoading()
    {
        if (nextScene != eSCENE.eSCENE_MAX)
        {
            LoadScene(nextScene);
            nextScene = eSCENE.eSCENE_MAX;  // 씬 변경 후 초기화
        }
        else
        {
            Debug.LogError("다음 씬이 올바르게 설정되지 않았습니다.");
        }
    }

    /// <summary>
    /// 씬을 로드하는 내부 메서드
    /// </summary>
    private void LoadScene(eSCENE scene)
    {
        string sceneName = GetSceneName(scene);
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("잘못된 씬 요청: " + scene);
        }
    }

    /// <summary>
    /// eSCENE 열거형을 사용하여 씬 이름을 반환
    /// </summary>
    private string GetSceneName(eSCENE scene)
    {
        switch (scene)
        {
            case eSCENE.eSCENE_TITLE: return "Title";
            case eSCENE.eSCENE_LOGIN: return "Login_new";
            case eSCENE.eSCENE_LOBBY: return "Lobby";
            case eSCENE.eSCENE_BATTLE: return "Battle";
            default: return string.Empty;
        }
    }
}
