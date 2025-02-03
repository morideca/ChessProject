using UnityEngine;

public class FigureDrag : MonoBehaviour
{
    private FormationUIModel formationUIModel;
    
    private Camera mainCamera;
    private LayerMask layerMask;
    private const float fixedHeight = 2f;

    private bool dragging = false;
    
    private IDragged draggedFigure;
    private IDragged newDraggedFigure;

    private void Start()
    {
        mainCamera = Camera.main;
        layerMask = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        if (dragging)
        {
            DragFigureUpdate();
        }
    }

    public void FormationInit(FormationUIModel formationUIModel)
    {
        this.formationUIModel = formationUIModel;
        formationUIModel.OnSoldFigure += OnSoldFigure;
    }

    private void OnSoldFigure()
    {
        if (draggedFigure != null)
        {
            Destroy(draggedFigure.GameObject);
            draggedFigure = null;
            SwitchDragging();
        }
    }
    
    public void DragFigure(CellInstance cellInstance)
    {
        if (cellInstance.FigureGO != null)
        {
            var figure = cellInstance.FigureGO;
            newDraggedFigure = figure.GetComponent<IDragged>();
            if (draggedFigure != null)
            {
                ReleaseFigure(cellInstance);
            }
            else
            {
                cellInstance.SetFigure(true, null);
            }
            draggedFigure = newDraggedFigure;
            newDraggedFigure = null;
            draggedFigure.SwitchDragging();
            SwitchDragging();
        }
    }

    public void ReleaseFigure(CellInstance cellInstance)
    {
        if (draggedFigure != null)
        {
            draggedFigure.SwitchDragging();
            PutFigure(cellInstance);
            draggedFigure = null;
            SwitchDragging();
        }
    }
    
    private void PutFigure(CellInstance cellInstance)
    {
        var mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask))
        {
            draggedFigure.GameObject.transform.position = hit.transform.position;
            bool isWhite = draggedFigure.GameObject.GetComponent<FigureFormationInstance>().IsWhite;
            cellInstance.SetFigure(isWhite, draggedFigure.GameObject);
        }
    }

    private void SwitchDragging()
    {
        dragging = !dragging;
    }
    
    private void DragFigureUpdate()
    {
        var mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, layerMask))
        {
            draggedFigure.GameObject.transform.position = new Vector3(hit.point.x, fixedHeight, hit.point.z);
        }
    }
}
