using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterView : MonoBehaviour {

    public InputField account;
    public InputField password;

    public void Register()
    {

    }

    public void Return()
    {
        gameObject.SetActive(false);
    }
}
