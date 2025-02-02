using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        var serviceLocator = ServiceLocator.GetInstance();
        SceneLoad sceneLoad = new();
        SceneStateMachine sceneStateMachine = new(sceneLoad);
        serviceLocator.SceneStateMachine = sceneStateMachine;
        sceneStateMachine.ChangeState(SceneType.mainMenu);
        DataSave dataSave = new();
        dataSave.LoadFormation();
    }
}
