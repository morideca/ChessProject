public class MainMenuPresenter
{
    private MainMenuView view;
    private MainMenuModel model;
    
    public MainMenuPresenter(MainMenuView view, MainMenuModel model)
    {
        this.model = model;
        this.view = view;
        view.OnButtonClicked += OnButtonClicked;
    }

    private void OnButtonClicked(MainMenuButtons button)
    {
        model.OnButtonClicked(button);
    }
}
