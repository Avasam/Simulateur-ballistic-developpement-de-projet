using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public Canvas CanvasOptionsJeu;
    public Canvas CanvasHUD;
    public Canvas CanvasAide;
	public Canvas CanvasChoix;	

    void Start() {
        Cursor.visible = true;
    }
	
    void Awake()
    {
        CanvasOptionsJeu.enabled = false;
        CanvasAide.enabled = false;
        CanvasChoix.enabled = false;
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
        CanvasChoix.enabled = false;
        CanvasHUD.enabled = true;

    }

    public void AideMenu()
    {
        CanvasHUD.enabled = false;
        CanvasAide.enabled = true;
    }

    public void ChangeMap(string nomMap) {

        SceneManager.LoadScene(nomMap); 
    }
	
	public void ChoixMenu()
    {
        CanvasHUD.enabled = false;
        CanvasChoix.enabled = true;
    }

}
