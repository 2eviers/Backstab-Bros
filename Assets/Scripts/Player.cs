using System;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    /// <summary>
    /// Cette variable est le préfix des controle dans l'InputManager il vaut "J1" ou "J2"
    /// </summary>
    [SerializeField] 
    private string _prefixController = "J1";
    /// <summary>
    /// Vitesse maximal de l'avatar
    /// </summary>
    public float MaxSpeed = 10.0f;
    /// <summary>
    /// Hauteur maximal de l'avatar
    /// </summary>
    public float JumpHeight = 2.0f;
    /// <summary>
    /// Temps de jump controle (temps pendant lequel tu peux augmenter la hauteur du saut
    /// </summary>
    [SerializeField]
    private float _jumpControlDuration = 0.5f;
    /// <summary>
    /// Acceleration maximale
    /// </summary>
    [SerializeField]
    private float _maxAcceleration = 5.0f;
    /// <summary>
    /// Acceleration maximale en l'air
    /// </summary>
    [SerializeField]
    private float _maxAccelerationAir = 1.0f;
    /// <summary>
    /// Acceleration maximale en l'air
    /// </summary>
    [SerializeField]
    private float _minJumpHeight = 1.0f;
    /// <summary>
    /// Vaut true si et seulement si l'avatar peut sauter
    /// </summary>
    public bool CanJump = true;
    /// <summary>
    /// Variable nécessaire à repérer quand le personnage est au sol
    /// </summary>
    private int grounded = 0;
    /// <summary>
    /// Temps au moment du saut (nécessaire pour jauger un saut)
    /// </summary>
    private float timerJump;

    private float _jumpRatio = 15f/30f;

    private Animator anim;
    
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }


    void FixedUpdate()
    {

        var axis = new Vector3(Input.GetAxis(_prefixController+"Horizontal"),0, 0);
        axis += new Vector3(Input.GetAxis(_prefixController + "HorizontalJoystick"),0, 0);
        if (grounded>0)
        {
            anim.speed = Mathf.Abs(rigidbody.velocity.x);
            if (axis.magnitude > 0)
            {
                // Calcule la vitesse à atteindre
                var targetVelocity = transform.TransformDirection(axis);
                targetVelocity *= MaxSpeed;

                // Apply a force that attempts to reach our target velocity
                Vector3 velocity = rigidbody.velocity;
                Vector3 velocityChange = (targetVelocity - velocity);
                var maxVelChan = _maxAcceleration;
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelChan, maxVelChan);
                velocityChange.z = 0;
                velocityChange.y = 0;
                rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
            }
            // Jump
            if (CanJump && Input.GetButton(_prefixController+"Jump"))
            {
                var initialJumpSpeed = CalculateInitialJumpVerticalSpeed(_minJumpHeight);
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, initialJumpSpeed, rigidbody.velocity.z);
                timerJump = Time.time;
                var tempsDeVole = 2*initialJumpSpeed/(Physics.gravity.magnitude);
                anim.speed = _jumpRatio / tempsDeVole;
            }
        }
        // si le personnage est en vole
        else
        {   
            var velocityChange = _maxAccelerationAir * transform.TransformDirection(axis);
            var t = timerJump + _jumpControlDuration - Time.time;
            
            if (CanJump && Input.GetButton(_prefixController+"Jump") && t>0)
            {
                velocityChange.y = CalculateJumpForce();

                var initialJumpSpeed = CalculateInitialJumpVerticalSpeed(_minJumpHeight);
                var finalJumpSpeed = CalculateInitialJumpVerticalSpeed(JumpHeight);
                var ratio = t/_jumpControlDuration;
                var tempsDeVole = 2*(finalJumpSpeed - ratio * (finalJumpSpeed - initialJumpSpeed)) 
                    / (Physics.gravity.magnitude);
                anim.speed = _jumpRatio / tempsDeVole;

            }
            
            rigidbody.AddForce(velocityChange, ForceMode.Force);
        }

        //grounded = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        grounded++;
        if(grounded>0)
            anim.Play("GoFront");
    }

    void OnCollisionExit(Collision collision)
    {
        grounded--;
        if(grounded==0)
            anim.Play("Jump");
    }
    /// <summary>
    /// Calcule la vitesse de saut initiale 
    /// </summary>
    /// <returns></returns>
    float CalculateInitialJumpVerticalSpeed(float hauteur)
    {
        return Mathf.Sqrt(2 * hauteur * Physics.gravity.magnitude * rigidbody.mass);
    }
    float CalculateJumpForce()
    {
        float deltaTime = 1/_jumpControlDuration;//Time.fixedDeltaTime / _jumpControlDuration;
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * (JumpHeight -_minJumpHeight) * Physics.gravity.magnitude * deltaTime);
    }
}
