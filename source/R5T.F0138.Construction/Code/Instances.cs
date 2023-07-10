using System;


namespace R5T.F0138.Construction
{
    public static class Instances
    {
        public static IDotnetPackPathOperator DotnetPackPathOperator => F0138.DotnetPackPathOperator.Instance;
        public static T0215.Z000.IDotnetPackNames DotnetPackNames => T0215.Z000.DotnetPackNames.Instance;
        public static T0216.F001.IVersionedDirectoryPathOperator VersionedDirectoryPathOperator => T0216.F001.VersionedDirectoryPathOperator.Instance;
    }
}