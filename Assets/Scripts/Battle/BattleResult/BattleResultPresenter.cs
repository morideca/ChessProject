using UnityEngine;

public class BattleResultPresenter
{
    private readonly BattleResultView view;
    private readonly BattleResultModel model;
    
    public BattleResultPresenter(BattleResultView view, BattleResultModel model)
    {
        this.view = view;
        this.model = model;
        Init();
    }

    private void Init()
    {
        model.OnWin += (bool isWhite) => view.OnWin(isWhite);
        view.OnMainMenuButtonClicked += () => model.ReturnMainMenu();
    }
}
