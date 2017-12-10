using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public Canvas CanvasOptionsJeu;
    public Canvas CanvasHUD;
    public Canvas CanvasAide;
    private int starter;


    void Start() {
        Cursor.visible = true;
    }

    void Awake()
    {
        CanvasOptionsJeu.enabled = false;
        CanvasAide.enabled = false;

    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0); 
    }

    public void Reset()
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
            SceneManager.LoadScene(2);
        
        else if (scene.name == "Montagne Lac" )
            SceneManager.LoadScene(3);
        
        else if (scene.name == "Moyen Orient")
            SceneManager.LoadScene(4);
        
        else if (scene.name == "Désert")
            SceneManager.LoadScene(5);
        
    }
}
