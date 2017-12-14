using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderForceVent : MonoBehaviour {

    [SerializeField]
    [Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
    private string formatText = "{0}km/h";

    private Text txtForce;

    public Slider slider;

    private void Start()
    {
        txtForce = GetComponent<Text>();

        slider.onValueChanged.AddListener(HandleValueChanged);
    }

    private void HandleValueChanged(float value)
    {
        txtForce.text = string.Format(formatText, value);
    }
}
