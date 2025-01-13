using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;


public class LoginManager : MonoBehaviour
{
    [Tooltip("아이디 입력 필드")]
    [SerializeField] private InputField _idInput;

    [Tooltip("비밀번호 입력 필드")]
    [SerializeField] private InputField _passwordInput;

    [Tooltip("로그인 버튼")]
    [SerializeField] private Button _loginButton;

    [Tooltip("회원가입 버튼")]
    [SerializeField] private Button _signupButton;

    [Tooltip("로그인 성공/실패 텍스트")]
    [SerializeField] private Text _loginText;

    void Start()
    {
        _loginText.gameObject.SetActive(false);

        // 버튼 클릭 이벤트 추가
        _loginButton.onClick.AddListener(Login);
        _signupButton.onClick.AddListener(SignUp);
    }

    /// <summary>로그인 함수</summary>
    private void Login()
    {
        // 유효성 검사: 아이디와 비밀번호 입력 확인
        if (string.IsNullOrEmpty(_idInput.text) || string.IsNullOrEmpty(_passwordInput.text))
        {
            _loginText.text = "아이디 또는 비밀번호를 입력하세요.";
            _loginText.color = Color.red;
            _loginText.gameObject.SetActive(true);
            return;  // 유효성 검사를 통과하지 않으면 함수 종료
        }

        // 서버에 로그인 요청
        StartCoroutine(LoginRequest(_idInput.text, _passwordInput.text));
    }

    /// <summary>회원가입 화면으로 이동</summary>
    private void SignUp()
    {
        SceneManager.LoadScene("Sign"); // 회원가입 화면으로 이동
    }

    /// <summary>로그인 요청을 서버에 보냄</summary>
    private IEnumerator LoginRequest(string username, string password)
    {
        // JSON 데이터 생성
        string json = JsonUtility.ToJson(new { username = username, password = password });

        // HTTP POST 요청 생성
        using (UnityWebRequest request = new UnityWebRequest("http://localhost:3000/login", "POST"))
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
                Debug.Log("로그인 응답: " + request.downloadHandler.text);

                // 서버 응답에서 성공 여부 확인
                if (request.downloadHandler.text.Contains("\"success\":true"))
                {
                    _loginText.text = "로그인 성공!";
                    _loginText.color = Color.green;
                    _loginText.gameObject.SetActive(true);

                    // 로그인 성공 후 메인 씬으로 이동
                    yield return new WaitForSeconds(2f);
                    SceneManager.LoadScene("Main"); // "Main" 씬으로 이동
                }
                else
                {
                    _loginText.text = "로그인 실패: 아이디 또는 비밀번호가 잘못되었습니다.";
                    _loginText.color = Color.red;
                    _loginText.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.LogError("로그인 요청 실패: " + request.error);
                _loginText.text = "서버 연결 실패!";
                _loginText.color = Color.red;
                _loginText.gameObject.SetActive(true);
            }
        }
    }
}