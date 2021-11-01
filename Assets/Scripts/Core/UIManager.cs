using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager:MonoBehaviour
{
    public GameObject MainMenuPrefab;
    public GameObject MainGameUIPrefab;
    public GameObject LoadingUIPrefab;

    private GameObject _loadUI;
    public void LoadMainMenu()
    {
        if(MainMenuPrefab == null)
        {
            return;
        }

        GameObject mainMenu = Instantiate(MainMenuPrefab);
    }

    public void LoadMainGameUI()
    {
        if (MainGameUIPrefab == null)
        {
            return;
        }

        GameObject mainMenu = Instantiate(MainGameUIPrefab);
    }

    public GameObject LoadLoadingUI()
    {
        Debug.Log("load loading ui");
        if(LoadingUIPrefab == null)
        {
            return null;
        }
        _loadUI = Instantiate(LoadingUIPrefab);

        return _loadUI;
    }

    public void RemoveLoadingUI()
    {
        if(_loadUI != null)
        {
            Destroy(_loadUI);
        }
    }

    void Start()
    {
        //LoadMainMenu();
    }

    
}
