using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class gonextscene : MonoBehaviour
{
   public void sendhelp(){


    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


   }
}
