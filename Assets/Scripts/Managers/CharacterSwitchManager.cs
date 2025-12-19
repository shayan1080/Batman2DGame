using UnityEngine;

/// <summary>
/// مدیریت سوییچ بین Batman و Batmobile.
/// با فشردن کلید P، کاراکتر فعال تغییر می‌کند.
/// در هر لحظه فقط یکی فعال است.
/// </summary>
public class CharacterSwitchManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject batman;
    public GameObject batmobile;

    public GameObject currentCharacter;

    void Start()
    {
        // شروع بازی با Batman
        ActivateBatman();
    }

    void Update()
    {
        HandleCharacterSwitch();
    }

    /// <summary>
    /// سوییچ کاراکتر با کلید P
    /// </summary>
    void HandleCharacterSwitch()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        if (currentCharacter == batman)
        {
            ActivateBatmobile();
        }
        else
        {
            ActivateBatman();
        }
    }

    void ActivateBatman()
    {
        batman.SetActive(true);
        batmobile.SetActive(false);
        currentCharacter = batman;
    }

    void ActivateBatmobile()
    {
        batman.SetActive(false);
        batmobile.SetActive(true);
        currentCharacter = batmobile;
    }
}

public enum BatmanState
{
    Normal,
    Stealth,
    Alert
}