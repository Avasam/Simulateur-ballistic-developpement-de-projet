using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public void menu_principal()
    {
        SceneManager.LoadScene(0); 
    }

    public void reset()
    {
        SceneManager.LoadScene(1);
    }
	
}
