using NorthWind.UseCases.Common.Ports;

namespace NorthWind.Presenters
{
    public interface IPresenter<ResponseType, FormatType> : IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}
