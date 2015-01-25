using UnityEngine;
using System.Collections;

public class Caracteristique : MonoBehaviour
{
	public GameObject deathSound;
    public int MaxLife = 100;
    /// <summary>
    /// Vie courrante
    /// </summary>
    protected int _life;
    public int Force = 10;
    public int Score;
    public Animator anim;

	// Use this for initialization
	protected void Start ()
	{

        anim = GetComponentInChildren<Animator>();
	    _life = MaxLife;
	    Score = 0;
	}
	/// <summary>
	/// A chaque frame on vérifie que le personnage est mort.
	/// </summary>
	void Update () {
	    if (_life < 0)
	    {
	        Suicide();
	    }
	}

    /// <summary>
    /// Applique des dommage au player
    /// </summary>
    /// <param name="player"></param>
    public void GiveDamage(Caracteristique player)
    {
        player.TakeDamage(Force);
    }
    /// <summary>
    /// Prend force dommage
    /// </summary>
    /// <param name="force"></param>
    public void TakeDamage(int force)
    {
        _life -= force;
    }

    /// <summary>
    /// Appelé quand le joueur est mort, active l'animation de mort 
    /// </summary>
    void Suicide()
    {
        ////appeler l'animation de mort et desactiver le script de controle
        anim.SetBool("Die",true);
		deathSound.audio.Play ();
        
        GetComponent<Player>().enabled = false;
    }
}
