using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleResultModel
{
    public event Action<bool> OnWin;
    
    private readonly List<GameObject> blackFigures;
    private readonly List<GameObject> whiteFigures;
    
    public BattleResultModel(List<GameObject> blackFigures, List<GameObject> whiteFigures)
    {
        this.blackFigures = blackFigures;
        this.whiteFigures = whiteFigures;
        Init();
    }

    public void ReturnMainMenu()
    {
        ServiceLocator.GetInstance().SceneStateMachine.ChangeState(SceneType.mainMenu);
    }

    private void Init()
    {
        foreach (var figure in blackFigures)
        {
            figure.GetComponent<FigureBattleInstance>().OnDeath += OnFigureDeath;
        }

        foreach (var figure in whiteFigures)
        {
            figure.GetComponent<FigureBattleInstance>().OnDeath += OnFigureDeath;
        }
    }

    private void OnFigureDeath(bool isWhite, FigureBattleInstance instance)
    {
        instance.OnDeath -= OnFigureDeath;
        if (isWhite)
        {
            whiteFigures.Remove(instance.gameObject);
        }
        else
        {
            blackFigures.Remove(instance.gameObject);
        }
        OnDeathCheck(isWhite);
    }
    private void OnDeathCheck(bool isWhite)
    {
        if (isWhite)
        {
            if (whiteFigures.Count > 0)
            {
                return;
            }
        }
        else
        {
            if (blackFigures.Count > 0)
            {
                return;
            }
        }
        Time.timeScale = 0;
        OnWin?.Invoke(!isWhite);
    }
}
