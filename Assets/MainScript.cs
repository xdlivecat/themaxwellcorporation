using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEditor;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    public GameObject LoginUI;
    public GameObject RegisterUI;
    public GameObject Account;
    public TMP_Text registerText;
    public GameObject Menu;
    public GameObject Main;
    public GameObject PurchaseConfirmation;
    public TMP_Text PurchaseConfirmation2;
    public GameObject PurchaseOver;
    public TMP_Text PurchaseDetails;
    public TMP_Text EASText;
    public Button EASButton;
    public TMP_Text TMCBText;
    public Button TMCBButton;
    public GameObject TMCBBuy;
    public TMP_Text TMCSTText;
    public Button TMCSTButton;
    public GameObject TMCSTBuy;
    public GameObject EASBuy;
    public TMP_Text PurchaseInfo1;
    public TMP_Text PurchaseInfo2;
    public TMP_Text PurchaseInfo3;
    public TMP_Text messageText1;
    public TMP_Text messageText2;
    public TMP_Text messageText3;
    public TMP_InputField emailInput1;
    public TMP_InputField IDInput;
    public TMP_InputField emailInput2;
    public TMP_InputField passwordInput1;
    public TMP_InputField passwordInput2;
    public TMP_Text AccountID;
    public TMP_Text email;
    public TMP_Text VoteText;
    public Button VoteButton;
    public GameObject navigation;
    public GameObject Darken;
    public GameObject Subscriptions;
    public GameObject Election;
    public GameObject Affiliates;
    public bool privacy;
    public GameObject idlogin;
    public TMP_InputField usernameinput;
    void GetAccountInfo()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, Success, Error);
    }
    private void Start()
    {
        Menu.SetActive(false);
    }
    void Success(GetAccountInfoResult result)
    {
        AccountID.text = result.AccountInfo.Username;
    }
    public void privacytrue()
    {
        privacy = true;
    }

    public void privacyopen()
    {
        Application.OpenURL("https://docs.google.com/document/d/1G9sNg7-a_WXNn1RNYxTuyg6T53kpB0-svvXSbpjsA_0/edit?usp=sharing");
    }
    void Error(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    public void Register()
    {
        LoginUI.SetActive(false);
        RegisterUI.SetActive(true);
    }

    public void RegisterBack()
    {
        RegisterUI.SetActive(false);
        LoginUI.SetActive(true);
    }

    public void RegisterButton()
    {
        if (passwordInput2.text.Length < 6)
        {
            messageText2.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput2.text,
            Username = usernameinput.text,
            Password = passwordInput2.text,
            RequireBothUsernameAndEmail = true
        };

        if (privacy == true)
        {
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
        }
        else
        {
            registerText.text = "Please agree to the privacy policy!";
            registerText.fontSize = 10;
        }
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText2.text = "Registered and logged in!";
        Menu.SetActive(true);
        RegisterUI.SetActive(false);
        Main.SetActive(true);
        GetAccountInfo();
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput1.text,
            Password = passwordInput1.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }
    public void LoginIDButton()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = IDInput.text,
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput1.text,
            TitleId = "B1892"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText1.text = "Password Reset email sent! Check your email!";
        messageText3.text = "Password Reset email sent!";
    }

    void OnSuccess(LoginResult result)
    {
        messageText1.text = "Logged in!";
        Debug.Log("success");
        Menu.SetActive(true);
        LoginUI.SetActive(false);
        Main.SetActive(true);
        messageText1.enabled = false;
        idlogin.SetActive(false);
        GetAccountInfo();
    }

    public void Navigation()
    {
        Darken.SetActive(true);
        navigation.SetActive(true);    
    }
    public void NavigationBack()
    {
        Darken.SetActive(false);
        navigation.SetActive(false);
    }

    public void TOS()
    {
        Application.OpenURL("https://docs.google.com/document/d/1Ack7GK6tADpHQho8_yASaZ5NhJF1Z_Tv43i2YGKI9wg/edit?usp=sharing");
    }
    public void VoteClosed()
    {
        VoteText.text = "Votes are currently closed!";
        VoteText.fontSize = 9;
        VoteButton.enabled = false;
    }
    public void Home()
    {
        Main.SetActive(true);
        Account.SetActive(false);
        Darken.SetActive(false);
        navigation.SetActive(false);
        Subscriptions.SetActive(false);
        Election.SetActive(false);
        Affiliates.SetActive(false);
    }

    public void subscriptions()
    {
        Main.SetActive(false);
        Account.SetActive(false);
        Darken.SetActive(false);
        navigation.SetActive(false);
        Subscriptions.SetActive(true);
        Election.SetActive(false);
        Affiliates.SetActive(false);
    }
    public void ElectionUI()
    {
        Application.OpenURL("https://imgur.com/a/2BCmJmy");
    }

    public void account()
    {
        Main.SetActive(false);
        Account.SetActive(true);
        Darken.SetActive(false);
        navigation.SetActive(false);
        Subscriptions.SetActive(false);
        Election.SetActive(false);
        Affiliates.SetActive(false);
    }
    public void affiliates()
    {
        Main.SetActive(false);
        Account.SetActive(false);
        Darken.SetActive(false);
        navigation.SetActive(false);
        Subscriptions.SetActive(false);
        Election.SetActive(false);
        Affiliates.SetActive(true);
    }

    public void PauloVM()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=kOG0_qjKWEI&pp=ygUPbWF4d2VsbCB0aGUgY2F0");
    }
    public void Discord()
    {
        Application.OpenURL("https://discord.com/invite/ZrfjKcqeXM");
    }

    void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        messageText1.text = error.ErrorMessage;
        messageText2.text = error.ErrorMessage;
    }

    public void EASPurchaseConfirm()
    {
        PurchaseConfirmation2.text = "Would you like to purchase MaxwellEAS for €1.50?";
        Main.SetActive(false);
        Menu.SetActive(false);
        TMCBBuy.SetActive(false);
        EASBuy.SetActive(true);
        PurchaseConfirmation.SetActive(true);
    }
    public void EASPurchased()
    {
        PurchaseConfirmation.SetActive(false);
        PurchaseOver.SetActive(true);
        PurchaseInfo1.text = "Product ID: easpreorder";
        PurchaseInfo2.text = "Price: €1.50";
        PurchaseInfo3.text = "Status: Success";
        EASText.text = "Purchased";
        EASButton.enabled = false;
    }
    public void EASPurchaseFailed()
    {
        PurchaseConfirmation.SetActive(false);
        PurchaseOver.SetActive(true);
        PurchaseDetails.text = "Thank you for shopping with TMC! Your purchase has failed. If you think this is a mistake, please contact Google Play Support.";
        PurchaseInfo1.text = "Product ID: easpreorder";
        PurchaseInfo2.text = "Price: €1.50";
        PurchaseInfo3.text = "Status: Failed";
    }

    public void TMBCPurchaseConfirm()
    {
        PurchaseConfirmation2.text = "Would you like to purchase TMC Standard for €1.00 per month?";
        Subscriptions.SetActive(false);
        Menu.SetActive(false);
        TMCBBuy.SetActive(true);
        EASBuy.SetActive(false);
        PurchaseConfirmation.SetActive(true);
    }

    public void TMCBPurchased()
    {
        PurchaseConfirmation.SetActive(false);
        PurchaseOver.SetActive(true);
        PurchaseInfo1.text = "Product ID: tmcstandard";
        PurchaseInfo2.text = "Price: €1.00 per month";
        PurchaseInfo3.text = "Status: Success";
        TMCBText.text = "Purchased";
        TMCBButton.enabled = false;
    }
    public void TMCBPurchaseFailed()
    {
        PurchaseConfirmation.SetActive(false);
        PurchaseOver.SetActive(true);
        PurchaseDetails.text = "Thank you for shopping with TMC! Your purchase has failed. If you think this is a mistake, please contact Google Play Support.";
        PurchaseInfo1.text = "Product ID: tmcstandard";
        PurchaseInfo2.text = "Price: €1.00 per month";
        PurchaseInfo3.text = "Status: Failed";
    }

    public void TMBSTPurchaseConfirm()
    {
        PurchaseConfirmation2.text = "Would you like to purchase TMC Standard one month free? (€1.00 per month after trial period)?";
        Subscriptions.SetActive(false);
        Menu.SetActive(false);
        TMCSTBuy.SetActive(true);
        TMCBBuy.SetActive(false);
        EASBuy.SetActive(false);
        PurchaseConfirmation.SetActive(true);
    }

    public void TMCSTPurchased()
    {
        PurchaseConfirmation.SetActive(false);
        PurchaseOver.SetActive(true);
        PurchaseInfo1.text = "Product ID: tmcstandardtrial";
        PurchaseInfo2.text = "Price: €1.00 per month (One month free)";
        PurchaseInfo3.text = "Status: Success";
        TMCSTText.text = "Purchased";
        TMCSTButton.enabled = false;
    }
    public void TMCSTPurchaseFailed()
    {
        PurchaseConfirmation.SetActive(false);
        PurchaseOver.SetActive(true);
        PurchaseDetails.text = "Thank you for shopping with TMC! Your purchase has failed. If you think this is a mistake, please contact Google Play Support.";
        PurchaseInfo1.text = "Product ID: tmcstandardtrial";
        PurchaseInfo2.text = "Price: €1.00 per month (One month free)";
        PurchaseInfo3.text = "Status: Failed";
    }
    public void PurchaseBack()
    {
        PurchaseOver.SetActive(false);
        Main.SetActive(true);
        Menu.SetActive(true);
    }
    public void PurchaseBack2()
    {
        PurchaseConfirmation.SetActive(false);
        Main.SetActive(true);
        Menu.SetActive(true);
    }

    public void EAssets()
    {
        Application.OpenURL("https://discord.gg/KZKngbTHZs'");
    }
}
