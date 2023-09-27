using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Saves and loads the player character's position in the game world.
/// </summary>
public class SaveLoadSystem : MonoBehaviour
{
    // We need...
    // - save the transform information of the player character
    //   - position, rotation, and scale
    // - player's inventory
    // - player's current hit points
    // - position of enemies in the game world

    GameObject playerCharacter;
    GameObject[] enemies;

    private void Start()
    {
        playerCharacter = GameObject.Find("Player Character");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            Load();
        }
    }

    /// <summary>
    /// Call this when we want to store game data in PlayerPrefs.
    /// </summary>
    private void Save()
    {
        // - save the transform information of the player character
        // character's Vector3 variables are just three floats

        PlayerPrefs.SetFloat("playerXpos", playerCharacter.transform.position.x);
        PlayerPrefs.SetFloat("playerYpos", playerCharacter.transform.position.y);
        PlayerPrefs.SetFloat("playerZpos", playerCharacter.transform.position.z);

        Debug.Log("Saved player position data.");

        for (int i = 0; i < enemies.Length; i++)
        {
            PlayerPrefs.SetFloat("Enemy" + enemies[i], enemies[i].transform.position.x);
        }

        //if (playerHasTheBossSword == true)
        //{
        //    PlayerPrefs.SetInt("bossSword", 1);
        //}
    }

    /// <summary>
    /// Call this when we want to retrieve stored game data from PlayerPrefs.
    /// </summary>
    private void Load()
    {
        Vector3 retrievedVector;
        retrievedVector.x = PlayerPrefs.GetFloat("playerXpos", 0);
        retrievedVector.y = PlayerPrefs.GetFloat("playerYpos", 0);
        retrievedVector.z = PlayerPrefs.GetFloat("playerZpos", 0);

        playerCharacter.transform.position = retrievedVector;

        //transform.position.Set(PlayerPrefs.GetFloat("playerXpos", 0), PlayerPrefs.GetFloat("playerYpos", 0), PlayerPrefs.GetFloat("playerZpos", 0));
        
        Debug.Log("Loaded player position data.");
    }
}
