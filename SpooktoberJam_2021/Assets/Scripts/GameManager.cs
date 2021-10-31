using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton instance.
    public static GameManager instance;
    
    // TODO: Reference to the player.

    // Score.
    [SerializeField] float score;

    /// <summary>
    /// Total cats rescued. Increases when cats are picked up, decreases when cats are thrown.
    /// </summary>
    public int CatsRescued { get; private set; } = 0;

    /// <summary>
    /// Total cats sacrificed (thrown or naturally eaten).
    /// </summary>
    public int CatsSacrificed { get; private set; } = 0;

    /// <summary>
    /// Total number of cats in the level (self-calculated).
    /// </summary>
    public int CATS_TOTAL { get; private set; }

    private void Awake()
    {
        //Set and handle Singleton for Game Manager. Destroy duplicates.
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Mulitple GameManagers detected. Duplicates were destroyed.");
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToCatsRescued()
    {
        CatsRescued++;
    }

    public void SacrificeCat()
    {
        CatsRescued--;
        CatsSacrificed++;
    }

    /// <summary>
    /// For use by PickUp_Cat class only. Add cat to static cats count.
    /// </summary>
    public void AddToCatsTotal()
    {
        CATS_TOTAL++;
    }

    
}
