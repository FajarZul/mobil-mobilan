using UnityEngine;

public class MobileInputManager : MonoBehaviour
{
    public static MobileInputManager Instance;
    private bool leftPressed, rightPressed, gasPressed, reversePressed, respawnPressed;

    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }
    public bool IsReversing => reversePressed;
    public bool IsRespawning => respawnPressed;

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

        if (gasPressed)
            Vertical = 1f;
        else if (reversePressed)
            Vertical = -1f;
        else
            Vertical = 0f;
    }

    public void PressLeft() => leftPressed = true;
    public void ReleaseLeft() => leftPressed = false;
    public void PressRight() => rightPressed = true;
    public void ReleaseRight() => rightPressed = false;
    public void PressGas() => gasPressed = true;
    public void ReleaseGas() => gasPressed = false;
    public void PressReverse() => reversePressed = true;
    public void ReleaseReverse() => reversePressed = false;
    public void PressRespawn() => respawnPressed = true;
    public void ReleaseRespawn() => respawnPressed = false;
}