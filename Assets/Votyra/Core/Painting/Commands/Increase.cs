using Votyra.Core.Images;
using Votyra.Core.Logging;

namespace Votyra.Core.Painting.Commands
{
    public class IncreaseFactory : BaseFactory<Increase>
    {
        public IncreaseFactory(IEditableImage2f editableImage, IEditableMask2e editableMask, IThreadSafeLogger logger)
            : base(editableImage, editableMask, logger)
        {
        }

        public override string Action => KnownCommands.Increase;
    }

    public class Increase : PaintCommand
    {
        public Increase()
            : base(0)
        {
        }

        protected override float Invoke(float value, int distance) => value + 1;
    }
}