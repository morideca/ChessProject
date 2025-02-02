public class DeskPresenter
{
    private DeskModel model;
    private DeskView view;

    public DeskPresenter(DeskModel model, DeskView view)
    {
        this.model = model;
        this.view = view;
        Init();
    }

    private void Init()
    {
        view.OnClicked += OnClicked;
    }

    private void OnClicked(CellInstance cellInstance)
    {
        model.OnCellClicked(cellInstance);
    }
}
