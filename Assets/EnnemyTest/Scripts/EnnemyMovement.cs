using System.Collections;
using UnityEngine;

public enum MouvementConfig
{
    // fait une boucle d'arriver et ensuite ne bouge pas
    Stable,
    // repete la boucle d'arriver en boucle
    Loop,
    // fait une boucle d'arriver et ensuite fait une autre boucle de mouvement
    StableAndLoop,
}

public class EnnemyMovement : MonoBehaviour
{
    public MouvementConfig MouvementConfig;
    
    [SerializeField] public Vector3[] positionArrayLoop;
    
    [SerializeField] private Vector3[] _positionArraySecondeLoop;
    
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private float _distanceChangeIndex;

    private bool _doFistLoop = false;
    private bool _doSecondeLoop = false;
    int _index = 1;

    

    private void Start()
    {
        transform.position = positionArrayLoop[0];
    }

    private void LateUpdate()
    {
        if (!_doFistLoop)
        {
            Movement(positionArrayLoop, MouvementConfig);
        }

        if (_doSecondeLoop)
        {
            Movement(_positionArraySecondeLoop, MouvementConfig.Loop);
        }
    }
    
    
    private void Movement(Vector3[] positionArray, MouvementConfig mouvementConfig = MouvementConfig.Stable)
    {
        if (Vector3.Distance(transform.position, positionArray[_index]) < _distanceChangeIndex)
        {
            if (_index + 1 >= positionArray.Length)
            {
                if (mouvementConfig == MouvementConfig.Stable)
                {
                    _doFistLoop = true;
                }
                else if (mouvementConfig == MouvementConfig.Loop)
                {
                    _index = 0;
                }
                else
                {
                    _index = 0;
                    _doFistLoop = true;
                    _doSecondeLoop = true;
                }
            }
            else
            {
                _index++;
            }
        }
        transform.position = Vector3.Lerp(transform.position, positionArray[_index], _smoothSpeed * Time.deltaTime);
    }
}
