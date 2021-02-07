using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SwitchControl : MonoBehaviour
{
    public GameObject menu;
    public GameObject levels;
    public GameObject shop;
    public GameObject settings;
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
        menu.SetActive(true);
    }
    public void Play()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }
    public void Shop()
    {
        menu.SetActive(false);
        shop.SetActive(true);
    }
    public void Settings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

}
