using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct PoolObject{
	public string key;
	public Transform prefab;
	public int initialSize;
}
public class UberPool : MonoBehaviour {
	public bool m_Growing;
	public PoolObject[] m_PooledPrefabs;
	public static UberPool SharedInstance;
	public Dictionary<string, List<Transform>> m_Pool;
	void Awake() {
		if(SharedInstance == null){
            SharedInstance = this;
            PopulatePool();
		}
	}
	void PopulatePool(){
		m_Pool = new Dictionary<string, List<Transform>>();
		for(int i = 0; i < m_PooledPrefabs.Length; i++){
			List<Transform> prefabList = new List<Transform>();
			m_Pool[m_PooledPrefabs[i].key] = prefabList;
			for(int j = 0; j < m_PooledPrefabs[i].initialSize; j++){
				Transform newObject = Instantiate(m_PooledPrefabs[i].prefab, transform);
                newObject.gameObject.SetActive(false);
                prefabList.Add(newObject);
			}
		}
	}
	public Transform GetObject(string key){
        Transform retVal = FindNextAvailable(key);
		if(retVal == null){
			if(m_Growing){
				retVal = GrowPool(key);
			}
		}
		if(retVal != null){
			retVal.gameObject.SetActive(true);
		}
		return retVal;
	}
	private Transform FindNextAvailable(string key){
        Transform retVal = null;
		foreach(Transform o in m_Pool[key]){
			if(!o.gameObject.activeInHierarchy){
				retVal = o;
				break;
			}
		}
		return retVal;
	}
	private Transform GrowPool(string key){
		int foundIndex = -1;
		for(int i = 0; i < m_PooledPrefabs.Length; i++){
			if(m_PooledPrefabs[i].key == key){
				foundIndex = i;
				break;
			}
		}
		Transform freshObject = Instantiate(m_PooledPrefabs[foundIndex].prefab, transform);
		m_Pool[key].Add(freshObject);
		return freshObject;
	}
}
