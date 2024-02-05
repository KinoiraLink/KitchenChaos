using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePausedUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButtom;



    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() => { Loader.Load(Loader.Scene.MainMenuScene); });
        resumeButton.onClick.AddListener(() => {KitchenGameManager.Instance.TogglePauseGame(); });
        optionsButtom.onClick.AddListener(() => {
            Hide();
            OptionsUI.Instance.Show(Show); 
        });


    }

    private void Start()
    {
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnPaused += KitchenGameManager_OnGameUnPaused;
        Hide();
    }



    private void KitchenGameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        resumeButton.Select();
        Show();
    }

    private void KitchenGameManager_OnGameUnPaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        resumeButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
