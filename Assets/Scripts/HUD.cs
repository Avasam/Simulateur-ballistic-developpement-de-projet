using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Canvas CanvasOptionsJeu;
    public Canvas CanvasHUD;
    public Canvas CanvasAide;

    void Awake()
    {
        CanvasOptionsJeu.enabled = false;
        CanvasAide.enabled = false;
    }

    public void menu_principal()
    {
        SceneManager.LoadScene(0); 
    }

    public void reset()
    {
        SceneManager.LoadScene(1);
    }
        

    public void OptionsMenu()
    {
        CanvasOptionsJeu.enabled = true;
        CanvasHUD.enabled = false;

    }

    public void RetourMenu()
    {
        CanvasOptionsJeu.enabled = false;
        CanvasAide.enabled = false;
        CanvasHUD.enabled = true;

    }

    public void AideMenu()
    {
        CanvasHUD.enabled = false;
        CanvasAide.enabled = true;
    }

}
