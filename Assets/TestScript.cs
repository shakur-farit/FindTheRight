using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
	public float duration = 5f;
	public float strength = 1f;
	public int vibrato = 5;
	public float random = 180f;

    void Update()
    {
      if(Input.GetMouseButtonDown(0))
        DoShakeEffect(transform);
    }

	public void DoShakeEffect(Transform transform)
	{
		transform.DOShakePosition(duration,strength,vibrato,random);
	}
}