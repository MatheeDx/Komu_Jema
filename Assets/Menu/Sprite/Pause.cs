using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    public bool menuExit;
    public GameObject OptionsPanel;
    public float timer;
    public GameObject GameOverPanel;
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;
    [SerializeField] private Text timerText;

    private float _timeLeft = 0f;
    void Start()
    {
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            int sek = (int)_timeLeft;
            if (normalizedValue == 0.0f)
                GameOver();
            timerText.text = sek.ToString();
            yield return null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Вроде работает");
            menuExit = !menuExit;

            if (PausePanel == menuExit)
            {
                PausePanel.SetActive(true);
                Invoke("StopTime", timer);
            }
            else
            {
                PausePanel.SetActive(false);
                Invoke("PlayTime", 0);

            }
        }
    }
    public void ExitGame()
    {
        Debug.Log("Игра всё");
        Application.Quit();
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Invoke("StopTime", timer);
    }
    public void BackGame()
    {
        PausePanel.SetActive(false);
        menuExit = !menuExit;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Invoke("PlayTime", 0);
    }
    public void BackOptions()
    {
        OptionsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }
    public void Restart()
    {
        PlayTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void StopTime()
    {
        Time.timeScale = 0f;
    }
    void PlayTime()
    {
        Time.timeScale = 1f;
    }
}
