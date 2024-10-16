using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SolarSystemController : MonoBehaviour
{

    void UpdatePosition(DateTime t)
    {
        foreach (PlanetData.Planet p in Enum.GetValues(typeof(PlanetData.Planet)))
        {
            GameObject planetObject = GameObject.Find(p.ToString()); 
            if (planetObject != null)
            {
                Vector3 v = PlanetData.GetPlanetPosition(p, t);
                planetObject.transform.position = v;
            }
        }
    }

   

    void Start()
    {
        UpdatePosition(DateTime.Now);
        PlanetManager.current.OnTimeChange += UpdatePosition;
    }
}