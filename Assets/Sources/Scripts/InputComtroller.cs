using UnityEngine;
using System.Collections;

public class InputComtroller : MonoBehaviour
{
    // Update is called once per frame
    

    void Start()
    {
        
    }


    public void UpArrow ()
    {
        EventArgs e = new EventArgs();
        e.arg1 = "Hello World";
        EventManager.Instance.Raise(e);

    }

    void Update()
    {

      

    }


}
