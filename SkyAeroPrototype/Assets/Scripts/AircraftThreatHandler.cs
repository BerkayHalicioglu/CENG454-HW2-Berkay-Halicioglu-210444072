using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioClip hitClip;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            Debug.Log("BOOM! Uçak vuruldu, başa dönülüyor!");
            
            Destroy(other.gameObject);

            if (hitClip != null)
            {
                AudioSource.PlayClipAtPoint(hitClip, transform.position);
            }

            if (examManager != null)
            {
                examManager.PlayerHitByMissile();
            }

            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;

                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }

            GameObject[] activeMissiles = GameObject.FindGameObjectsWithTag("Missile");
            foreach (GameObject missile in activeMissiles)
            {
                Destroy(missile);
            }
        }
    }
}