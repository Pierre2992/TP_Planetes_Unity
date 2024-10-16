using UnityEngine;
using UnityEngine.UI;
using System;

public class ToggleController : MonoBehaviour
{
    public Toggle Realiste, Adapte; // Assurez-vous que les Toggles sont liés dans l'éditeur Unity

    public GameObject Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune;
    void Start()
    {
        Adapte.SetIsOnWithoutNotify(true);
        Realiste.SetIsOnWithoutNotify(false);

        ToggleGroup toggleGroup = Realiste.GetComponentInParent<ToggleGroup>();
        if (toggleGroup != null)
        {
            toggleGroup.allowSwitchOff = true;
        }

        Realiste.onValueChanged.AddListener(delegate { OnRealisteToggleValueChanged(); });
        Adapte.onValueChanged.AddListener(delegate { OnAdapteToggleValueChanged(); });
    }

     public void ScalePlanetsRealiste()
    {
        Mercury.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Venus.transform.localScale = new Vector3(0.248f, 0.248f, 0.248f);
        Earth.transform.localScale = new Vector3(0.261f, 0.261f, 0.261f);
        Mars.transform.localScale = new Vector3(0.139f, 0.139f, 0.139f);
        Jupiter.transform.localScale = new Vector3(2.865f, 2.865f, 2.865f);
        Saturn.transform.localScale = new Vector3(2.387f, 2.387f, 2.387f);
        Uranus.transform.localScale = new Vector3(1.039f, 1.039f, 1.039f);
        Neptune.transform.localScale = new Vector3(1.009f, 1.009f, 1.009f);
    }

    public void ScalePlanetsAdapte()
    {
        Mercury.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Venus.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Earth.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Mars.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Jupiter.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Saturn.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Uranus.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Neptune.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }

    void Update()
    {
        if (Realiste.isOn)
        {
            ScalePlanetsRealiste();
        }
        else if (Adapte.isOn)
        {
            ScalePlanetsAdapte();
        }
    }

    private void OnRealisteToggleValueChanged()
    {
        if (Realiste.isOn)
        {
            ScalePlanetsRealiste();
        }
        else if (!Adapte.isOn)
        {
            ScalePlanetsAdapte();
        }
    }

     private void OnAdapteToggleValueChanged()
    {
        if (Adapte.isOn)
        {
            ScalePlanetsAdapte();
        }
        else if (!Realiste.isOn)
        {
            ScalePlanetsAdapte();
        }
    }
}

