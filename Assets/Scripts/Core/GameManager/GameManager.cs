using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public GMPreGameState PreGameState = new GMPreGameState();
    public GMMainGameState MainGameState = new GMMainGameState();
    public GMLoadingGameState LoadingGameState = new GMLoadingGameState();
    
    GManagerBaseState _currentState;

    private UIManager _uiManager;
    public UIManager UiMangaer
    {
        get
        {
            if(_uiManager != null)
            {
                return _uiManager;
            }
            Debug.LogError("UI Manager is null");
            return null;
        }
    }

    private LevelManager _levelManager;
    public LevelManager Levelmanager
    {
        get
        {
            if(_levelManager != null)
            {
                return _levelManager;
            }
            Debug.LogError("Level Manager is null");
            return null;
        }
    }


    private PlayerController _player;
    public PlayerController Player
    {
        set
        {
            _player = value;
        }
        get
        {
            return _player;
        }
    }
    
    void Start()
    {
        _uiManager = gameObject.GetComponentInChildren<UIManager>();
        _levelManager = gameObject.GetComponentInChildren<LevelManager>();

        TranslateToState(PreGameState);
        DontDestroyOnLoad(gameObject);
    }

    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        ao.completed += OnUnloadOperationComplete;
    }

    void OnLoadOperationComplete(AsyncOperation ao)
    {

    }


    void OnUnloadOperationComplete(AsyncOperation ao)
    {

    }


    public void TranslateToState(GManagerBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }

    private void Update()
    {
        if(_currentState != null)
        {
            _currentState.OnUpdate(this);
        }
    }
}
