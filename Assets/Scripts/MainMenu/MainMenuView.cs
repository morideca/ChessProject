using System;
using UnityEngine;
using UnityEngine.UI;

public enum MainMenuButtons
{
    startBattle,
    startFormation,
    exit
}
public class MainMenuView : MonoBehaviour
{
    public event Action<MainMenuButtons> OnButtonClicked;
    
    [SerializeField]
    private Button startBattle;
    [SerializeField]
    private Button startFormation;
    [SerializeField]
    private Button exit;

    private void Awake()
    {
        startBattle.onClick.AddListener(StartBattle);
        startFormation.onClick.AddListener(StarteFormation);
        exit.onClick.AddListener(Exit);
    }

    private void StartBattle()
    {
        OnButtonClicked?.Invoke(MainMenuButtons.startBattle);
    }
    private void StarteFormation()
    {
        OnButtonClicked?.Invoke(MainMenuButtons.startFormation);
    }
    private void Exit()
    {
        OnButtonClicked?.Invoke(MainMenuButtons.exit);
    }
    
}
