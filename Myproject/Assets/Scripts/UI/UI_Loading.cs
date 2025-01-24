using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Loading : MonoBehaviour
{
    [Header("UI Components")]
    public Text loadingText;
    public Image loadingImage;

    [Header("Loading Settings")]
    public List<string> loadingMessages;
    public Sprite[] loadingSprites;

    [Tooltip("Loading duration in seconds")]
    public float loadingDuration = 3f;

    private int messageIndex;
    private int spriteIndex;

    void Start()
    {
        StartCoroutine(LoadingCoroutine());
    }

    void UpdateLoadingScreen()
    {
        // 무작위로 메시지 및 이미지 선택
        messageIndex = Random.Range(0, loadingMessages.Count);
        spriteIndex = Random.Range(0, loadingSprites.Length);

        // 텍스트 및 이미지 업데이트
        loadingText.text = loadingMessages[messageIndex];
        loadingImage.sprite = loadingSprites[spriteIndex];
    }

    IEnumerator LoadingCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < loadingDuration)
        {
            UpdateLoadingScreen();
            yield return new WaitForSeconds(1f);
            elapsedTime += 1f;
        }

        // 로딩 완료 후 로비 씬으로 전환
        LoadNextScene();
    }

    void LoadNextScene()
    {
        Debug.Log("Loading Complete. Transitioning to the Lobby scene...");
        SceneManager.LoadScene("Lobby");  // 로비 씬으로 전환
    }
}
