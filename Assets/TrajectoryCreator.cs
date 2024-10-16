using System;
using UnityEngine;
using UnityEngine.UI;

public class TrajectoryCreator : MonoBehaviour
{
    public int numberOfPoints = 100000; // Le nombre de points pour tracer la trajectoire
    public float timeInterval = 1.0f; // L'intervalle de temps entre chaque point
    public Material trajectoryMaterial; // Le matériau pour la trajectoire
    public Toggle trajectoryToggle; // Le bouton à bascule pour afficher ou masquer la trajectoire

    private GameObject[] trajectories; // Tableau pour stocker les objets de trajectoire
    public float lineWidth = 0.1f;
    void Start()
    {
        trajectoryToggle.SetIsOnWithoutNotify(true);
        // Créer des trajectoires pour toutes les planètes
        trajectories = new GameObject[Enum.GetValues(typeof(PlanetData.Planet)).Length];
        int index = 0;
        foreach (PlanetData.Planet p in Enum.GetValues(typeof(PlanetData.Planet)))
        {
            GameObject planetObject = GameObject.Find(p.ToString());
            if (planetObject != null)
            {
                GameObject trajectory = CreateTrajectory(planetObject, p);
                trajectories[index] = trajectory;
                index++;
            }
        }

        // Ajouter un écouteur pour suivre les modifications de l'état du bouton à bascule
        if (trajectoryToggle != null)
        {
            trajectoryToggle.onValueChanged.AddListener(delegate { ToggleTrajectories(); });
        }
        else
        {
            Debug.LogError("Toggle not assigned.");
        }
    }

    // Fonction pour créer une trajectoire pour une planète spécifique
    public GameObject CreateTrajectory(GameObject planet, PlanetData.Planet planetType)
    {
        DateTime startDate = new DateTime(2023, 1, 1);
        GameObject trajectory = new GameObject(planetType.ToString() + "Trajectory");
        trajectory.transform.SetParent(transform);

        LineRenderer lineRenderer = trajectory.AddComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
        lineRenderer.material = trajectoryMaterial;
        lineRenderer.startWidth = lineWidth; // Ajuster l'épaisseur de début de la trajectoire
        lineRenderer.endWidth = lineWidth; // Ajuster l'épaisseur de fin de la trajectoire

        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector3 planetPosition = PlanetData.GetPlanetPosition(planetType, startDate.AddDays(timeInterval*i)); // Utilisation de la méthode GetPlanetPosition
            lineRenderer.SetPosition(i, planetPosition);
        }

        return trajectory;
    }

    // Fonction pour activer ou désactiver les trajectoires en fonction de l'état du bouton à bascule
    public void ToggleTrajectories()
    {
        if (trajectories != null)
        {
            foreach (GameObject trajectory in trajectories)
            {
                if (trajectory != null)
                {
                    // Activer ou désactiver les trajectoires en fonction de l'état du bouton à bascule
                    trajectory.SetActive(trajectoryToggle.isOn);
                }
            }
        }
    }
}


