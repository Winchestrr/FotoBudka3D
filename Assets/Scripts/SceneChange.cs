using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ExitApp();
    }

    public void StartChangeAnim()
    {
        _animator.SetTrigger("ChangeScene");
    }

    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
