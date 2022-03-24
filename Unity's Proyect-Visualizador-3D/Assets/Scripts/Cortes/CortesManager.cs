// podria ser util: https://www.youtube.com/watch?v=BVCNDUcnE1o
// para el shader nos basamos en: https://www.ronja-tutorials.com/
// Lo siguiente dice que combiene cambiar entre 2 materiales con != shader que cambian el shader
// https://stackoverflow.com/questions/48559523/how-can-i-switch-between-shaders-in-real-time
// podriamos instanciar un material con las propiedades del original y meterle otro shader
// pero quizas es lo mismo que el problema original

using UnityEngine;

public class CortesManager : MonoBehaviour
{
    [SerializeField] private CortesEventChannel OnCortesRequest;

    [SerializeField] private GameObject clippingPlane;

    private Selectable[] _list; // lista de objetos a los cuales cambiamos el material

    private bool _Started = false; // para saber si ya cambiamos los materiales

    [SerializeField] private Shader ClippingShader;

    private Shader StandardShader;

    private Shader TwoSided;

    private void Awake()
    {
        OnCortesRequest.OnCortesStartRequested += OnCortesStart;
        OnCortesRequest.OnCortesCancelRequested += OnCortesCancel;
        OnCortesRequest.OnCortesXYRequested += OnCorteXY;
        OnCortesRequest.OnCortesXZRequested += OnCorteXZ;
        OnCortesRequest.OnCortesYZRequested += OnCorteYZ;
        
        //cuando lo inicio así no funciona
        //clippingPlane = GetComponentInChildren<Transform>(true).gameObject;
    }

    private void Start()
    {
        _list = FindObjectsOfType<Selectable>();
        StandardShader = Shader.Find("Standard");
        TwoSided = Shader.Find("TwoSided");
        if(ClippingShader == null)
            ClippingShader = Shader.Find("Clipping_Plane_hueco");
    }

    private void OnDisable()
    {    
        OnCortesRequest.OnCortesStartRequested -= OnCortesStart;
        OnCortesRequest.OnCortesCancelRequested -= OnCortesCancel;
        OnCortesRequest.OnCortesXYRequested -= OnCorteXY;
        OnCortesRequest.OnCortesXZRequested -= OnCorteXZ;
        OnCortesRequest.OnCortesYZRequested -= OnCorteYZ;
    }

    private void OnCortesStart()
    {
        clippingPlane.SetActive(true);
    }

    private void OnCortesCancel()
    {
        clippingPlane.SetActive(false);
        ChangeToStandardShader();
        _Started = false;
    }

    private void OnCorteXY()
    {
        CheckStarted();
        transform.up = -Vector3.forward;
    }

    private void OnCorteXZ()
    {
        CheckStarted();
        transform.up = Vector3.up;
    }

    private void OnCorteYZ()
    {
        CheckStarted();
        transform.up = Vector3.right;
    }

    private void CheckStarted()
    {
        if(!_Started)
        {
            _Started = true;
            ChangeToClippingShader();
        }
    }

    private void ChangeToClippingShader()
    {
        foreach (var obj in _list)
        {
            //var mat = Instantiate<Material>(ClippingMaterial);
            //obj.meshRenderer.material = mat;
            //mat.color = obj.OriginalMaterials[0].color;
            //var materials = obj.meshRenderer.materials.ToList();
            obj.meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            foreach (var mat in obj.meshRenderer.sharedMaterials)
            {
                if(mat.name.Equals("OutlineMask (Instance)") || mat.name.Equals("OutlineFill (Instance)"))
                    continue;
                
                //var color = mat.color;
                mat.shader = ClippingShader;
            }
        }
    }

    private void ChangeToStandardShader()
    {
        foreach (var obj in _list)
        {
            //obj.meshRenderer.material = obj.OriginalMaterial;
            //obj.meshRenderer.materials = obj.OriginalMaterials;
            //var materials = obj.meshRenderer.materials.ToList();
            obj.meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

            foreach (var mat in obj.meshRenderer.sharedMaterials)
            {
                if(mat.name.Equals("OutlineMask (Instance)") || mat.name.Equals("OutlineFill (Instance)"))
                    continue;
                //mat.shader = StandardShader;
                mat.shader = TwoSided;
            }
        }
    }

    // Cuando salimos de la escena volvemos los materiales a la normalidad
    private void OnDestroy()
    {
        if(_Started)
        {
            OnCortesCancel();
        }
    }
}
