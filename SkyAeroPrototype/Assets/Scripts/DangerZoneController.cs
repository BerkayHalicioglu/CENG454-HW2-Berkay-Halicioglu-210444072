using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private Transform playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            examManager.EnterDangerZone();
            activeCountdown = StartCoroutine(CountdownAndLaunch());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.ExitDangerZone();
            if (activeCountdown != null)            
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
            playerTransform = null;
        }
    }
    
    private IEnumerator CountdownAndLaunch()
    {
        yield return new WaitForSeconds(missileDelay);

        if (missileLauncher != null && playerTransform != null)
        {
            missileLauncher.Launch(playerTransform);
            examManager.OnMissileLaunched();
        }
    }     
}
