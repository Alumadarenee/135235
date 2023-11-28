using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
//using Newtonsoft.Json;
using UnityEngine.UI;
using TMPro;

public class PlayFabManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("UI")]
    public Text messageText;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField emailInput;

   

    public void RegisterButton()
    { 
       var request = new RegisterPlayFabUserRequest
       {
        Email = emailInput.text,
        Password = passwordInput.text,
        Username = usernameInput.text,
        //RequireBothUsernameAndPassword = false
       };
       PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess,OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and Loggen in!";
        Debug.Log("Registered and Loggen in!!");
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnloginSuceess, OnError);

    }

    public void PasswordResetButton() 
    {
        var request = new SendAccountRecoveryEmailRequest
        {
             Email = emailInput.text,
             TitleId = "9BD02"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnForgotPassword, OnError);

    }
    void OnForgotPassword(SendAccountRecoveryEmailResult result){
         messageText.text = "Password reset Mail sent!";
        Debug.Log("Password reset Mail sent!");

    }
    void Start()
    {
        Login();
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request , OnSuccess, OnError);
    }

    void OnloginSuceess(LoginResult result){
        messageText.text = "Logged in";
        Debug.Log("Succesful login/account Create!");
        //GetCharacters();
    }

    void OnSuccess(LoginResult result)
    {
        messageText.text = "Registered and  Logged in";
        Debug.Log("Successful login!");
    }

    void OnError(PlayFabError error)
    {
        messageText.text = "Error!";
        Debug.Log(error.GenerateErrorReport());
    }
}
