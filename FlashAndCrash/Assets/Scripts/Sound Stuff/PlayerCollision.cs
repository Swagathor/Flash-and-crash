﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(FlickeringLight))]
public class PlayerCollision : MonoBehaviour {
    public GameObject prefab;

    private MultisoundEmitter soundScript;
    private PlayerMovement movementScript;
    private FlickeringLight flickerScript;
    [HideInInspector] public ParticleSystem particleSystem;
    
	// Use this for initialization
	void Start () {
        particleSystem  = (ParticleSystem)prefab.GetComponent(typeof(ParticleSystem));
        soundScript     = (MultisoundEmitter)GetComponent(typeof(MultisoundEmitter));
        movementScript  = (PlayerMovement)GetComponent(typeof(PlayerMovement));
        flickerScript   = (FlickeringLight)GetComponent(typeof(FlickeringLight));
	}

    void OnCollisionEnter(Collision p_collision)
    {
        if (p_collision.gameObject.tag.Contains("ball") || p_collision.gameObject.tag == "wall")
        {
            soundScript.PlaySound("impact", (rigidbody.velocity.magnitude / movementScript.maxSpeed) >= 0.5f ? (rigidbody.velocity.magnitude / movementScript.maxSpeed) : 0.5f);
            StartCoroutine(flickerScript.FlickerLights());
            StartCoroutine(SpawnParticles(p_collision.transform));
        }
    }

    private IEnumerator SpawnParticles(Transform p_transform)
    {
        Object particles = Instantiate(prefab, p_transform.position, new Quaternion());
        yield return new WaitForSeconds(particleSystem.duration - 0.1f);
        Destroy(particles);
    }
}
