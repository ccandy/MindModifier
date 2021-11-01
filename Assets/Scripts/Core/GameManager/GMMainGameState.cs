using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GMMainGameState : GManagerBaseState
{
    GameManager _gM;
    LevelManager _levelController;
    public override void EnterState(GameManager GM)
    {
        /*
        _gM = GM;
        SceneManager.sceneLoaded += OnSceneLoaded;
        GameManager.Instance.LoadScene("GameScene");*/
    }
    public override void ExitState(GameManager GM)
    {
        //SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public override void OnUpdate(GameManager GM)
    {
        
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        //_gM.TranslateToState(_gM.LoadingGameState);
        /*
        _gM.UiMangaer.LoadMainGameUI();
        _gM.Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (_gM.Player == null)
        {
            Debug.LogError("Player is null");
        }
        else
        {
            _gM.Player.PlayerInit();
        }
        //_gM.Levelmanager.LoadLevel(0);*/


    }
}
