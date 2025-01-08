using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SignManager : MonoBehaviour
{
    [Tooltip("아이디 입력 필드")]
    [SerializeField] private InputField _idInput;

    [Tooltip("비밀번호 입력 필드")]
    [SerializeField] private InputField _passwordInput;

    [Tooltip("회원가입 버튼")]
    [SerializeField] private Button _signupButton;

    [Tooltip("회원가입 성공 텍스트")]
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
        // 유효성 검사: 아이디와 비밀번호 입력 확인
        if (string.IsNullOrEmpty(_idInput.text) || string.IsNullOrEmpty(_passwordInput.text))
        {
            Debug.Log("아이디 또는 비밀번호를 입력하세요.");
            return;  // 유효성 검사를 통과하지 않으면 함수 종료
        }

        // 회원가입 성공 처리 (예: 로그인 화면으로 이동)
        Debug.Log("회원가입 성공");

        // 회원가입 후 로그인 화면으로 이동
        SceneManager.LoadScene("Login");
    }

    /// <summary>로그인 성공시 로그인 관련 UI들을 비활성화 시키는 함수</summary>
    private void HideLoginUI()
    {
        _idInput.gameObject.SetActive(false);
        _passwordInput.gameObject.SetActive(false);

        _signupButton.gameObject.SetActive(false);
    }
}
