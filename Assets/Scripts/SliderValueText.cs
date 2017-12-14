using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class SliderValueText : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
    private string formatText = "{0}°";
    private GameObject myObject;
    private float rotation;
    private Text tmproText;
    public Slider slider;

    private void Start()
    {
        tmproText = GetComponent<Text>();
        myObject = GameObject.Find("boussole");
        slider.onValueChanged.AddListener(HandleValueChanged);
    }

    private void HandleValueChanged(float value)
    {
        tmproText.text = string.Format(formatText, value);
        rotation = slider.value;
        myObject.transform.localEulerAngles = new Vector3(0, 0, -rotation);
    }
}
