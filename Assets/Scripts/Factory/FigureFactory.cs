using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public enum FigureType
{
    none,
    bishop,
    king,
    queen,
    pawn,
    knight,
    rook
}

public class FigureFactory : IFactory
{
    private readonly FigureConfigsData configs;
    private readonly GameObject healthBarPrefab;

    public List<GameObject> WhiteFigures { get; private set; } = new();
    public List<GameObject> BlackFigures { get; private set; } = new();
    
    public FigureFactory(FigureConfigsData configs, DeskModel deskModel)
    {
        this.configs = configs;
    }
    
    public FigureFactory(FigureConfigsData configs, GameObject healthBarPrefab)
    {
        this.configs = configs;
        this.healthBarPrefab = healthBarPrefab;
    }

    public void CreateFigure(FigureType figureType, CellInstance cell, bool isWhite, bool isBattle)
    {
        if (figureType == FigureType.none) return;
        
        InstantiatePrefab(figureType, cell, isWhite, out FigureConfig config, out GameObject Figure);
        if (isBattle)
        {
            AddBattleInstance(figureType, isWhite, Figure, config);
            
        }
        else
        {
            AddFormationInstance(Figure, figureType);
        }
        cell.SetFigure(Figure);
    }

    private void InstantiatePrefab(FigureType figureType, CellInstance cellInstance, bool isWhite, out FigureConfig config, out GameObject chess)
    {
        config = configs.FigureConfigs.Find(x => x.FigureType == figureType);
        var prefab = isWhite ? config.WhiteFigurePrefab : config.BlackFigurePrefab;
        chess = Object.Instantiate(prefab, cellInstance.transform.position, Quaternion.identity);
    }

    private void AddBattleInstance(FigureType figureType, bool isWhite, GameObject chess, FigureConfig config)
    {
        var instance = chess.AddComponent<FigureBattleInstance>();
        if (isWhite)
        {
            WhiteFigures.Add(chess.gameObject);
            instance.Init(figureType, config, healthBarPrefab, BlackFigures, isWhite);
        }
        else
        {
            BlackFigures.Add(chess.gameObject);
            instance.Init(figureType, config, healthBarPrefab, WhiteFigures, isWhite);
        }
    }

    private void AddFormationInstance(GameObject chess, FigureType figureType)
    {
        var instance = chess.AddComponent<FigureFormationInstance>();
        instance.SetType(figureType);
    }
}
