public class FormationUIPresenter
{
    private FormationUIView view;
    private FormationUIModel model;

    public FormationUIPresenter(FormationUIView view, FormationUIModel model)
    {
        this.view = view;
        this.model = model;
        Init();
    }

    private void Init()
    {
        view.OnFigureButtonClicked += (FigureType type) => model.CreateFigure(type);
        view.OnFinishClicked += () => model.ReturnToMainMenu();
    }
}
