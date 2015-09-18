using UnityEngine;
using System.Collections;
using Entitas;
using UnityStandardAssets.CrossPlatformInput;

public class InputManagementSystem : IExecuteSystem, ISetPool
{
    Pool _Pool;
    Entity e;

    public void SetPool(Pool pool)
    {
        _Pool = pool;
        e = _Pool.CreateEntity();
   
    }

    public void Execute()
    {

        e.isInputBeingClicked = CrossPlatformInputManager.GetButton(KeyCode.Mouse0.ToString());
         
    }


}
