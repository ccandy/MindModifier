using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public abstract class LevelController:MonoBehaviour
{
    //public Transform SwapPoint;

    public abstract void LevelInit();

    public List<LevelCondition> WinningConditionList;
    public List<LevelCondition> LoseConditionList;

    //public LevelDataSo LevelData;

    public GameObject TilePrefab;

    public float LoadingProgress;

    public bool FinishLoading;

    public void LoadLevelData(UnityAction callback)
    {
        StartCoroutine(LoadLevel(callback));
    }


    IEnumerator LoadLevel(UnityAction callback)
    {
        /*
        FinishLoading = false;
        List<Vector3> _tiles = LevelData.TliesObjs;
        LoadingProgress = 0;
        for(int n = 0; n < _tiles.Count; n++)
        {
            Vector3 p = _tiles[n];
            Instantiate(TilePrefab, p, Quaternion.identity);

            LoadingProgress = ((float)n / _tiles.Count) * 100;
            yield return new WaitForEndOfFrame();
        }

        LevelInit();
        FinishLoading = true;
        callback.Invoke();*/

        yield return new WaitForEndOfFrame();
    }

    
    public void OnLevelUpdate()
    {
        
        for(int n = 0; n < LoseConditionList.Count; n++)
        {
            LevelCondition lc = LoseConditionList[n];
            if (lc.ReachCondition())
            {
                MessageSystem.Instance.TriggerEvent("PlayerLose");
                return;
            }
        }

        bool playerWin = true;

        for(int n = 0; n < WinningConditionList.Count; n++)
        {
            LevelCondition lc = WinningConditionList[n];
            playerWin &= lc.ReachCondition();
        }

        if (playerWin)
        {
            MessageSystem.Instance.TriggerEvent("PlayerWin");
        }
    }
}
