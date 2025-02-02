public class FormationSceneState : IState
{
    private SceneLoad sceneLoad;
    
    public FormationSceneState(SceneLoad sceneLoad)
    {
        this.sceneLoad = sceneLoad;
    }
    
    public void Enter()
    {
        sceneLoad.LoadScene(SceneType.formation);
    }
    
    public void Exit()
    {
     
    }
}
