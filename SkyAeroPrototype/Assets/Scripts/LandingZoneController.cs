// LandingZoneController.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Berkay Halicioglu | Student ID: 210444072
using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LandingArea"))
        {
            examManager.TryLand();
        }
    }
}
