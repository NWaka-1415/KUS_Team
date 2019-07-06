using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager = null;
    [SerializeField] private UIManager _uiManager = null;
    [SerializeField] private CharaStatus _charaStatus = null;
    [SerializeField] private MovePointManager _movePoint = null;
    [SerializeField] private Camera _camera = null;
    private static SoundManager _soundManagerStatic = null;
    private static UIManager _uiManagerStatic = null;
    private Quaternion _cameraDefault;

    private float _time = 1.5f;

    /// <summary>
    /// ボーナスステージ突入かどうか
    /// </summary>
    private static bool _isBonus;

    // Start is called before the first frame update
    void Start()
    {
        _soundManagerStatic = _soundManager;
        _uiManagerStatic = _uiManager;
        _soundManager.PlayBGM();
        _isBonus = false;
        _cameraDefault = _camera.transform.rotation;
    }

    private void Update()
    {
        if (_charaStatus.Point >= 20)
        {
            _movePoint.gameObject.SetActive(true);
        }

        if (_isBonus)
        {
//            if (_time <= 0f)
//            {
//                _camera.transform.rotation = _cameraDefault;
//            }

            _camera.gameObject.transform.Rotate(0f, 0f, 20f);
            _time -= Time.deltaTime;
        }
    }

    public static void SetBonus()
    {
        _isBonus = true;
        _uiManagerStatic.SetBonusPanel();
    }

    public void OnclickMoveToTitle()
    {
        SceneManager.LoadSceneAsync("StartScene");
    }

    public static void PlaySE(string audioName)
    {
        _soundManagerStatic.PlaySE(audioName);
    }

    public static void StopBGM()
    {
        _soundManagerStatic.StopBGM();
    }

    public static bool IsBonus => _isBonus;
}