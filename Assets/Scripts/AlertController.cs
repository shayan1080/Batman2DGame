using UnityEngine;

/// <summary>
/// مدیریت نورهای چشمک زن و آژیر Alert
/// </summary>
public class AlertController : MonoBehaviour
{
    public CharacterStateManager stateManager; // مرجع StateManager
    public GameObject[] alertLights;           // نورهای قرمز/آبی
    public AudioSource alarmAudio;             // صدای آژیر
    public AudioSource batmanAmbientAudio;
    public AudioSource batmobileAmbientAudio;
    public float flashInterval = 0.3f;

    private float timer = 0f;
    private bool lightsOn = false;

    void Update()
    {
        GameObject activeChar = stateManager.switchManager.currentCharacter;

        if(stateManager.currentState == BatmanState.Alert)
        {
            FlashLights();
            if(!alarmAudio.isPlaying) alarmAudio.Play();

            // Stop ambient sounds during Alert
            batmanAmbientAudio.Pause();
            batmobileAmbientAudio.Pause();
        }
        else
        {
            TurnOffLights();
            if(alarmAudio.isPlaying) alarmAudio.Stop();

            // Stop all ambient sounds first
            batmanAmbientAudio.Pause();
            batmobileAmbientAudio.Pause();

            // Play ambient sound of active character
            if(activeChar != null)
            {
                if(activeChar.name.Contains("Batman"))
                    batmanAmbientAudio.Play();
                else if(activeChar.name.Contains("Batmobile"))
                    batmobileAmbientAudio.Play();
            }
        }
    }




    void FlashLights()
    {
        timer += Time.deltaTime;
        if(timer >= flashInterval)
        {
            lightsOn = !lightsOn;
            foreach(GameObject light in alertLights)
                light.SetActive(lightsOn);
            timer = 0f;
        }
    }

    void TurnOffLights()
    {
        foreach(GameObject light in alertLights)
            light.SetActive(false);
        timer = 0f;
        lightsOn = false;
    }
}
