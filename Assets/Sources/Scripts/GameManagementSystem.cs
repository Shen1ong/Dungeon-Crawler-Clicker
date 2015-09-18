using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameManagementSystem : MonoBehaviour
{

    
    Systems _Systems;


    // Use this for initialization
    void Start()
    {
        _Systems = CrateSystems(Pools.pool);
        _Systems.Initialize();   

    }

    // Update is called once per frame
    void Update()
    {
        _Systems.Execute();
        
    }

    Systems CrateSystems(Pool pool)
    {
#if (UNITY_EDITOR)
        return new DebugSystems()
#else
        return new Systems()
#endif

        //Input
        .Add(pool.CreateSystem<InputManagementSystem>());
    }
}
