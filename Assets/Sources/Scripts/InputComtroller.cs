using UnityEngine;
using System.Collections;
using Entitas;

public class InputComtroller : MonoBehaviour
{
    // Update is called once per frame
    Entity _Enitity;

    void Start()
    {
        _Enitity = Pools.pool.CreateEntity();
    }


    public void UpArrow ()
    {
        _Enitity.IsInteractive(true);

    }

    void Update()
    {

      

    }
}
