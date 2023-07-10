using System;


namespace R5T.F0138
{
    public class DotnetPackDirectoryNameOperator : IDotnetPackDirectoryNameOperator
    {
        #region Infrastructure

        public static IDotnetPackDirectoryNameOperator Instance { get; } = new DotnetPackDirectoryNameOperator();


        private DotnetPackDirectoryNameOperator()
        {
        }

        #endregion
    }
}
