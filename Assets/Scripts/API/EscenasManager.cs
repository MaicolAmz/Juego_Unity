using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscenasManager : MonoBehaviour
{
    [Header("Login")]
    [SerializeField] private InputField m_loginPasswordInput = null;
    [SerializeField] private InputField m_loginUsernameInput = null;

    [Header("Register")]
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;
    [SerializeField] private Text m_text;

    [SerializeField] private InputField m_usernameInput = null;
    [SerializeField] private InputField m_passwordInput = null;
    [SerializeField] private InputField m_reEnterPasswordInput = null;

    private NetworkManager m_networkManager = null;
    public void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void SubmitLogin()
    {
        if (m_loginPasswordInput.text == "" || m_loginUsernameInput.text == "") 
        {
            m_text.text = "Por favor llenar todos los datos";
            m_text.color = Color.red;
            return;
        }
        m_text.text = "Procesando...";

        m_networkManager.CheckUser(m_loginUsernameInput.text, m_loginPasswordInput.text, delegate (CResponse res)
        {
            m_text.text = res.message;

            if (res.done)
            {
                useSinRegister();
                m_text.color = Color.green;
            }
            else
            {
                m_text.color = Color.red;
            }
        });
    }

    public void SubmitRegister()
    {
        if (m_usernameInput.text == "" || m_passwordInput.text == "" || m_reEnterPasswordInput.text == "")
        {
            m_text.text = "Por favor llenar todos los campos";
            m_text.color = Color.red;
            return;
        }
        if (m_passwordInput.text == m_reEnterPasswordInput.text)
        {
            m_text.text = "Procesando...";
            m_text.color = Color.blue;
            m_networkManager.CrearUser(m_usernameInput.text, m_passwordInput.text, delegate(CResponse res)
            {
                m_text.text = res.message;
                if (res.done)
                {
                    m_text.color = Color.green;
                    useSinRegister();
                }
                else
                {
                    m_text.color = Color.red;
                }
            });
        }
        else
        {
            m_text.text = "Contraseña no son iguales";
            m_text.color = Color.red;
        }
    }
    public void ShowLogin()
    {
        m_text.text = "";
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }

    public void ShowRegister()
    {
        m_text.text = "";
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }

    public void useSinRegister()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
