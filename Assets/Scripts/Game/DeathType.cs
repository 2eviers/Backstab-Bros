using UnityEngine;
using System.Collections;

public class DeathType : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        _max = 3;
        PuzzleTimerP1 = _max;
        PuzzleTimerP2 = _max;
        SkillTimerP1 = _max;
        SkillTimerP2 = _max;
        Player1State = PlayerState.Alive;
        Player2State = PlayerState.Alive;
        ActivePuzzleP1 = false;
        ActivePuzzleP2 = false;
        ActiveSkillP1 = false;
        ActiveSkillP2 = false;

    }

    public enum PlayerState
    {
        Alive,
        Suicide,
        Kill
    }

    [SerializeField]
    private GameObject _player1;
    [SerializeField]
    private GameObject _player2;

    public GameObject Player1 { get { return _player1;} }
    public GameObject Player2 { get { return _player2; } }


    private int _max;

    #region Timer
    public float PuzzleTimerP1 { get; private set; }
    public float PuzzleTimerP2 { get; private set; }
    public float SkillTimerP1 { get; private set; }
    public float SkillTimerP2 { get; private set; }
    #endregion

    #region ActiveTimer
    public bool ActivePuzzleP1 { get; set; }
    public bool ActivePuzzleP2 { get; set; }
    public bool ActiveSkillP1 { get; set; }
    public bool ActiveSkillP2 { get; set; }
    #endregion

    public PlayerState Player1State { get; private set; }
    public PlayerState Player2State { get; private set; }

    private void RunTimer()
    {
        #region PuzzleTimerP1
        if (ActivePuzzleP1)
        {
            PuzzleTimerP1 -= Time.deltaTime;
            if (PuzzleTimerP1 <= 0)
            {
                PuzzleTimerP1 = _max;
                ActivePuzzleP1 = false;
            }
        }
        #endregion

        #region PuzzleTimerP2
        if (ActivePuzzleP2)
        {
            PuzzleTimerP2 -= Time.deltaTime;
            if (PuzzleTimerP2 <= 0)
            {
                PuzzleTimerP2 = _max;
                ActivePuzzleP2 = false;
            }
        }
        #endregion

        #region SkillTimerP1
        if (ActiveSkillP1)
        {
            SkillTimerP1 -= Time.deltaTime;
            if (SkillTimerP1 <= 0)
            {
                SkillTimerP1 = _max;
                ActiveSkillP1 = false;
            }
        }
        #endregion

        #region SkillTimerP2
        if (ActiveSkillP2)
        {
            SkillTimerP2 -= Time.deltaTime;
            if (SkillTimerP2 <= 0)
            {
                SkillTimerP2 = _max;
                ActiveSkillP2 = false;
            }
        }
        #endregion
    }

    private void ChangeState()
    {
        if (PuzzleTimerP1 != _max && !_player2.GetComponent<Player>().enabled && Player2State == PlayerState.Alive)
            Player2State = PlayerState.Kill;
        if (SkillTimerP1 != _max && !_player2.GetComponent<Player>().enabled && Player2State == PlayerState.Alive)
            Player2State = PlayerState.Kill;
        if (PuzzleTimerP2 != _max && !_player1.GetComponent<Player>().enabled && Player1State == PlayerState.Alive)
            Player1State = PlayerState.Kill;
        if (SkillTimerP2 != _max && !_player1.GetComponent<Player>().enabled && Player1State == PlayerState.Alive)
            Player1State = PlayerState.Kill;
        if (!_player1.GetComponent<Player>().enabled && Player1State == PlayerState.Alive)
            Player1State = PlayerState.Suicide;
        if (!_player2.GetComponent<Player>().enabled && Player2State == PlayerState.Alive)
            Player2State = PlayerState.Suicide;
    }

    // Update is called once per frame
    void Update()
    {
        RunTimer();
        ChangeState();
    }
}