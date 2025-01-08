using UnityEngine;

public class BackgroundColorChanger : MonoBehaviour
{
    // 시작할 때 배경색을 설정합니다.
    void Start()
    {
        // 카메라의 배경색을 하늘색으로 변경
        Camera.main.backgroundColor = Color.cyan; 
    }

    // 매 프레임마다 배경색을 변경
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바를 누르면 색이 변경됩니다.
        {
            Camera.main.backgroundColor = new Color(Random.value, Random.value, Random.value); // 랜덤 색
        }
    }
}
