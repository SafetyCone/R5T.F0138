using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0172;
using R5T.T0214;
using R5T.T0214.Extensions;
using R5T.T0214.N001.Extensions;
using R5T.T0215;
using R5T.T0217;
using R5T.T0218;


namespace R5T.F0138
{
    /// <summary>
    /// Path operator for dotnet framework core library pack paths.
    /// Example: C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\6.0.18\ref\net6.0
    /// </summary>
    [FunctionalityMarker]
    public partial interface IDotnetPackPathOperator : IFunctionalityMarker
    {
        public IDocumentationXmlFilePath[] GetDocumentationXmlFilePaths(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var dotnetPackDirectoryPath = this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                targetFrameworkMoniker);

            // Safe to assume that all XML files in the directory will be documentation files.
            var documentationFilePaths = Instances.DocumentationXmlFilePathOperator.Get_DocumentationXmlFilePaths_AssumeAllXmls(
                dotnetPackDirectoryPath);

            return documentationFilePaths;
        }

        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            T0214.N001.IDotnetPacksDirectoryPath dotnetPacksDirectoryPath,
            T0214.N001.IDotnetPackDirectoryName dotnetPackDirectoryName,
            T0216.N001.IMajorMinorPatchVersionedDirectoryName majorMinorPatchVersionedDirectoryName,
            ITargetFrameworkDirectoryName targetFrameworkDirectoryName)
        {
            var output = Instances.PathOperator.GetDirectoryPath(
                dotnetPacksDirectoryPath.Value,
                dotnetPackDirectoryName.Value,
                majorMinorPatchVersionedDirectoryName.Value,
                Instances.DotnetPackDirectoryNames.Ref.Value,
                targetFrameworkDirectoryName.Value)
                .ToDotnetPackDirectoryPath();

            return output;
        }

        /// <summary>
        /// Uses the <see cref="T0214.Z001.IDotnetPacksDirectoryPaths.Windows"/> value for the dotnet packs directory path.
        /// </summary>
        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            T0214.N001.IDotnetPackDirectoryName dotnetPackDirectoryName,
            T0216.N001.IMajorMinorPatchVersionedDirectoryName majorMinorPatchVersionedDirectoryName,
            ITargetFrameworkDirectoryName targetFrameworkDirectoryName)
        {
            return this.Get_DotnetPackDirectoryPath(
                Instances.DotnetPacksDirectoryPaths.Windows,
                dotnetPackDirectoryName,
                majorMinorPatchVersionedDirectoryName,
                targetFrameworkDirectoryName);
        }

        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            T0215.IDotnetPackName dotnetPackName,
            T0216.N001.IMajorMinorPatchVersionedDirectoryName majorMinorPatchVersionedDirectoryName,
            ITargetFrameworkDirectoryName targetFrameworkDirectoryName)
        {
            var dotnetPackDirectoryName = Instances.DotnetPackDirectoryNameOperator.Get_DotnetPackDirectoryName(dotnetPackName);

            return this.Get_DotnetPackDirectoryPath(
                dotnetPackDirectoryName,
                majorMinorPatchVersionedDirectoryName,
                targetFrameworkDirectoryName);
        }

        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            T0215.IDotnetPackName dotnetPackName,
            T0216.N001.IMajorMinorPatchVersionedDirectoryName majorMinorPatchVersionedDirectoryName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var targetFrameworkDirectoryName = Instances.TargetFrameworkDirectoryNameOperator.Get_TargetFrameworkDirectoryName(targetFrameworkMoniker);

            return this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                majorMinorPatchVersionedDirectoryName,
                targetFrameworkDirectoryName);
        }

        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            T0215.IDotnetPackName dotnetPackName,
            T0185.IVersionName versionName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var versionedDirectoryName = Instances.VersionedDirectoryNameOperator.Get_VersionedDirectoryName(versionName);

            return this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                versionedDirectoryName,
                targetFrameworkMoniker);
        }

        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            T0215.IDotnetPackName dotnetPackName,
            Version version,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var versionName = Instances.VersionOperator.ToVersionName(version);

            return this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                versionName,
                targetFrameworkMoniker);
        }

        public T0214.N001.IDotnetPackRootDirectoryPath Get_DotnetPackRootDirectoryPath(
            T0214.N001.IDotnetPacksDirectoryPath dotnetPacksDirectoryPath,
            T0214.N001.IDotnetPackDirectoryName dotnetPackDirectoryName)
        {
            var output = Instances.PathOperator.GetDirectoryPath(
                dotnetPacksDirectoryPath.Value,
                dotnetPackDirectoryName.Value)
                .ToDotnetPackRootDirectoryPath();

            return output;
        }

        public T0214.N001.IDotnetPackRootDirectoryPath Get_DotnetPackRootDirectoryPath(
            T0215.IDotnetPackName dotnetPackName)
        {
            var dotnetPackDirectoryName = Instances.DotnetPackDirectoryNameOperator.Get_DotnetPackDirectoryName(dotnetPackName);

            var output = this.Get_DotnetPackRootDirectoryPath(
                Instances.DotnetPacksDirectoryPaths.Windows,
                dotnetPackDirectoryName);

            return output;
        }

        public T0214.N001.IVersionedDotnetPackDirectoryPath[] Get_VersionedDotnetPackDirectoryPaths(T0214.N001.IDotnetPackRootDirectoryPath dotnetPackRootDirectoryPath)
        {
            var output = Instances.FileSystemOperator.EnumerateAllChildDirectoryPaths(
                dotnetPackRootDirectoryPath.Value)
                .Select(x => x.ToVersionedDotnetPackDirectoryPath())
                .Now();

            return output;
        }

        public T0214.N001.IVersionedDotnetPackDirectoryPath[] Get_VersionedDotnetPackDirectoryPaths(T0215.IDotnetPackName dotnetPackName)
        {
            var dotnetPackRootDirectoryPath = this.Get_DotnetPackRootDirectoryPath(dotnetPackName);

            var output = this.Get_VersionedDotnetPackDirectoryPaths(dotnetPackRootDirectoryPath);
            return output;
        }

        public IDictionary<Version, T0214.N001.IVersionedDotnetPackDirectoryPath> Get_VersionedPackDirectoryPathsByVersion(T0215.IDotnetPackName dotnetPackName)
        {
            var versionedDirectoryPaths = this.Get_VersionedDotnetPackDirectoryPaths(dotnetPackName);

            var output = Instances.VersionedDirectoryPathOperator.Get_VersionedDirectoryPathsByVersion(versionedDirectoryPaths);
            return output;
        }

        /// <summary>
        /// Given a dotnet pack name and a target framework moniker, get the dotnet pack directory path.
        /// This requires querying the file system for the versions available for a dotnet pack.
        /// </summary>
        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var versionedDirectoryPathsByVersion = this.Get_VersionedPackDirectoryPathsByVersion(
                dotnetPackName);

            var dotnetMajorVersion = Instances.TargetFrameworkMonikerOperator.Get_DotnetMajorVersion(targetFrameworkMoniker);

            var highestSubVersion = Instances.VersionOperator.Choose_HighestSubVersionOf(
                versionedDirectoryPathsByVersion.Keys,
                dotnetMajorVersion);

            if(highestSubVersion is null)
            {
                throw new Exception($"No subversions found for dotnet pack '{dotnetPackName}', major version {dotnetMajorVersion}.");
            }

            var dotnetPackDirectoryPath = this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                highestSubVersion,
                targetFrameworkMoniker);

            return dotnetPackDirectoryPath;
        }
    }
}
