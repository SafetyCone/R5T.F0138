using System;


namespace R5T.F0138
{
    public static class Instances
    {
        public static F0140.IDocumentationXmlFilePathOperator DocumentationXmlFilePathOperator => F0140.DocumentationXmlFilePathOperator.Instance;
        public static T0214.Z001.IDotnetPacksDirectoryPaths DotnetPacksDirectoryPaths => T0214.Z001.DotnetPacksDirectoryPaths.Instance;
        public static IDotnetPackDirectoryNameOperator DotnetPackDirectoryNameOperator => F0138.DotnetPackDirectoryNameOperator.Instance;
        public static T0214.Z001.IDotnetPackDirectoryNames DotnetPackDirectoryNames => T0214.Z001.DotnetPackDirectoryNames.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static T0217.F001.ITargetFrameworkDirectoryNameOperator TargetFrameworkDirectoryNameOperator => T0217.F001.TargetFrameworkDirectoryNameOperator.Instance;
        public static F0139.ITargetFrameworkMonikerOperator TargetFrameworkMonikerOperator => F0139.TargetFrameworkMonikerOperator.Instance;
        public static T0159.ITextOutputOperator TextOutputOperator => T0159.TextOutputOperator.Instance;
        public static T0216.F001.IVersionedDirectoryNameOperator VersionedDirectoryNameOperator => T0216.F001.VersionedDirectoryNameOperator.Instance;
        public static T0216.F001.IVersionedDirectoryPathOperator VersionedDirectoryPathOperator => T0216.F001.VersionedDirectoryPathOperator.Instance;
        public static L0035.IVersionOperator VersionOperator => L0035.VersionOperator.Instance;
    }
}