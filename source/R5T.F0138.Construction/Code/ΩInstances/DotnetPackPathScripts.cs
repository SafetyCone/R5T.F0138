using System;


namespace R5T.F0138.Construction
{
    public class DotnetPackPathScripts : IDotnetPackPathScripts
    {
        #region Infrastructure

        public static IDotnetPackPathScripts Instance { get; } = new DotnetPackPathScripts();


        private DotnetPackPathScripts()
        {
        }

        #endregion
    }
}
