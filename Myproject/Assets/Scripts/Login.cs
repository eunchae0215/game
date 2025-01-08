using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Tooltip("로그인 성공 텍스트")]
    [SerializeField] private Text _loginText;

    void Start()
    {
        _loginText.gameObject.SetActive(false);

        // 버튼 클릭 이벤트 추가
        //_loginButton.onClick.AddListener(Login);
        _signupButton.onClick.AddListener(SignUp);
    }

    /// <summary>로그인 함수</summary>
   /* private void Login()
    {
        // 유효성 검사: 아이디와 비밀번호 입력 확인
        if (string.IsNullOrEmpty(_idInput.text) || string.IsNullOrEmpty(_passwordInput.text))
        {
            Debug.Log("아이디 또는 비밀번호를 입력하세요.");
            return;  // 유효성 검사를 통과하지 않으면 함수 종료
        }

        // 로그인 성공 처리 (예: 성공 텍스트 표시)
        Debug.Log("로그인 성공");

        // 로그인 성공 후 UI 업데이트
        HideLoginUI();
    }*/

    /// <summary>회원가입 함수</summary>
    private void SignUp()
    {
        SceneManager.LoadScene("Sign");
    }

    /// <summary>로그인 성공시 로그인 관련 UI들을 비활성화 시키는 함수</summary>
    private void HideLoginUI()
    {
        _idInput.gameObject.SetActive(false);
        _passwordInput.gameObject.SetActive(false);
        _loginButton.gameObject.SetActive(false);
        _signupButton.gameObject.SetActive(false);

        _loginText.gameObject.SetActive(true);
    }
}
