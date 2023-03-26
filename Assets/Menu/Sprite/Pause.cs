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
    public GameObject HUD;
    public GameObject ZTM;
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;
    [SerializeField] private Text timerText;

    private float _timeLeft = 0f;
    void Start()
    {
        HUD.SetActive(true);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        _timeLeft = time;
        Invoke("StTimer", timer);
        Invoke("Zatem", timer);
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
            Debug.Log("����� ��������");
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
    public void StTimer()
    {
        StartCoroutine(StartTimer());
    }
    public void ExitGame()
    {
        Debug.Log("���� ��");
        Application.Quit();
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Invoke("StopTime", timer);
    }
    public void BackGame()
    {
        Invoke("PlayTime", 0);
        PausePanel.SetActive(false);
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
    void Zatem()
    {
        ZTM.SetActive(false);
    }
}