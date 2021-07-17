using SaveLoadCore.Controllers;
using SaveLoadCore.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Kwicot.Controllers
{
    public class TESTSCRIPT : MonoBehaviour
    {
        public GameObject prefab;
        public bool Load = false;

        private void Start()
        {
            if(Load) SaveLoadController.instance.LoadData();
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    var pos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
                    gameObject.Create(prefab, pos);
                }
            }
        }


        private void OnDisable()
        {
            SaveLoadController.instance.SaveData();
        }
    }
}