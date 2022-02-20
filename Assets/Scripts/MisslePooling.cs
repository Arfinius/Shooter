using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class MisslePooling : MonoBehaviour
    { 

        public static MisslePooling Instance { get { return _instance; } }
        private static MisslePooling _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(this);
            }
            _instance = this;
        }

        #region variables
        [SerializeField]
        protected GameObject poolingObject;

        [SerializeField]
        protected List<Missle> poolingObjects = new List<Missle>();

        #endregion

        #region PoolingBase methods
        public void AddObjectToPool(Missle obj)
        {
            if (poolingObjects.Exists(x => x.Equals(obj)))
            {
                return;
            }
            poolingObjects.Add(obj);
        }

        public void RemoveObjectFromPool(Missle obj)
        {
            poolingObjects.Remove(obj);
        }
        public void RemoveObjectFromPool(int index)
        {
            poolingObjects.RemoveAt(index);
        }

        public Missle GetObjectFromPool(int index)
        {
            return poolingObjects[index];
        }
        public Missle GetActiveObjectFromPool()
        {
            foreach (var obj in poolingObjects)
            {
                if (obj.gameObject.activeSelf)
                    return obj;
            }
        Missle newObj = CreateObjectInPool();
            newObj.gameObject.SetActive(true);
            return newObj;
        }
        public Missle GetInactiveObjectFromPool()
        {
            foreach (var obj in poolingObjects)
            {
                if (!obj.gameObject.activeSelf)
                {
                    obj.transform.position = Vector3.zero;
                    obj.transform.rotation = Quaternion.identity;
                    return obj;
                }
            }
            return CreateObjectInPool();
        }
        protected Missle CreateObjectInPool()
        {
            GameObject newObj = Instantiate(poolingObject, new Vector3(0, 0, 0), Quaternion.identity, transform);
            newObj.transform.name = typeof(Missle).ToString() + poolingObjects.Count.ToString();
            Missle missObj = newObj.GetComponent<Missle>();
            newObj.SetActive(false);
            AddObjectToPool(missObj);
            return missObj;
        }

        #endregion
    }



