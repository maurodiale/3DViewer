using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CortesManagerV2 : MonoBehaviour
{
    [SerializeField] private CortesEventChannel OnCortesRequest;

    [SerializeField] private SelectedRuntimeSet Set;

    [SerializeField] private Material ClippingMaterial;

    [SerializeField] private GameObject clippingPlane;

    private void Awake()
    {
        OnCortesRequest.OnCortesStartRequested += OnCortesStart;
        OnCortesRequest.OnCortesCancelRequested += OnCortesCancel;
    }

    private void OnDisable()
    {
        OnCortesRequest.OnCortesStartRequested -= OnCortesStart;
        OnCortesRequest.OnCortesCancelRequested -= OnCortesCancel;
    }

    private void OnCortesStart()
    {
        // activar el clipping plane
        // cambiar el material de los objetos seleccionados
        ChangeToClippingMaterial();
        clippingPlane.SetActive(true);
    }

    private void ChangeToClippingMaterial()
    {
        foreach (GameObject obj in Set.Items)
        {
            MeshRenderer rend = obj.GetComponent<Selectable>().meshRenderer;
            rend.material = ClippingMaterial;
        }
    }

    private void OnCortesCancel()
    {
        // desactivar el clipping plane
        // cambiar el material
        clippingPlane.SetActive(false);
    }

    

}
