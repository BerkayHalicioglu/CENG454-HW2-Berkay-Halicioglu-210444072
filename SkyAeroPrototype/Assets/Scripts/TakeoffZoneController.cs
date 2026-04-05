// TakeoffZoneController.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II
// Author: Berkay Halicioglu | Student ID: 210444072
using UnityEngine;

public class TakeoffZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float takeoffAltitude = 10f;

    private Transform player;
    private float groundY;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            groundY = player.position.y;
            Debug.Log("TakeoffZone: groundY=" + groundY + " threshold=" + (groundY + takeoffAltitude));
        }
        else
        {
            Debug.LogWarning("TakeoffZone: Player bulunamadi!");
        }
    }

    void Update()
    {
        if (examManager.hasTakenOff) return;

        if (player != null && player.position.y > groundY + takeoffAltitude)
        {
            Debug.Log("OnTakeOff tetiklendi! playerY=" + player.position.y + " threshold=" + (groundY + takeoffAltitude));
            examManager.OnTakeOff();
        }
    }
}
