using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        EventManager.Instance.AddListener<EventArgs>(HelloWorld);
    }
    void OnDisable()
    {
        EventManager.Instance.RemoveListener<EventArgs>(HelloWorld);
    }

    void HelloWorld(EventArgs e)
    {
        Debug.Log(e.arg1);
    }
}

public class EventArgs : EventManager
{
    public object arg1, arg2, arg3, arg4, arg5;
}