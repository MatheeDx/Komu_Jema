using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PausePanelDownBar;
    public GameObject OptionsPanel;
    public float timer;
    public GameObject GameOverPanel;
    public GameObject HUD;
    public GameObject ZTM;
    [SerializeField] private float time;
    [SerializeField] private Image timerImage;
    [SerializeField] private Text timerText;
    int x, y, z;
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
        Debug.Log(PausePanelDownBar.transform.position);
        if (PausePanel.activeSelf == false && OptionsPanel.activeSelf == false) {
            PausePanelDownBar.transform.position = new Vector3(-1560, -238, 0);
            PlayTime(); 
        }
        if (PausePanelDownBar.transform.position == new Vector3(960, 302, 0))
        {
            StopTime();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("����� ��������");

            if (PausePanel.activeSelf == false)
            {
                PausePanel.SetActive(true);
            }
            else if (PausePanel.activeSelf == true)
            {
                PausePanel.SetActive(false);

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
