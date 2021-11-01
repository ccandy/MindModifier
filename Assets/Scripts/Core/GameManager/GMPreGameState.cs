using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMPreGameState : GManagerBaseState
{
    public override void EnterState(GameManager GM)
    {
        //UIManager.Instance.LoadMainMenu();
        GM.UiMangaer.LoadMainMenu();
        MessageSystem.Instance.StartListening("StartButtonClick", StartButtonClick);
        MessageSystem.Instance.StartListening("EndButtonClick", EndButtonClick);
    }

    public override void ExitState(GameManager GM)
    {
        //MessageSystem.StopListening("StartButtonClick", StartButtonClick);
    }

    public override void OnUpdate(GameManager GM)
    {
        
    }

    private void StartButtonClick()
    {
        MessageSystem.Instance.StopListening("StartButtonClick", StartButtonClick);

        GameManager.Instance.TranslateToState(GameManager.Instance.LoadingGameState);
        
    }

    private void EndButtonClick()
    {
        Application.Quit();
    }


}
