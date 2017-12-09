using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Canvas CanvasOptionsJeu;
    public Canvas CanvasHUD;
    public Canvas CanvasAide;
    private int starter;


    void start() {
        Cursor.visible = true;
    }

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
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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
        Debug.Log("!!!!!");
    }

    public void ChangeMap() {

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "UI_Test" || scene.name == "Plaine Italie")
            Application.LoadLevel(2);
        
        else if (scene.name == "Montagne Lac" ) 
            Application.LoadLevel(3);
        
        else if (scene.name == "Moyen Orient") 
            Application.LoadLevel(4);
        
        else if (scene.name == "Désert") 
            Application.LoadLevel(5);
        
    }
}
