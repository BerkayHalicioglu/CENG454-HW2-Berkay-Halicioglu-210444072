//MissileLauncher.cs
// CENG 454 - HW2 Midterm: Sky-High Prototype II 
// Author: Berkay Halicioglu | Student ID: 210444072
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioClip launchClip;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        if (activeMissile == null) 
        {
            activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

            MissileHoming homingScript = activeMissile.GetComponent<MissileHoming>();
            if (homingScript != null)
            {
                homingScript.SetTarget(target);
            }

            if (launchClip != null)
            {
                AudioSource.PlayClipAtPoint(launchClip, launchPoint.position);
            }
        }
        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}