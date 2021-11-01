using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMLoadingGameState : GManagerBaseState
{

    GameManager _gM;
    LoadingUI _loadingUI;
    bool _startLoadingLevel;
    public override void EnterState(GameManager GM)
    {
        _gM = GM;
        SceneManager.sceneLoaded += OnSceneLoaded;
        GameManager.Instance.LoadScene("GameScene");

        
        
    }

    public override void ExitState(GameManager GM)
    {
        
    }

    public override void OnUpdate(GameManager GM)
    {
        if (_startLoadingLevel)
        {
            float progress = _gM.Levelmanager.CurrentLoadingProgress();

            
            _loadingUI.TxtLoadingProgress.text = "" + progress;
        }

            
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject gb = _gM.UiMangaer.LoadLoadingUI();
        _loadingUI = gb.GetComponent<LoadingUI>();
        _gM.Levelmanager.LoadLevel(0, FinishLoading);
        _startLoadingLevel = true;

    }

    private void FinishLoading()
    {
        _gM.UiMangaer.RemoveLoadingUI();
        _gM.TranslateToState(_gM.MainGameState);
    }
}
