using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    public bool hasTakenOff = false;
    public bool threatCleared = false;
    public bool missionComplete = false;

    void Start() 
    {
        statusText.text = "";
        missionText.text = "Mission: Take off and cross the Danger Zone";
    }

    public void EnterDangerZone()
    {
        if (!threatCleared)
        {
            statusText.text = "Entered a Danger Zone! Clear the threat!";
            statusText.color = Color.red;
            missionText.text = "Warning: Incoming threat! Clear it to proceed.";
        }
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        statusText.text = "Threat cleared! You can proceed.";
        statusText.color = Color.green;
        missionText.text = "Mission: Return and land safely.";
    }
}
