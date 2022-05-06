namespace NorthWind.Presenters
{
    public class CreateOrderPresenter : IPresenter<int, string>
    {
        public string Content { get; private set; }

        public void Handler(int response)
        {
            Content = $"Order Id: {response}";
        }
    }
}
