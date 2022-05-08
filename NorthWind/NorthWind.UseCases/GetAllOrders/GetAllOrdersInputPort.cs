using NorthWind.UseCases.Common.Ports;
using NorthWind.UseCasesDTOs.GetAllOrders;

namespace NorthWind.UseCases.GetAllOrders
{
    public class GetAllOrdersInputPort : IInputPort<GetAllOrdersParams, GetAllOrdersOutputPort>
    {
        public GetAllOrdersParams RequestData { get; }
        public IOutputPort<GetAllOrdersOutputPort> OutputPort { get; }

        public GetAllOrdersInputPort(GetAllOrdersParams requestData, IOutputPort<GetAllOrdersOutputPort> outputPort)
        {
            RequestData = requestData;
            OutputPort = outputPort;
        }
    }
}
