using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class MessageSystem : MonoBehaviour 
{
    private static Dictionary<string, UnityEvent> _eventDic;
    private static Dictionary<string, UnityEvent<int>> _eventTDic;


    private static MessageSystem _eventManager;
    public static MessageSystem Instance
    {
        get
        {
            if(_eventManager == null)
            {
                Debug.LogError("something werid happened");
                return null;
            }

            return _eventManager;
        }
    }
    private void Awake()
    {
        if(_eventManager != null && _eventManager != this)
        {
            Destroy(_eventManager);
        }
        else
        {
            _eventManager = this;
        }

        if(_eventDic == null)
        {
            _eventDic = new Dictionary<string, UnityEvent>();
        }

        if(_eventTDic == null)
        {
            _eventTDic = new Dictionary<string, UnityEvent<int>>();
        }

    }
    public void StartListening(string key, UnityAction<int> linstener)
    {
        UnityEvent<int> _thisEvent;
        if (_eventTDic.TryGetValue(key, out _thisEvent))
        {
            _thisEvent.AddListener(linstener);
        }
        else
        {
            _thisEvent = new UnityEvent<int>();
            _thisEvent.AddListener(linstener);
            _eventTDic.Add(key, _thisEvent);
        }
    }

    public void StopListening(string key, UnityAction<int> linstener)
    {
        if (_eventManager == null)
        {
            return;
        }

        UnityEvent<int> _thisEvent;
        if (_eventTDic.TryGetValue(key, out _thisEvent))
        {
            _thisEvent.RemoveListener(linstener);
        }
    }
    public void StartListening(string key, UnityAction linstener)
    {
        UnityEvent _thisEvent;
        if (_eventDic.TryGetValue(key, out _thisEvent))
        {
            _thisEvent.AddListener(linstener);
        }
        else
        {
            _thisEvent = new UnityEvent();
            _thisEvent.AddListener(linstener);
            _eventDic.Add(key, _thisEvent);
        }
    }

    public void StopListening(string key, UnityAction linstener)
    {
        if(_eventManager == null)
        {
            return;
        }

        UnityEvent _thisEvent;
        if (_eventDic.TryGetValue(key, out _thisEvent))
        {
            _thisEvent.RemoveListener(linstener);
        }
    }

    public void TriggerEvent(string key)
    {
        UnityEvent _thisEvent;
        if (_eventDic.TryGetValue(key, out _thisEvent))
        {
            _thisEvent.Invoke();
        }
    }

    public void TriggerEvent(string key, int param)
    {
        UnityEvent<int> _thisEvent;
        if (_eventTDic.TryGetValue(key, out _thisEvent))
        {
            _thisEvent.Invoke(param);
        }
    }

}
