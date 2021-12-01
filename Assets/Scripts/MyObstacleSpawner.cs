using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObstacleSpawner : MonoBehaviour
{

	[SerializeField] GameObject[] hindernisse;
	List<GameObject> hindernisseZumErscheinen = new List<GameObject>();

	// Use this for initialization
	
	
	void Awake()
    {
		InitialisiereHindernisse();
	}

	
	void Start()
	{
		StartCoroutine (SpawnRandomObstacle());
	}


	void InitialisiereHindernisse()
	{
		int index = 0;
		for (int i = 0; i < hindernisse.Length * 3; i++)
		{
			GameObject obj = Instantiate(hindernisse[index], transform.position, Quaternion.identity);
			hindernisseZumErscheinen.Add(obj);
			hindernisseZumErscheinen[i].SetActive(false);
			index++;
			if (index == hindernisse.Length)
			{
				index = 0;
			}
		}
	}

	IEnumerator SpawnRandomObstacle()
	{
		yield return new WaitForSeconds(Random.Range(1.5f, 4.5f));

		int index = Random.Range(0, hindernisseZumErscheinen.Count);

		while (true)
		{
			if (!hindernisseZumErscheinen[index].activeInHierarchy)
			{
				hindernisseZumErscheinen[index].SetActive(true);
				hindernisseZumErscheinen[index].transform.position = transform.position;
				break;
			}

			else
			{
				index = Random.Range(0, hindernisseZumErscheinen.Count);
			}
		}

		StartCoroutine(SpawnRandomObstacle());
	
	}
}