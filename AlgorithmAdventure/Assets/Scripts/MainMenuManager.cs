using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    [SerializeField] private GameObject mainMenuPage;
    [SerializeField] private GameObject mapSelection;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject backSettingsButton;

    public void quickSortScene() {
        SceneManager.LoadScene("QuickSortScene");
    }

    public void MapSelection() {
        mainMenuPage.SetActive(false);
        mapSelection.SetActive(true);
    }

    public void SettingsPage() {
        settingsPage.SetActive(true);
        mainMenuPage.SetActive(false);
    }

    public void BackSettingsButton() {
        settingsPage.SetActive(false);
        mainMenuPage.SetActive(true);
    }

}
