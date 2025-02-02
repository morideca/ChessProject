using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BattleBootStrap : MonoBehaviour
{
    [SerializeField] 
    private GameObject cellPrefab;
    [SerializeField] 
    private Transform cellPosition;
    [SerializeField] 
    private int deskSize;
    [SerializeField] 
    private Transform deskTransform;
    [SerializeField] 
    private FigureConfigsData configData;
    [SerializeField] 
    private GameObject healthBarPrefab;
    [SerializeField] 
    private BattleResultView battleResulView;

    private Dictionary<int, FigureType> whiteFigures = new();
    private Dictionary<int, FigureType> blackFigures = new();
        
    private DeskCreator deskCreator;
    private NavMeshSurface navmesh;
    private IFactory factory;
    private FigureLoad figureLoad;
    private FormationSave formationSave;
    private BattleResultModel battleResultModel;
    private BattleResultPresenter battleResultPresenter;

    private void Awake()
    {
        // blackFigures.Add(63, FigureType.pawn);
        // blackFigures.Add(62, FigureType.pawn);
        blackFigures.Add(61, FigureType.pawn);
        
        LoadDesk();
 
        navmesh = GetComponent<NavMeshSurface>();
        navmesh.BuildNavMesh();
        InitFabric();
        LoadFigures();
        InitBattleResult();
    }

    private void LoadDesk()
    {
        deskCreator = new(cellPosition.position, cellPrefab, deskSize, deskTransform); 
        var deskCells = deskCreator.CreateDesk();
        formationSave = new(deskCells);
    }

    private void InitFabric()
    { 
        factory = new FigureFactory(configData, healthBarPrefab);
    }

    private void InitBattleResult()
    {
        battleResultModel = new(factory.BlackFigures, factory.WhiteFigures);
        battleResultPresenter = new(battleResulView, battleResultModel);
    }

    private void LoadFigures()
    {
        figureLoad = new(formationSave, factory, deskCreator.DeskCells, blackFigures);
        figureLoad.LoadFigures(true);
    }
   
}
   
