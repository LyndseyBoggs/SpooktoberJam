using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton instance.
    public static GameManager instance;

    // Reference to the player.
    public GameObject Player;

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

    public GameObject CatPrefab;

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

    public void AddToCatsRescued()
    {
        CatsRescued++;
    }

    public void SacrificeThrowCat()
    {
        CatsRescued--;
        CatsSacrificed++;
        UIManager.instance.UpdateCatCounter(0.0f);
        GameObject cat = Instantiate(CatPrefab, Player.transform.position, Quaternion.Inverse(Player.transform.rotation));
        cat.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f));
    }

    public void SacrificeWildCat()
    {
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
