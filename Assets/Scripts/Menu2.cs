using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu2 : MonoBehaviour
{

    public Canvas CanvasMenu;
    public Canvas CanvasOptions;
    public Canvas CanvasCredits;
    public Slider SliderMusique;
    public AudioSource VolumeMusique;

    void Update() {
        //Rotate dans l'axe des Y
        transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }

    void Awake()
    {
        CanvasOptions.enabled = false;
        CanvasCredits.enabled = false;
    }

    public void OptionsMenu()
    {
        CanvasOptions.enabled = true;
        CanvasMenu.enabled = false;
        CanvasCredits.enabled = false;
    }

    public void RetourMenu()
    {
        CanvasOptions.enabled = false;
        CanvasCredits.enabled = false;
        CanvasMenu.enabled = true;
    }

    public void CreditsMenu()
    {
        CanvasCredits.enabled = true;
        CanvasOptions.enabled = false;
        CanvasMenu.enabled = false;
    }

    public void Quitter()
    {
        Application.Quit();
    }


    public void LoadSimul()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadCible()
    {
        SceneManager.LoadScene(2);
    }

    public void ControleVolume()
    {
        VolumeMusique.volume = SliderMusique.value;
    }
}