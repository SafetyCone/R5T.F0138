using System;

using R5T.T0132;
using R5T.T0214.N001;
using R5T.T0214.N001.Extensions;
using R5T.T0215;


namespace R5T.F0138
{
    [FunctionalityMarker]
    public partial interface IDotnetPackDirectoryNameOperator : IFunctionalityMarker
    {
        public IDotnetPackDirectoryName Get_DotnetPackDirectoryName(IDotnetPackName dotnetPackName)
        {
            // The directory name is just the pack name.
            var output = dotnetPackName.Value
                .ToDotnetPackDirectoryName();

            return output;
        }
    }
}
