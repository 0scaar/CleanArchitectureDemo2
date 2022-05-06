namespace NorthWind.UseCases.Common.Ports
{
    public interface IOutputPort<TInteractorResponseType>
    {
        void Handler(TInteractorResponseType response);
    }
}
