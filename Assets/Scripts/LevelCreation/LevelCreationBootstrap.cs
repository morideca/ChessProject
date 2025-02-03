using System.Collections.Generic;
using UnityEngine;

public class LevelCreationBootstrap : MonoBehaviour
{
    [SerializeField] 
    private GameObject cellPrefab;
    [SerializeField] 
    private Transform cellPosition;
    [SerializeField] 
    private int deskSize; 
    [SerializeField] 
    private Transform deskParent;
    [SerializeField] 
    private FigureConfigsData configData;
    [SerializeField] 
    private DeskView deskView;
    [SerializeField]
    private ClickHandler clickHandler;
    
    [SerializeField]
    private FormationUIView formationUIView;
    private FormationUIModel formationUIModel;
    private FormationUIPresenter formationUIPresenter;

    private DeskPresenter deskPresenter;
    private DeskModel deskModel;
    
    private DeskCreator deskCreator;
    private IFactory factory;
    private FigureLoad figureLoad;
    [SerializeField]
    private FigureDrag figureDrag;
    private FormationSave formationSave;

    private void Awake()
    {
        LoadDesk(out List<CellInstance> deskCell);
        InitFabric();
        InitUI(deskCell);
        LoadFigures();
    }

    private void LoadDesk(out List<CellInstance> deskCells)
    {
        deskCreator = new(cellPosition.position, cellPrefab, deskSize, deskParent, deskView); 
        deskCells = deskCreator.CreateDesk();
        formationSave = new(deskCells);
        deskModel = new(figureDrag);
        deskPresenter = new(deskModel, deskView);
    }

    private void InitFabric()
    { 
        factory = new FigureFactory(configData);
    }

    private void InitUI(List<CellInstance> deskCells)
    {
        formationUIModel = new(factory, deskCells, formationSave, false);
        formationUIPresenter = new(formationUIView, formationUIModel);
        figureDrag.FormationInit(formationUIModel);
    }

    private void LoadFigures()
    {
        figureLoad = new(formationSave, factory, deskCreator.DeskCells);
        figureLoad.LoadFigures(false, false);
    }
}
