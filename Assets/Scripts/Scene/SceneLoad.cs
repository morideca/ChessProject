using System;
using UnityEngine.SceneManagement;

public enum SceneType
{
    mainMenu,
    battle,
    formation,
    levelCreate
}

public class SceneLoad
{
    public void LoadScene(SceneType scene)
    {
        switch(scene)
        {
            case SceneType.mainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case SceneType.battle:
                SceneManager.LoadScene("BattleScene");
                break;
            case SceneType.formation:
                SceneManager.LoadScene("FormationScene");
                break;
            case SceneType.levelCreate:
                SceneManager.LoadScene("LevelCreate");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(scene), scene, null);
        }
    }
}
