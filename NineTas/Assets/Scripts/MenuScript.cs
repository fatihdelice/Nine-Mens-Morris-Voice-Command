using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject ExitPanel;
    public GameObject SettingsPanel;
    public GameObject DeveloperAboutPanel;
    public GameObject HowToPlayPanel;

    public void Start()
    {
        ExitPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        DeveloperAboutPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
    }
    public void BaslaButon()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Oyun Sahnesine Geçildi");
    }
    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
    }
    public void DeveloperAboutButton()
    {
        DeveloperAboutPanel.SetActive(true);
    }
    public void HowToPlaytButton()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void ExitButon()
    {
        ExitPanel.SetActive(true);
        
    }

    public void YesButton()
    {
        Application.Quit();
        Debug.Log("Oyundan çıkış yapıldı.");
    }
    public void NoButton()
    {
        ExitPanel.SetActive(false);
        SettingsPanel.SetActive(false);
        DeveloperAboutPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
    }
}
