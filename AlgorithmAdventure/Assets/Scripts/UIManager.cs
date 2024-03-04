using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;


    [SerializeField] private GameObject userLogin;
    [SerializeField] private GameObject RegisterLogin;
    [SerializeField] private Button userLoginButton;
    [SerializeField] private Button RegisterLoginButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button signUpButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        RegisterLoginButton.onClick.AddListener(RegisterScene);
        backButton.onClick.AddListener(UserLoginScene);
    }

    public void UserLoginScene()
    { // Switches to Login Page
        RegisterLogin.SetActive(false);
        userLogin.SetActive(true);
    }

    public void RegisterScene()
    { // Switches to Register Page
        RegisterLogin.SetActive(true);
        userLogin.SetActive(false);
    }
}
