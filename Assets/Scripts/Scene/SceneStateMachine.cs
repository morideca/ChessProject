using System;
using UnityEngine;

public enum SceneState
{
    mainMenu,
    battle,
    formation
}
public class SceneStateMachine : MonoBehaviour, IStateMachine
{
    private IState currentState;

    private readonly IState battleState;
    private readonly IState formationState;
    private readonly IState mainMenuState;
    private readonly IState levelCreateState;
    
    public SceneStateMachine(SceneLoad sceneLoad)
    {
        battleState = new BattleSceneState(sceneLoad);
        formationState = new FormationSceneState(sceneLoad);
        mainMenuState = new MainMenuSceneState(sceneLoad);
        levelCreateState = new LevelCreateState(sceneLoad);
    }

    public void ChangeState(SceneType sceneType)
    {
        IState newState;
        switch(sceneType)
        {
            case SceneType.mainMenu:
                newState = mainMenuState;
                break;
            case SceneType.battle:
                newState = battleState;
                break;
            case SceneType.formation:
                newState = formationState;
                break;
            case SceneType.levelCreate:
                newState = levelCreateState;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sceneType), sceneType, null);
        }

        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }
}
