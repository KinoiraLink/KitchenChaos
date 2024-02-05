using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;

    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button gamepadInteractButton;
    [SerializeField] private Button gamepadInteractAlternateButton;
    [SerializeField] private Button gamepadPauseButton;

    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    [SerializeField] private TextMeshProUGUI moveUpText;//MoveUpButtonText
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI gamepadInteractText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlternateText;
    [SerializeField] private TextMeshProUGUI gamepadPauseText;

    [SerializeField] private Transform pressToRebindKeyTransform;

    private Action onCloseButtonAction;
    public static OptionsUI Instance { get; private set; }

    private void Start()
    {
        KitchenGameManager.Instance.OnGameUnPaused += KitchenGameManager_OnGameUnpaused;
        UpdateVisual();
        HidePressToRebindKey();
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Awake()
    {
        Instance = this;

        soundEffectButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        musicButton.onClick.AddListener(() => {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() => {
            Hide();
            onCloseButtonAction();
        });


        moveUpButton.onClick.AddListener(() => { RebindBinding(Binding.Move_Up); });
        moveDownButton.onClick.AddListener(() => { RebindBinding(Binding.Move_Down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(Binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(Binding.Move_Right); });
        interactButton.onClick.AddListener(() => { RebindBinding(Binding.Interact); });
        interactAlternateButton.onClick.AddListener(() => { RebindBinding(Binding.InteractAlternate); });
        pauseButton.onClick.AddListener(() => { RebindBinding(Binding.Pause); });

        gamepadInteractButton.onClick.AddListener(() => { RebindBinding(Binding.Gamepad_Interact); });
        gamepadInteractAlternateButton.onClick.AddListener(() => { RebindBinding(Binding.Gamepad_InteractAlternate); });
        gamepadPauseButton.onClick.AddListener(() => { RebindBinding(Binding.Gamepad_Pause); });
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects:" + Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music:" + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveUpText.text = GameInput.Instance.GetBindingText(Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBindingText(Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBindingText(Binding.InteractAlternate);
        pauseText.text = GameInput.Instance.GetBindingText(Binding.Pause);

        gamepadInteractText.text = GameInput.Instance.GetBindingText(Binding.Gamepad_Interact);
        gamepadInteractAlternateText.text = GameInput.Instance.GetBindingText(Binding.Gamepad_InteractAlternate);
        gamepadPauseText.text = GameInput.Instance.GetBindingText(Binding.Gamepad_Pause);

    }

    public void Show(Action OnCloseButtonAction)
    {
        this.onCloseButtonAction = OnCloseButtonAction;
        gameObject.SetActive(true);
        soundEffectButton.Select();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyTransform.gameObject.SetActive(true);
    }
    private void HidePressToRebindKey()
    {
       pressToRebindKeyTransform.gameObject.SetActive(false);
    }

    private void RebindBinding(Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.RebindBinding(binding, () => {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
}
