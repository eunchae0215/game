using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 모든 UI 클래스의 기본 클래스
/// UI 오브젝트의 큐 관리를 담당
/// </summary>
public class UI_Base : MonoBehaviour
{
    /// <summary>
    /// UI를 큐에 추가 (활성화 대기)
    /// </summary>
    public void SetEnQueue()
    {
        if (Shared.QueUI != null)
        {
            Shared.QueUI.Enqueue(this);
            Debug.Log($"{gameObject.name}이(가) UI 큐에 추가되었습니다. 현재 큐 크기: {Shared.QueUI.Count}");
        }
        else
        {
            Debug.LogError("Shared.QueUI가 초기화되지 않았습니다. Shared 클래스를 확인하세요.");
        }
    }

    /// <summary>
    /// UI 닫기 버튼 클릭 시 실행
    /// UI를 큐에서 제거하고 비활성화 처리
    /// </summary>
    public virtual void OnBtnBack()
    {
        if (Shared.QueUI != null && Shared.QueUI.Count > 0)
        {
            Shared.QueUI.Dequeue();
            gameObject.SetActive(false);
            Debug.Log($"{gameObject.name}이(가) UI 큐에서 제거되었습니다. 남은 큐 크기: {Shared.QueUI.Count}");
        }
        else
        {
            Debug.LogError("큐가 비어있거나 Shared.QueUI가 초기화되지 않았습니다.");
        }
    }
}
