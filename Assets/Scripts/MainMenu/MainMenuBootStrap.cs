using System;
using UnityEngine;

public class MainMenuBootStrap : MonoBehaviour
{
    [SerializeField]
    private MainMenuView mainMenuView;

    private DataSave dataSave;
    private void Awake()
    {
        var serviceLocator = ServiceLocator.GetInstance();
        dataSave = new();
        MainMenuModel mainMenuModel = new(serviceLocator.SceneStateMachine, dataSave);
        MainMenuPresenter mainMenuPresenter = new(mainMenuView, mainMenuModel);
    }
}
