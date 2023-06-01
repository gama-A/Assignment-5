using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : Interactable
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject particle;
    private GameSystem gameSystem;


    protected override void Interact()
    {
        Debug.Log("Interacted with " + particle);
        int num = gameSystem.NextToCollect();
        if(particle.name == num.ToString())
        {
            particle.SetActive(false);
            if (num == 5)
            {
                gameSystem.ResetGame();
                num = 0;
            }
            gameSystem.UpdateNext(num + 1);
        }
        else
        {
            Debug.Log("Wrong item, collect in order");
        }
    }
}
