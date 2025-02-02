using System;
using UnityEngine.Device;

public class MainMenuModel
{
    private readonly SceneStateMachine sceneStateMachine;
    private readonly DataSave dataSave;
    
    public MainMenuModel(SceneStateMachine sceneStateMachine)
    {
        this.sceneStateMachine = sceneStateMachine;
    }

    public void OnButtonClicked(MainMenuButtons button)
    {
        switch (button)
        {
            case MainMenuButtons.startBattle:
                sceneStateMachine.ChangeState(SceneType.battle);
                break;
            case MainMenuButtons.startFormation:
                sceneStateMachine.ChangeState(SceneType.formation);
                break;
            case MainMenuButtons.exit:
                dataSave.SaveData();
                Application.Quit();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(button), button, null);
        }
    }
}
