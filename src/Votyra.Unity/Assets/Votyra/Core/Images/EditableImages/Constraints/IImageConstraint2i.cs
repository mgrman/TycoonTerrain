using Votyra.Core.Models;

namespace Votyra.Core.Images.EditableImages.Constraints
{
    public interface IImageConstraint2i
    {
        SampledData2i Process(SampledData2i sampleData);
    }
}