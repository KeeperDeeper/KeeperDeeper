using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testbtn : MonoBehaviour
{
    public void MoveTest1()
    {
        SceneManager.LoadScene("HGTestScene");
    }
    public void MoveTest2()
    {
        SceneManager.LoadScene("HGTest2");
    }
}
