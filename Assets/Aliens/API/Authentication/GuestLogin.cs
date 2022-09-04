using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class GuestLogin : MonoBehaviour {
    public enum GameState { MenuIdle, LoggingIn, Error, LoggedIn, Play };
    public GameState gameState = GameState.MenuIdle;
    public Animator buttonAnimator;
    public Button button;

    void Start() {

    }

    public void ButtonPress() { // Connects to the canvas button "login" in the scene
        if (ValidAnimationIsPlaying() == false) {
            return;
        }
        switch (gameState) {
            case GameState.MenuIdle: // This is the state when the user opens the game first
                Login();
                break;
            case GameState.Error:
                Login();
                break;
            case GameState.LoggedIn:
                Play();
                break;
            case GameState.Play:
                buttonAnimator.SetTrigger("Back");
                gameState = GameState.MenuIdle;
                break;
        }
    }

    private void Login() {
        gameState = GameState.LoggingIn;
        buttonAnimator.SetTrigger("Login");
        StartCoroutine(GuestLoginRoutine());
    }

    private void Play()
    {
        gameState = GameState.Play;
        buttonAnimator.SetTrigger("Play");
    }

    private IEnumerator GuestLoginRoutine() {
        bool gotResponse = false;
        LootLockerSDKManager.StartGuestSession((response) => { // Send web request to LL to start the game session with a guest account
            if (response.success) {
                gotResponse = true;
                gameState = GameState.LoggedIn;
            } else {
                gameState = GameState.Error;
                gotResponse = true;
            }
        });

        yield return new WaitWhile(() => gotResponse == false); // wait until a response has been retrieved from the LL server

        if (gameState == GameState.Error) { // Play correct animation based on gameState
            buttonAnimator.SetTrigger("Error");
        } else if (gameState == GameState.LoggedIn) {
            buttonAnimator.SetTrigger("LoggedIn");
        }
    }

    bool ValidAnimationIsPlaying() {
        if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleError")) {
            return true;
        }
        if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdlePlay")) {
            return true;
        }
        if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleLogin")) {
            return true;
        }
        if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleCross")) {
            return true;
        }
        return false;
    }

    public bool isLoggedIn;

    private void SimpleGuestLogin() {
        LootLockerSDKManager.StartGuestSession((response) => { if (response.success) isLoggedIn = true; }); // if "success" response from server, log the user in
    }

    // To-Do: Load this when user logs in with metamask and then send a post request to flask detailing all user info from both lootlocker and moralis/eth
}