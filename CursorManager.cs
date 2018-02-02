using UnityEngine;

/// <summary>
/// Made by Koen Sparreboom
/// </summary>
public class CursorManager : MonoBehaviour {

    [SerializeField]
    private CursorLockMode lockMode;
    public CursorLockMode LockMode {
        get {
            return lockMode;
        }
        set {
            lockMode = value;
            UpdateLockState();
        }
    }

    private void Start() {
        EventManager.StartListening("OnPauseChange", OnPauseChange);

        UpdateLockState();
    }

    private void OnPauseChange() {
        if (Pause.Paused) {
            lockMode = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            lockMode = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        UpdateLockState();
    }

    private void UpdateLockState() {
        Cursor.lockState = lockMode;
    }
}
