using System;
using UnityEngine;
using UnityEngine.UI;

public enum MainMenuButtons
{
    startBattle,
    startFormation,
    exit,
    levelCreate
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
    [SerializeField] 
    private Button LevelCreate;

    private void Awake()
    {
        startBattle.onClick.AddListener(StartBattle);
        startFormation.onClick.AddListener(StarteFormation);
        exit.onClick.AddListener(Exit);
        LevelCreate.onClick.AddListener(StartLevelCreate);
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

    private void StartLevelCreate()
    {
        OnButtonClicked?.Invoke(MainMenuButtons.levelCreate);
    }
}
