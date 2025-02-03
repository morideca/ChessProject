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
         blackFigures.Add(143, FigureType.pawn); 
         blackFigures.Add(142, FigureType.pawn);
         blackFigures.Add(141, FigureType.pawn);
         blackFigures.Add(140, FigureType.pawn);
         blackFigures.Add(139, FigureType.pawn);
         blackFigures.Add(138, FigureType.pawn);
         blackFigures.Add(137, FigureType.pawn);
         blackFigures.Add(136, FigureType.pawn);
         
        
        LoadDesk();
 
        navmesh = GetComponent<NavMeshSurface>();
        navmesh.BuildNavMesh();
        InitFabric();
        LoadFigures();
        InitBattleResult();
        
        TurnOffCursor();
    }

    private static void TurnOffCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        figureLoad = new(formationSave, factory, deskCreator.DeskCells);
        figureLoad.LoadFigures(true, true);
    }
   
}
   
