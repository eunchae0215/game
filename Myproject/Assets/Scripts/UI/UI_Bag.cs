using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

/// <summary>
/// 가방(UI) 관리 클래스 - 인벤토리 저장 및 불러오기 기능 추가
/// </summary>
public class UI_Bag : UI_Base
{
    [Header("UI Elements")]
    [Tooltip("아이템이 배치될 부모 오브젝트")]
    public Transform TRPOS;

    [Header("Inventory Settings")]
    [Tooltip("인벤토리 아이템 개수")]
    public int InvenCount = 10;

    private Dictionary<int, ItemElement> IEMap = new Dictionary<int, ItemElement>();
    private List<InventoryItem> inventoryData = new List<InventoryItem>();

    /// <summary>
    /// UI 초기화 시 실행 (큐에 추가)
    /// </summary>
    private void Awake()
    {
        base.SetEnQueue();
        Debug.Log("UI_Bag 초기화 완료.");
    }

    /// <summary>
    /// 인벤토리 아이템 불러오기 및 생성
    /// </summary>
    private void Start()
    {
        LoadInventory();
        PopulateInventory();
    }

    /// <summary>
    /// 저장된 인벤토리 데이터를 불러오기
    /// </summary>
    private void LoadInventory()
    {
        if (PlayerPrefs.HasKey("InventoryData"))
        {
            string json = PlayerPrefs.GetString("InventoryData");
            inventoryData = JsonConvert.DeserializeObject<List<InventoryItem>>(json);
            Debug.Log("인벤토리 데이터 로드 완료.");
        }
        else
        {
            Debug.Log("저장된 인벤토리가 없습니다. 새로운 인벤토리 생성.");
            GenerateRandomInventory();
        }
    }

    /// <summary>
    /// 인벤토리를 초기화 및 화면에 표시
    /// </summary>
    private void PopulateInventory()
    {
        if (TRPOS == null)
        {
            Debug.LogError("TRPOS가 할당되지 않았습니다. Unity 인스펙터에서 설정하세요.");
            return;
        }

        for (int i = 0; i < inventoryData.Count; ++i)
        {
            UnityEngine.Object obj = Resources.Load("Prefabs/Element/ItemElement");

            if (obj == null)
            {
                Debug.LogError("ItemElement 프리팹을 찾을 수 없습니다. 경로 확인.");
                return;
            }

            GameObject gobj = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
            gobj.transform.SetParent(TRPOS, false);

            ItemElement ie = gobj.GetComponent<ItemElement>();
            if (ie == null)
            {
                Debug.LogError("ItemElement 컴포넌트를 찾을 수 없습니다.");
                return;
            }

            // 불러온 인벤토리 데이터를 적용
            ie.TEXTLEVEL.text = inventoryData[i].Level.ToString();
            ie.TEXTCOUNT.text = inventoryData[i].Count.ToString();

            IEMap.Add(i, ie);
        }
    }

    /// <summary>
    /// 무작위 인벤토리 데이터를 생성
    /// </summary>
    private void GenerateRandomInventory()
    {
        inventoryData.Clear();
        for (int i = 0; i < InvenCount; ++i)
        {
            inventoryData.Add(new InventoryItem
            {
                Level = Random.Range(1, 100),
                Count = Random.Range(1, 100000)
            });
        }
        SaveInventory();
    }

    /// <summary>
    /// 인벤토리 데이터를 저장
    /// </summary>
    public void SaveInventory()
    {
        string json = JsonConvert.SerializeObject(inventoryData);
        PlayerPrefs.SetString("InventoryData", json);
        PlayerPrefs.Save();
        Debug.Log("인벤토리 데이터 저장 완료.");
    }

    /// <summary>
    /// 인벤토리 데이터 초기화 및 삭제
    /// </summary>
    public void ClearInventory()
    {
        PlayerPrefs.DeleteKey("InventoryData");
        inventoryData.Clear();
        Debug.Log("인벤토리 데이터가 초기화되었습니다.");
    }

    /// <summary>
    /// 뒤로가기 버튼 클릭 시 호출 (UI 닫기)
    /// </summary>
    public override void OnBtnBack()
    {
        SaveInventory(); // UI 닫기 전에 인벤토리 저장
        gameObject.SetActive(false);
        Debug.Log("UI_Bag이(가) 비활성화됨 및 인벤토리 저장 완료.");
    }
}

/// <summary>
/// 인벤토리 아이템 구조체
/// </summary>
[System.Serializable]
public class InventoryItem
{
    public int Level;
    public int Count;
}
