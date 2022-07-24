using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGame : MonoBehaviour
{
    public GameObject gameSelectButton;
    public GameObject optionsSelectButton;
    public GameObject moralisAuthButton;

    public void selectGameButtonClicked() {
        gameSelectButton.SetActive(false);
        optionsSelectButton.SetActive(false);
        moralisAuthButton.SetActive(false);
    }
}
 // Note -> Once inventory is complete, set up so it writes to a local db