using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{
    public Slider timeScaleSlider; // L'objet Slider utilisé pour contrôler la vitesse du temps
    public float speed;
    void Start()
    {
        PlanetManager.current.Date = DateTime.Now;
        timeScaleSlider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
    }
    private void OnSliderValueChanged()
    {
        speed = timeScaleSlider.value;
    } 

    void Update()
    {
        PlanetManager.current.Date = PlanetManager.current.Date.GetDateTime().AddSeconds(Time.deltaTime*speed);
    }
}


