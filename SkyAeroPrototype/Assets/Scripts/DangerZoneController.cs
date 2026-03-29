using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        // YENİ RADARIMIZ: Küpe ne çarparsa çarpsın konsola yazdıracak!
        Debug.Log("DİKKAT! Kırmızı küpe bir şey girdi. Adı: " + other.gameObject.name + " | Etiketi (Tag): " + other.gameObject.tag);

        if (other.CompareTag("Player"))
        {
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
            //TODO: Aktif füzeyi yok etme kodunu Task 3'te buraya yazacağzı.
        }
    }
    
    private IEnumerator CountdownAndLaunch()
    {
        yield return new WaitForSeconds(missileDelay);

        Debug.Log("5 saniye doldu! Füze fırlatılıyor...");
        // TODO: Füze fırlatma komutunu Task 3'te buraya yazacağız.
    }     
}
