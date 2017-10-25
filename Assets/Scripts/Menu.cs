using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas CanvasMenu;
    public Canvas CanvasOptions;
    
    void Awake()
    {
        CanvasOptions.enabled = false;
    }

    public void OptionsMenu()
    {
        CanvasOptions.enabled = true;
        CanvasMenu.enabled = false;
    }

    public void RetourMenu()
    {
        CanvasOptions.enabled = false;
        CanvasMenu.enabled = true;
    }

    public void LoadSimul()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCible()
    {
        SceneManager.LoadScene(2);
    }
}
