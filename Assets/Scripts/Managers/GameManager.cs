
/*
 * -----------------------------------------
 * -- Project: Endless Runner 2D -----------
 * -- Author: Rubén Rodríguez Estebban -----
 * -- Date: 98/10/2021 ---------------------
 * -----------------------------------------
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Script that controls the status of the game
 */

public class GameManager : MonoBehaviour
{
    // Distance covered by the player
    private float distance;

    // Music level soundtrack
    private AudioSource audioSource;
    
    // Energry points of the player
    public int energyPoints;

    // Indicartor text of the energy points of the player
    public Text energyText;

    // Indicartor text of distance covered
    public Text distanceText;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the reference of the audio source component and plays the soundtrack and keeps its time
        audioSource = GetComponent<AudioSource>();
        audioSource.time = PlayerPrefs.GetFloat("MusicTime");
        audioSource.Play();

        // Update the energy points of the player in the HUD
        UpdateEnergyPoints();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates the distance using time between frames and updates the HUD energy points indicator
        distance += Time.deltaTime;
        int distanceValue = (int)distance;
        distanceText.text = distanceValue.ToString();
    }

    // Increments the energy points of the player
    public void AddEnergyPoints()
    {
        // Add one energy point and updates the HUD energy points indicator
        energyPoints++;
        UpdateEnergyPoints();
    }

    // Decrease the energy points of the player
    public void DecreaseEnergyPoints()
    {
        // Decrese energy points of the player if he has more than one
        if (energyPoints > 1)
        {
            // Decrease one energy point and updates the HUD energy points indicator
            energyPoints--;
            UpdateEnergyPoints();
        }
        else
        {
            // Sets the game over when the player has zero energy points
            GameOver();
        }
    }


    private void UpdateEnergyPoints()
    {
        energyText.text = energyPoints.ToString();
    }

    public void GameOver()
    {
        PlayerPrefs.SetFloat("MusicTime", audioSource.time);
        audioSource.Stop();
        SceneManager.LoadScene("Level");
    }
}
