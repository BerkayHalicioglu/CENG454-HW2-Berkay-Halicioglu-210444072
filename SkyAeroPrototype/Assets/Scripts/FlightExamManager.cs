using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private AudioClip successClip;

    public bool hasTakenOff = false;
    public bool threatCleared = false;
    public bool missionComplete = false;
    public bool missileWasLaunched = false;
    private bool justCrashed = false;

    void Start()
    {
        statusText.text = "";
        missionText.text = "Mission: Take off and cross the Danger Zone!";
    }

    public void OnTakeOff()
    {
        if (!hasTakenOff)
        {
            hasTakenOff = true;
            missionText.text = "Mission: Enter the Danger Zone!";
        }
    }

    public void TryLand()
    {
        if (!hasTakenOff)
        {
            statusText.text = "You must take off first!";
            statusText.color = Color.yellow;
            Invoke("ClearStatusText", 2f);
            return;
        }

        if (!threatCleared)
        {
            statusText.text = "Clear the threat first!";
            statusText.color = Color.yellow;
            Invoke("ClearStatusText", 2f);
            return;
        }

        if (!missionComplete)
        {
            missionComplete = true;
            statusText.text = "Mission Complete! Safe landing!";
            statusText.color = Color.green;
            missionText.text = "Congratulations! Mission accomplished.";

            if (successClip != null)
            {
                AudioSource.PlayClipAtPoint(successClip, Camera.main.transform.position);
            }
        }
    }

    public void EnterDangerZone()
    {
        if (!threatCleared)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
            missionText.text = "Warning: Incoming missile threat! Escape the zone!";
        }
    }

    public void OnMissileLaunched()
    {
        missileWasLaunched = true;
    }

    public void ExitDangerZone()
    {
        if (justCrashed)
        {
            justCrashed = false;
            return;
        }

        if (missileWasLaunched)
        {
            threatCleared = true;
            missileWasLaunched = false;
            statusText.text = "Threat cleared! Proceed to landing.";
            statusText.color = Color.green;
            missionText.text = "Mission: Return and land safely.";
        }
        else
        {
            statusText.text = "You left too early! Re-enter the zone.";
            statusText.color = Color.yellow;
            missionText.text = "Mission: Enter the Danger Zone and face the threat!";
            Invoke("ClearStatusText", 2f);
        }
    }

    public void PlayerHitByMissile()
    {
        justCrashed = true;
        threatCleared = false;
        hasTakenOff = false;
        missionComplete = false;
        missileWasLaunched = false;

        statusText.text = "CRASHED: Mission Failed!";
        statusText.color = Color.red;
        
        missionText.text = "Mission: Take off and try again.";
        
        Invoke("ClearStatusText", 2f);
    }

    private void ClearStatusText()
    {
        statusText.text = "";
    }
}
