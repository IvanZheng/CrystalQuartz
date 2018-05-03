namespace CrystalQuartz.WebFramework
{
    using CrystalQuartz.WebFramework.HttpAbstractions;
    using CrystalQuartz.WebFramework.Request;

    public class RunningApplication
    {
        private readonly IRequestHandler[] _handlers;

        public RunningApplication(IRequestHandler[] handlers)
        {
            _handlers = handlers;
        }

        public RequestHandlingResult Handle(IRequest request, IResponseRenderer renderer)
        {
            RequestHandlingResult finalRequestHandlingResult = RequestHandlingResult.NotHandled;
            
            foreach (IRequestHandler handler in _handlers)
            {
                RequestHandlingResult result = handler.HandleRequest(request);
                if (result.IsHandled)
                {
                    renderer.Render(result.Response);
                    return result;
                }
            }
            return finalRequestHandlingResult;
        }
    }
}