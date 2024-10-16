using UnityEngine;
using UnityEngine.UI;
using System;

public class TextController : MonoBehaviour
{
    public InputField dateInputField;

    private void Start()
    {
        // Abonnez-vous à la méthode de détection de la touche entrée
        dateInputField.onEndEdit.AddListener(OnDateEndEdit);
    }

    private void Update()
    {
        // Vérifiez si la touche entrée a été pressée
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnEnterKeyPressed();
        }
    }

    private void OnDateEndEdit(string inputDate)
    {
        DateTime parsedDate;
        if (DateTime.TryParse(inputDate, out parsedDate))
        {
            PlanetManager.current.Date = parsedDate;
        }
        else
        {
            Debug.Log("Format de date incorrect. Veuillez saisir une date au format valide.");
        }
    }

    private void OnEnterKeyPressed()
    {
        string inputDate = dateInputField.text;
        OnDateEndEdit(inputDate);
    }
}
