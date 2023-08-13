using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0159;
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
        public IDocumentationXmlFilePath[] Get_DocumentationXmlFilePaths(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("{0} ({1}): Getting documentation XML file paths...",
                dotnetPackName,
                targetFrameworkMoniker);

            var dotnetPackDirectoryPath = this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                targetFrameworkMoniker,
                textOutput);

            // Safe to assume that all XML files in the directory will be documentation files.
            var documentationFilePaths = Instances.DocumentationXmlFilePathOperator.Get_DocumentationXmlFilePaths_AssumeAllXmls(
                dotnetPackDirectoryPath,
                textOutput);

            textOutput.WriteInformation("{0} ({1}): Got documentation XML file paths, count: {2}.",
                dotnetPackName,
                targetFrameworkMoniker,
                documentationFilePaths.Length);

            return documentationFilePaths;
        }

        public IDocumentationXmlFilePath[] Get_DocumentationXmlFilePaths(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_DocumentationXmlFilePaths(
                dotnetPackName,
                targetFrameworkMoniker,
                textOutput);
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
            IDotnetPackName dotnetPackName,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("{0}: Getting dotnet pack root directory path for dotnet pack...", dotnetPackName);

            var dotnetPackDirectoryName = Instances.DotnetPackDirectoryNameOperator.Get_DotnetPackDirectoryName(dotnetPackName);

            var output = this.Get_DotnetPackRootDirectoryPath(
                Instances.DotnetPacksDirectoryPaths.Windows,
                dotnetPackDirectoryName);

            textOutput.WriteInformation("{0}: dotnet pack root directory path:\n\t{1}", dotnetPackName, output);

            return output;
        }

        public T0214.N001.IDotnetPackRootDirectoryPath Get_DotnetPackRootDirectoryPath(
            IDotnetPackName dotnetPackName)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_DotnetPackRootDirectoryPath(
                dotnetPackName,
                textOutput);
        }

        public T0214.N001.IVersionedDotnetPackDirectoryPath[] Get_VersionedDotnetPackDirectoryPaths(T0214.N001.IDotnetPackRootDirectoryPath dotnetPackRootDirectoryPath)
        {
            var output = Instances.FileSystemOperator.EnumerateAllChildDirectoryPaths(
                dotnetPackRootDirectoryPath.Value)
                .Select(x => x.ToVersionedDotnetPackDirectoryPath())
                .Now();

            return output;
        }

        public T0214.N001.IVersionedDotnetPackDirectoryPath[] Get_VersionedDotnetPackDirectoryPaths(
            IDotnetPackName dotnetPackName,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("{0}: Getting versioned dotnet pack directory paths for dotnet pack...", dotnetPackName);

            var dotnetPackRootDirectoryPath = this.Get_DotnetPackRootDirectoryPath(
                dotnetPackName,
                textOutput);

            var output = this.Get_VersionedDotnetPackDirectoryPaths(dotnetPackRootDirectoryPath);

            textOutput.WriteInformation("{0} (Count: {1}): Got versioned dotnet pack directory paths.", dotnetPackName, output.Length);

            return output;
        }

        public T0214.N001.IVersionedDotnetPackDirectoryPath[] Get_VersionedDotnetPackDirectoryPaths(
            IDotnetPackName dotnetPackName)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_VersionedDotnetPackDirectoryPaths(
                dotnetPackName,
                textOutput);
        }

        public IDictionary<Version, T0214.N001.IVersionedDotnetPackDirectoryPath> Get_VersionedPackDirectoryPathsByVersion(
            IDotnetPackName dotnetPackName,
            ITextOutput textOutput)
        {
            var versionedDirectoryPaths = this.Get_VersionedDotnetPackDirectoryPaths(
                dotnetPackName,
                textOutput);

            var output = Instances.VersionedDirectoryPathOperator.Get_VersionedDirectoryPathsByVersion(versionedDirectoryPaths);
            return output;
        }

        public IDictionary<Version, T0214.N001.IVersionedDotnetPackDirectoryPath> Get_VersionedPackDirectoryPathsByVersion(
            IDotnetPackName dotnetPackName)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_VersionedPackDirectoryPathsByVersion(
                dotnetPackName,
                textOutput);
        }

        /// <summary>
        /// Given a dotnet pack name and a target framework moniker, get the dotnet pack directory path.
        /// This requires querying the file system for the versions available for a dotnet pack.
        /// </summary>
        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("{0} ({1}): Getting dotnet pack directory path...",
                dotnetPackName,
                targetFrameworkMoniker);

            var versionedDirectoryPathsByVersion = this.Get_VersionedPackDirectoryPathsByVersion(
                dotnetPackName,
                textOutput);

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

            textOutput.WriteInformation("{0} ({1}): Dotnet pack directory path:\n\t{2}'",
                dotnetPackName,
                targetFrameworkMoniker,
                dotnetPackDirectoryPath);

            return dotnetPackDirectoryPath;
        }

        public IDotnetPackDirectoryPath Get_DotnetPackDirectoryPath(
            IDotnetPackName dotnetPackName,
            ITargetFrameworkMoniker targetFrameworkMoniker)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                targetFrameworkMoniker,
                textOutput);
        }
    }
}
