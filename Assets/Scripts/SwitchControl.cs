using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SwitchControl : MonoBehaviour
{
    public GameObject menu;
    public GameObject levelsMenu;
    public GameObject shopMenu;
    public GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Play()
    {
        menu.SetActive(false);
        levelsMenu.SetActive(true);
    }
    public void Shop()
    {
        menu.SetActive(false);
        shopMenu.SetActive(true);
    }
    public void Settings()
    {
        menu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void EquitGame()
    {
        Application.Quit();
    }
    public void Level1()
    {
        SceneManager.LoadScene("Game");
    }
}
