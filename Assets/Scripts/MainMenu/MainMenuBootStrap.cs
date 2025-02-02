using System;
using UnityEngine;

public class MainMenuBootStrap : MonoBehaviour
{
    [SerializeField]
    private MainMenuView mainMenuView;
    private void Awake()
    {
        var serviceLocator = ServiceLocator.GetInstance();
        MainMenuModel mainMenuModel = new(serviceLocator.SceneStateMachine);
        MainMenuPresenter mainMenuPresenter = new(mainMenuView, mainMenuModel);
    }
}
