using UnityEngine;

public class MobileInputManager : MonoBehaviour
{
    public static MobileInputManager Instance;

    private bool leftPressed, rightPressed, gasPressed, brakePressed;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsBraking => brakePressed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        Horizontal = 0f;
        if (leftPressed) Horizontal -= 1f;
        if (rightPressed) Horizontal += 1f;

        Vertical = gasPressed ? 1f : 0f;
    }

    // Dipanggil dari tombol UI via Event Trigger
    public void PressLeft() => leftPressed = true;
    public void ReleaseLeft() => leftPressed = false;
    public void PressRight() => rightPressed = true;
    public void ReleaseRight() => rightPressed = false;
    public void PressGas() => gasPressed = true;
    public void ReleaseGas() => gasPressed = false;
    public void PressBrake() => brakePressed = true;
    public void ReleaseBrake() => brakePressed = false;
}