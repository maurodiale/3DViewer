// NO ESTA TERMINADO, NI IMPLEMENTADO
// La idea es hacer un script que haga un build personalizado, como elegir para que plataforma,
// en lo posible que le meta un icono y cree un instalador, y cosas así
// https://docs.unity3d.com/2020.2/Documentation/Manual/BuildPlayerPipeline.html
// https://gist.github.com/radiatoryang/b65e9c4807a64987aba2

using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class Build: MonoBehaviour
{
    //[MenuItem("CustomEditor/Compilar Linux")]
    public static void BuildApp()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] {"Assets/Scenes/MainMenu.unity", "Assets/Scenes/CasoDeEstudio.unity"};
        buildPlayerOptions.locationPathName = "/Builds";
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }
    }
    
}
