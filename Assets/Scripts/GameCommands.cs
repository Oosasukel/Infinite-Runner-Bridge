using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCommands : MonoBehaviour
{
    public void GoTo(string target)
    {
        SceneManager.LoadScene(target);
    }
}
