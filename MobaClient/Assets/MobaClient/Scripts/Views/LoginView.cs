using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginView : MonoBehaviour {

    public InputField account;
    public InputField password;

    public GameObject objRegister;

    public void Login()
    {

    }

    public void Register()
    {
        objRegister.SetActive(true);
    }
}
