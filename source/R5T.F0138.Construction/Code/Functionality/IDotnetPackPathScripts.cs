using System;

using R5T.T0132;


namespace R5T.F0138.Construction
{
    /// <summary>
    /// Scripts for working with dotnet pack paths (example: C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.18\ref\net6.0\).
    /// </summary>
    [FunctionalityMarker]
    public partial interface IDotnetPackPathScripts : IFunctionalityMarker
    {
        /// <summary>
        /// Given a .NET pack name, list the .NET versions available for it.
        /// </summary>
        public void List_VersionsForPack()
        {
            /// Input.
            var dotnetPackName = Instances.DotnetPackNames.Microsoft_NETCore_App_Ref;


            /// Run.
            //var versionedDirectoryPathsByVersion = Instances.
        }
    }
}
