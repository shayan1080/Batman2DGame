using UnityEngine;

/// <summary>
/// Central state manager for the active character (Batman or Batmobile).
/// Handles movement speed based on state and Stealth overlay effect.
/// </summary>
public class CharacterStateManager : MonoBehaviour
{
    [Header("Movement Reference")]
    public CharacterSwitchManager switchManager; // مرجع SwitchManager

    [Header("Speed Settings")]
    public float normalSpeed = 3f;
    public float stealthSpeed = 1.5f;
    public float alertSpeed = 3f;

    [Header("Current State")]
    public BatmanState currentState = BatmanState.Normal;

    [Header("Stealth Overlay")]
    public SpriteRenderer stealthOverlay; // Overlay دایره سفید/مشکی
    public float stealthAlpha = 0.3f;    // کم نور شدن در Stealth
    public float fadeSpeed = 3f;         // سرعت محو/پدید شدن

    void Update()
    {
        HandleStateInput();
        ApplyStateToActiveCharacter();
        UpdateOverlay(); // اضافه شد برای Stealth
    }

    void HandleStateInput()
    {
        if (Input.GetKeyDown(KeyCode.N))
            currentState = BatmanState.Normal;

        if (Input.GetKeyDown(KeyCode.C))
            currentState = BatmanState.Stealth;

        if (Input.GetKeyDown(KeyCode.Space))
            currentState = BatmanState.Alert;
    }

    void ApplyStateToActiveCharacter()
    {
        if (switchManager == null) return;
        GameObject activeChar = switchManager.currentCharacter;
        if (activeChar == null) return;

        CharacterMovement2D movement = activeChar.GetComponent<CharacterMovement2D>();
        if (movement == null) return;

        switch(currentState)
        {
            case BatmanState.Normal:
                movement.normalSpeed = normalSpeed;
                break;

            case BatmanState.Stealth:
                movement.normalSpeed = stealthSpeed;
                break;

            case BatmanState.Alert:
                movement.normalSpeed = alertSpeed;
                break;
        }
    }

    void UpdateOverlay()
    {
        if (stealthOverlay == null) return;

        float targetAlpha = (currentState == BatmanState.Stealth) ? stealthAlpha : 0f;

        Color color = stealthOverlay.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * fadeSpeed);
        stealthOverlay.color = color;
    }
}
