using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EnginDeSiegeController))]
public class HUD : MonoBehaviour {

    public Canvas CanvasOptionsJeu;
    public Canvas CanvasHUD;
    public Canvas CanvasAide;
	public Canvas CanvasChoix;
    EnginDeSiegeController enginDeSiegeController;
    WindZonePhysics physicsWindZone;
    public float Direction {
        get { return physicsWindZone.Direction; }
        set { physicsWindZone.Direction = value; }
    }
    public float Strength {
        get { return physicsWindZone.Strength; }
        set { physicsWindZone.Strength = value; }
    }

    void Awake() {
        Cursor.visible = true;
        ClearCanvas();
        CanvasHUD.enabled = true;
        enginDeSiegeController = GetComponent<EnginDeSiegeController>();
        physicsWindZone = FindObjectOfType<WindZonePhysics>();
        if (physicsWindZone == null) {
            Debug.LogError("There is no WindZonePhysics in the scene!");
        }

    }

    private void ClearCanvas() {
        CanvasOptionsJeu.enabled = false;
        CanvasAide.enabled = false;
        CanvasChoix.enabled = false;
        CanvasHUD.enabled = false;
    }

    public void MenuPrincipal() {
        SceneManager.LoadScene(0); 
    }

    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        

    public void OptionsMenu() {
        ClearCanvas();
        CanvasOptionsJeu.enabled = true;
    }

    public void RetourMenu() {
        ClearCanvas();
        CanvasHUD.enabled = true;
    }

    public void AideMenu() {
        ClearCanvas();
        CanvasAide.enabled = true;
    }

    public void ChangeMap(string nomMap) {
        SceneManager.LoadScene(nomMap); 
    }
	
	public void ChoixMenu() {
        ClearCanvas();
        CanvasChoix.enabled = true;
    }

    public void ChangerEngin(string nomEngin) {
        GameObject gameObject = GameObject.Find(nomEngin);
        if (gameObject != null) {
            EnginDeSiege enginDeSiege = gameObject.GetComponent<EnginDeSiege>();
            if (enginDeSiege != null) {
                enginDeSiegeController.enginDeSiege = enginDeSiege;
            } else {
                Debug.LogError("Ce " + nomEngin + " n'a pas de composant EnginDeSiege.");
            }
        } else {
            Debug.LogError("Il n'y a pas de \"" + nomEngin + "\" dans la scène!");
        }
    }

}
