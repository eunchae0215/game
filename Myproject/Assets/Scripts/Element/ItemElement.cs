using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 개별 아이템 요소를 관리하는 클래스
/// </summary>
public class ItemElement : MonoBehaviour
{
    [Header("UI Elements")]
    [Tooltip("아이템 아이콘 이미지")]
    public Image IMGICON;

    [Tooltip("아이템 레벨 텍스트")]
    public Text TEXTLEVEL;

    [Tooltip("아이템 개수 텍스트")]
    public Text TEXTCOUNT;

    private string itemName;  // 아이템 이름 (내부 관리용)
    private int itemLevel;    // 아이템 레벨 (내부 관리용)
    private int itemCount;    // 아이템 개수 (내부 관리용)

    /// <summary>
    /// 아이템 정보를 설정하는 메서드
    /// </summary>
    public void SetItemInfo(string name, Sprite icon, int level, int count)
    {
        itemName = name;
        itemLevel = level;
        itemCount = count;

        if (IMGICON != null)
            IMGICON.sprite = icon;

        if (TEXTLEVEL != null)
            TEXTLEVEL.text = $"Lv. {level}";

        if (TEXTCOUNT != null)
            TEXTCOUNT.text = $"x {count}";

        Debug.Log($"아이템 설정 완료: {itemName}, 레벨: {itemLevel}, 개수: {itemCount}");
    }

    /// <summary>
    /// UI 요소를 기본값으로 초기화하는 메서드
    /// </summary>
    public void ResetItem()
    {
        if (IMGICON != null)
            IMGICON.sprite = null;

        if (TEXTLEVEL != null)
            TEXTLEVEL.text = "Lv. 0";

        if (TEXTCOUNT != null)
            TEXTCOUNT.text = "x 0";

        itemName = "";
        itemLevel = 0;
        itemCount = 0;

        Debug.Log("아이템 초기화 완료");
    }

    /// <summary>
    /// 아이템 클릭 시 호출될 이벤트
    /// </summary>
    public void OnBtnClick()
    {
        Debug.Log($"아이템 클릭됨: {itemName}, 레벨: {itemLevel}, 개수: {itemCount}");

        // TODO: 아이템 클릭 시 상세 정보를 보여주는 UI를 활성화하는 로직 추가
    }
}
