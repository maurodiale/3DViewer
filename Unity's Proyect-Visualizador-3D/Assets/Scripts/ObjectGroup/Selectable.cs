using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Selectable : MonoBehaviour
{
    [SerializeField] private SelectEventChannel SelectEventRequest = default;
    [SerializeField] private UnSelectEventChannel UnSelectEventRequest = default;
    [SerializeField] private UnSelectAllEventChannel UnSelectAllEventRequest = default;
    [SerializeField] private ResetTransformEventChannel ResetTransformEventRequest = default;
    [SerializeField] private DespieceEventChannel DespieceEventRequest = default;

    public MeshRenderer meshRenderer; // poner getter and setter

    //public Material[] OriginalMaterials; // material original

    public bool _isGrouped = false; // poner getter and setter
    
    // Usamos una interfaz para no depender de una clase en particular y poder alterar el comportamiento de la selección sin tener que cambiar este script
    private ISelectionResponse _selectionResponse; // Encargado del resolver la selección

    // Despiece
    private float _timeToDespiece;

    private Vector3 _target; // posicion final en despiece

    private bool _isDespiece = false;

    private Vector3 despieceSmoothDampVel;

    private float timeChange;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnEnable()
    {
        SelectEventRequest.OnGroupRequested += GroupRequest;
        UnSelectEventRequest.OnUnGroupRequested += UnGroupRequest;
        UnSelectAllEventRequest.OnUnGroupAllRequested += UnGroupAllRequest;
        ResetTransformEventRequest.OnResetTransformRequested += ResetRequest;
        DespieceEventRequest.OnDespieceRequested += DespieceRequest;
    }

    private void OnDisable()
    {
        SelectEventRequest.OnGroupRequested -= GroupRequest;
        UnSelectEventRequest.OnUnGroupRequested -= UnGroupRequest;
        UnSelectAllEventRequest.OnUnGroupAllRequested -= UnGroupAllRequest;
        ResetTransformEventRequest.OnResetTransformRequested -= ResetRequest;
        DespieceEventRequest.OnDespieceRequested -= DespieceRequest;
    }

    private void Start()
    {
        //DataManager.InitializeGeoTransform(transform); // comentar y descomentar cuando cambiamos a Spawner
    }

    private void GroupRequest(GameObject obj, Transform parent)
    {
        bool condition = GameObject.ReferenceEquals(gameObject, obj);
        if(!_isGrouped && condition)
        {
            _selectionResponse.OnSelect(this, parent);
        }
    }

    private void UnGroupRequest(GameObject obj)
    {
        bool condition = GameObject.ReferenceEquals(gameObject, obj);
        if(_isGrouped && condition)
        {
            _selectionResponse.OnDeselect(this);
        }
    }

    private void UnGroupAllRequest()
    {
        if(_isGrouped)
        {
            _selectionResponse.OnDeselect(this);
        }
    }

    private void ResetRequest()
    {
        if(_isDespiece) return; // no se puede resetear hasta que termine despiece
        Geometry geo = DataManager.GetGeometryByName(gameObject.name);
        //Geometry geo = DataManager.GetGeometryByID(gameObject.GetInstanceID());
        transform.position = geo.geoPosition;
        transform.rotation = geo.geoRotation;
        UnGroupAllRequest();
    }

    private void DespieceRequest(float FactorDespiece, float timeToDespiece)
    {
        if(_isDespiece) return;
        _timeToDespiece = timeToDespiece;
        Vector3 direction = transform.position - DataManager.GetCenterPoint();
        float module = direction.magnitude; // cuanto más lejos, más se desplaza
        direction.Normalize();

        _target = transform.position + direction * module * FactorDespiece;
        timeChange = timeToDespiece + 0.5f;
        _isDespiece = true;
    }

    private void Update()
    {
        if(_isDespiece)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _target, ref despieceSmoothDampVel, _timeToDespiece);
            if(timeChange < 0)
                _isDespiece = false;
            else
                timeChange -= Time.deltaTime;
        }
    }

    public void SetChannels(SelectEventChannel SEC, UnSelectEventChannel USEC, UnSelectAllEventChannel USAEC, ResetTransformEventChannel RTEC, DespieceEventChannel DEC)
    {
        SelectEventRequest = SEC;
        UnSelectEventRequest = USEC;
        UnSelectAllEventRequest = USAEC;
        ResetTransformEventRequest = RTEC;
        DespieceEventRequest = DEC;
    }
}