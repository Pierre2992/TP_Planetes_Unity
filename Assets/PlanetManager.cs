using UnityEngine;
using System;
public class PlanetManager : MonoBehaviour
{
    public static PlanetManager current;
    public event Action<DateTime> OnTimeChange;
    public void TimeChanged(DateTime newTime) => OnTimeChange?.Invoke(newTime);

    [SerializeField]
    private UDateTime date;
    public UDateTime Date
    {
        get => date;
        set
        {
            date = value;
            TimeChanged(value.dateTime); //Fire the event
        }
    }
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }
}  


