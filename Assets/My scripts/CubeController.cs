using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private Detonator _detonator;
    [SerializeField] private Cube _initialCube;

    private void OnEnable() => _initialCube.Clicked += HandleCubeClick;
    private void OnDisable() => _initialCube.Clicked -= HandleCubeClick;

    private void HandleCubeClick(Cube cube)
    {
        if (Random.value <= cube.CloneChance)
        {
            var bodies = _spawner.Spawn(cube.CloneChance, cube.transform);
            _detonator.ApplyForce(bodies, cube.transform.position);
        }

        cube.Clicked -= HandleCubeClick;
        Destroy(cube.gameObject);
    }

    public void RegisterCube(Cube cube)
    {
        cube.Clicked += HandleCubeClick;
    }
}