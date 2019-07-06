using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D _rb2D;
    [SerializeField] private CharaStatus _charastatus;

    [SerializeField] float _jumpPower;

    [SerializeField] private float _constCoolTime = 0;
    private float _coolTime = 0;

    Vector2 _addVec = Vector2.zero;

    [SerializeField] SpriteRenderer _charaSprite;
    [SerializeField] Sprite[] _animationsSprite;
    [SerializeField] Sprite _deathSprite = null;
    [SerializeField] private BoxCollider2D _boxCollider2D = null;

    private void check_animation()
    {
        bool flag = false;
        int animationNumber = 0;
        if (_rb2D.velocity.y > 0 && _charastatus.CharaState != CharaStatus.State.Jump)
        {
            flag = true;
            animationNumber = (int) CharaStatus.State.Jump;
        }
        else if (_rb2D.velocity.y < 0 && _charastatus.CharaState != CharaStatus.State.Fall)
        {
            flag = true;
            animationNumber = (int) CharaStatus.State.Fall;
        }


        if (flag)
        {
            Animation_Update(animationNumber);
        }
    }

    void Animation_Update(int animationNumber)
    {
        _charaSprite.sprite = _animationsSprite[animationNumber];
        _charastatus.CharaState = (CharaStatus.State) System.Enum.ToObject(typeof(CharaStatus.State), animationNumber);
    }


    void Awake()
    {
        _rb2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        _addVec = new Vector2(0, _jumpPower);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameSceneManager.IsBonus)
        {
            _rb2D.gravityScale = 0f;
            _rb2D.velocity = Vector2.zero;
            return;
        }

        if (_charastatus.CharaState == CharaStatus.State.Death)
        {
            _charaSprite.sprite = _deathSprite;
            _rb2D.gravityScale = 2f;
            _rb2D.AddForce(new Vector2(0, 20f));
            _boxCollider2D.isTrigger = true;
            return;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && _coolTime <= 0)
        {
            float rand = Random.Range(0f, 1f);
            GameSceneManager.PlaySE(SoundManager.AudioName.Jump1);
//            GameSceneManager.PlaySE(SoundManager.AudioName.Jump);
            _rb2D.velocity = Vector2.zero;
            _rb2D.AddForce(_addVec, ForceMode2D.Impulse);
            _coolTime = _constCoolTime;
        }

        if (_coolTime > 0)
        {
            _coolTime -= Time.deltaTime;
            if (_coolTime < 0)
            {
                _coolTime = 0;
            }
        }

        check_animation();
    }
}