using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutoriaUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadMoveText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }

    private void GameInput_OnBindingRebind(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsCountdownToStartActive())
        {
            Hide();
        }
    }

    private void UpdateVisual()
    {

        keyMoveUpText.text = GameInput.Instance.GetBindingText(Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBindingText(Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBindingText(Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBindingText(Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBindingText(Binding.Interact);
        keyInteractAlternateText.text = GameInput.Instance.GetBindingText(Binding.InteractAlternate);
        keyPauseText.text = GameInput.Instance.GetBindingText(Binding.Pause);
        keyGamepadInteractText.text = GameInput.Instance.GetBindingText(Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = GameInput.Instance.GetBindingText(Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = GameInput.Instance.GetBindingText(Binding.Gamepad_Pause);

    }


    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

    }

}