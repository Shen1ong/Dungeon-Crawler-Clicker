using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager
{
    private static EventManager _EventManager = null;

    public static EventManager Instance
    {
        get
        {
            if (_EventManager == null)
                _EventManager = new EventManager();

            return _EventManager;
        } 
    }

    public delegate void EventDelegate<T> (T e) where T : EventManager;

    private Dictionary<System.Type, System.Delegate> _Delegates = new Dictionary<System.Type, System.Delegate>();
    
    public void AddListener<T> (EventDelegate<T> del) where T : EventManager
    {
        if (_Delegates.ContainsKey(typeof(T)))
        {
            System.Delegate tempDel = _Delegates[typeof(T)];
            _Delegates[typeof(T)] = System.Delegate.Combine(tempDel, del);
        }
        else
        {
            _Delegates[typeof(T)] = del;
        }
    }
        
    public void RemoveListener<T> (EventDelegate<T> del) where T : EventManager
    {
        if (_Delegates.ContainsKey(typeof(T)))
        {
            var currentDel = System.Delegate.Remove(_Delegates[typeof(T)], del);

            if( currentDel == null)
            {
                _Delegates.Remove(typeof(T));
            }
            else
            {
                _Delegates[typeof(T)] = currentDel;
            }
        }
    }


    public void Raise(EventManager e)
    {
        if (e == null)
        {
            Debug.Log("Invalid event argument: " + e.GetType().ToString());
            return;
        }

        if (_Delegates.ContainsKey(e.GetType()))
        {
            _Delegates[e.GetType()].DynamicInvoke(e);
        }
    }


}

public class EventArgs : EventManager
{
    public object arg1, arg2, arg3, arg4, arg5;
}