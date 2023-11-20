using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
  public PlayFabManager playFabManager;

    public void CallRegisterButton()
    {
        playFabManager.RegisterButton();
    }

    public void CallLoginButton()
    {
        playFabManager.LoginButton();
    }
}
