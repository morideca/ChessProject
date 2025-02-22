using UnityEngine;

public class MainMenuSceneState : IState
{
    private readonly SceneLoad sceneLoad;
    
    public MainMenuSceneState(SceneLoad sceneLoad)
    {
        this.sceneLoad = sceneLoad;
    }
    
    public void Enter()
    {
        sceneLoad.LoadScene(SceneType.mainMenu);
        Time.timeScale = 1; 
    }

    public void Exit()
    {

    }
}
