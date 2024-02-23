using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterLoginManager : MonoBehaviour
{

    public static RegisterLoginManager instance;

    //MainMenu variables
    [Header("Main Menu")]
    [SerializeField] private Button mainMenuLogin;
    [SerializeField] private Button mainMenuRegister;
    [SerializeField] private Button exit;

    //Login variables
    [Header("Login")]
    [SerializeField] private GameObject registerLogin;
    [SerializeField] private Button loginbackButton;

    //Register variables
    [Header("Login")]
    [SerializeField] private Button RegisterLoginButton;
    [SerializeField] private Button registerbackButton;

    //Pages variables
    [Header("Pages")]
    [SerializeField] private GameObject loginRegisterPage;
    [SerializeField] private GameObject userLogin;
    

    //[SerializeField] private Button userLoginButton;
    
    //[SerializeField] private Button signUpButton;

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
        mainMenuLogin.onClick.AddListener(UserLoginUI);
        mainMenuRegister.onClick.AddListener(RegisterUI);
        exit.onClick.AddListener(ExitGame);

        loginbackButton.onClick.AddListener(MainMenuUI);

        RegisterLoginButton.onClick.AddListener(MainMenuScene);


        registerbackButton.onClick.AddListener(MainMenuUI);
        
    }

    public void MainMenuUI() {
        loginRegisterPage.SetActive(true);
        registerLogin.SetActive(false);
        userLogin.SetActive(false);
    }

    public void UserLoginUI()
    { // Switches to Login Page
        registerLogin.SetActive(false);
        loginRegisterPage.SetActive(false);
        userLogin.SetActive(true);
    }

    public void RegisterUI()
    { // Switches to Register Page
        registerLogin.SetActive(true);
        userLogin.SetActive(false);
    }

    public void MainMenuScene() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitGame() { 
        Application.Quit();
    }
}
