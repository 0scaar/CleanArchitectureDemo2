using MediatR;

namespace NorthWind.UseCases.Common.Ports
{
    public interface IInputPort<TInteractorRequestType, TInteractorResponseType> : IRequest
    {
        public TInteractorRequestType RequestData { get; }
        public IOutputPort<TInteractorResponseType> OutputPort { get; }
    }
}
