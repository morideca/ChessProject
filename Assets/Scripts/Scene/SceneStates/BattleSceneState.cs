public class BattleSceneState : IState
{
    private SceneLoad sceneLoad;
    
    public BattleSceneState(SceneLoad sceneLoad)
    {
        this.sceneLoad = sceneLoad;
    }
    
    public void Enter()
    {
        sceneLoad.LoadScene(SceneType.battle);
    }

    public void Exit()
    {
    
    }
}
