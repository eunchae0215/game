using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking; // 서버와 통신을 위한 네임스페이스
using System.Collections;

public class SignManager : MonoBehaviour
{
    [Tooltip("닉네임 입력 필드")]
    [SerializeField] private InputField _nicknameInput;

    [Tooltip("아이디 입력 필드")]
    [SerializeField] private InputField _idInput;

    [Tooltip("비밀번호 입력 필드")]
    [SerializeField] private InputField _passwordInput;

    [Tooltip("회원가입 버튼")]
    [SerializeField] private Button _signupButton;

    [Tooltip("회원가입 성공/실패 메시지 텍스트")]
    [SerializeField] private Text _signupText;

    void Start()
    {
        _signupText.gameObject.SetActive(false);

        // 버튼 클릭 이벤트 추가
        _signupButton.onClick.AddListener(SignUp);
    }

    /// <summary>회원가입 함수</summary>
    private void SignUp()
    {
        // 유효성 검사: 닉네임, 아이디, 비밀번호 입력 확인
        if (string.IsNullOrEmpty(_nicknameInput.text) ||
            string.IsNullOrEmpty(_idInput.text) ||
            string.IsNullOrEmpty(_passwordInput.text))
        {
            _signupText.text = "닉네임, 아이디, 비밀번호를 모두 입력하세요.";
            _signupText.color = Color.red;
            _signupText.gameObject.SetActive(true);
            return;  // 유효성 검사를 통과하지 않으면 함수 종료
        }

        // 서버와 통신하여 회원가입 요청
        StartCoroutine(SignUpRequest(_nicknameInput.text, _idInput.text, _passwordInput.text));
    }

    /// <summary>회원가입 요청을 서버에 보냄</summary>
    private IEnumerator SignUpRequest(string nickname, string id, string password)
    {
        // JSON 데이터 생성
        // 서버 코드에서 { id, password, nickname } 형태로 받는다고 가정
        string json = JsonUtility.ToJson(new { id = id, password = password, nickname = nickname });

        // HTTP POST 요청 생성
        using (UnityWebRequest request = new UnityWebRequest("http://localhost:3000/register", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // 요청 보내기
            yield return request.SendWebRequest();

            // 응답 처리
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("회원가입 응답: " + request.downloadHandler.text);

                // 서버 응답에서 success 여부 확인
                if (request.downloadHandler.text.Contains("\"success\":true"))
                {
                    _signupText.text = "회원가입 성공! 로그인 화면으로 이동합니다.";
                    _signupText.color = Color.green;
                    _signupText.gameObject.SetActive(true);

                    // 일정 시간 후 로그인 화면으로 전환
                    yield return new WaitForSeconds(2f);
                    SceneManager.LoadScene("Login");
                }
                else
                {
                    _signupText.text = "회원가입 실패: 이미 존재하는 아이디이거나 서버 오류.";
                    _signupText.color = Color.red;
                    _signupText.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("회원가입 요청 실패: " + request.error);
                _signupText.text = "서버 연결 실패!";
                _signupText.color = Color.red;
                _signupText.gameObject.SetActive(true);
            }
        }
    }
}
