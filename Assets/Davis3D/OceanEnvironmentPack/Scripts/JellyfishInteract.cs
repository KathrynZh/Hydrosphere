using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishInteract : MonoBehaviour
{
 
    public FloatingText flotT;

    void OnMouseEnter()
    {
        

        if (flotT != null)
        {
            flotT.gameObject.SetActive(true);
        }

    }
    
      void OnMouseExit()
    {
         
        
        if (flotT != null)
        {
            flotT.gameObject.SetActive(false);
        }

       
    }

    
}
