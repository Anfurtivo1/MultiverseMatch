using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BotonesOpcionesNivelManager))]
[CanEditMultipleObjects]
[System.Serializable]
public class SetGameButtonEditor : Editor
{
    //Para poder crearnos un nuevo editor y manejar los botones de las cartas y estilo como se quieran, sobreescribimos esta funcion
    public override void OnInspectorGUI()
    {
        //
       DrawDefaultInspector();
        BotonesOpcionesNivelManager script = target as BotonesOpcionesNivelManager;

        switch (script.tipoBoton)
        {
            //
            case BotonesOpcionesNivelManager.TipoBoton.BotonCantidadCartas:
                script.cantidadCartas = (OpcionesNivelesManager.CantidadCartas) EditorGUILayout.EnumPopup("cantidadCartas",script.cantidadCartas);
                break;
            case BotonesOpcionesNivelManager.TipoBoton.BotonEstilo:
                script.estiloJuego = (OpcionesNivelesManager.EstiloJuego)EditorGUILayout.EnumPopup("estiloJuego", script.estiloJuego);
                break;
            default:
                break;
        }

        if (GUI.changed)
        {
            //Si se actualiza el GUI, esto se tiene que actualizar
            EditorUtility.SetDirty(target);
        }

    }
}
