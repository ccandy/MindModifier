using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public List<LevelController> LevelList;
    private LevelController _currentLevel;

    void Start()
    {
        
    }

    public float CurrentLoadingProgress()
    {
        return _currentLevel.LoadingProgress;
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentLevel != null && _currentLevel.FinishLoading)
        {
            _currentLevel.OnLevelUpdate();
        }
    }

    public void LoadLevel(int index, UnityAction callback)
    {
        if(index >= LevelList.Count)
        {
            return;
        }

        LevelController l = LevelList[index];
        LevelController levelIns = Instantiate(l);
        _currentLevel = levelIns;
        _currentLevel.LoadLevelData(callback);
    }
}
