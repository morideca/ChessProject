public class LevelCreateState : IState
{
    private SceneLoad sceneLoad;
    
    public LevelCreateState(SceneLoad sceneLoad)
    {
        this.sceneLoad = sceneLoad;
    }
    public void Enter()
    {
        sceneLoad.LoadScene(SceneType.levelCreate);
    }

    public void Exit()
    {
    
    }
}
