using System.Collections.Generic;

public class ServiceLocator
{
    private static ServiceLocator serviceLocator;

    public FormationData FormationData = new();
    public Dictionary<int, FigureType> Formation;
    public SceneStateMachine SceneStateMachine;
    
    public static ServiceLocator GetInstance()
    {
        if (serviceLocator == null)
        {
            serviceLocator = new ServiceLocator();
        }
        return serviceLocator;
    }
}
