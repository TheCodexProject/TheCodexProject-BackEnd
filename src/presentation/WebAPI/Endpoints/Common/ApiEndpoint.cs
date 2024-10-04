using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Endpoints.Common;

public static class ApiEndpoint
{
    /// <summary>
    /// This class is used for endpoints that require a request.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public static class WithRequest<TRequest>
    {
        /// <summary>
        /// This marks the endpoint as one that requires a request and returns a response.
        /// </summary>
        /// <typeparam name="TResponse">The type of response that is sent to the user.</typeparam>
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request);
        }

        /// <summary>
        /// This marks the endpoint as one that requires a request and does not return a response.
        /// </summary>
        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync(TRequest request);
        }
    }

    /// <summary>
    /// This class is used for endpoints that do not require a request.
    /// </summary>
    public static class WithoutRequest
    {
        /// <summary>
        /// This marks the endpoint as one that does not require a request and returns a response.
        /// </summary>
        /// <typeparam name="TResponse">The type of response that is sent to the user.</typeparam>
        public abstract class WithResponse<TResponse> : EndpointBase
        {
            public abstract Task<ActionResult<TResponse>> HandleAsync();
        }

        /// <summary>
        /// This marks the endpoint as one that does not require a request and does not return a response.
        /// </summary>
        public abstract class WithoutResponse : EndpointBase
        {
            public abstract Task<ActionResult> HandleAsync();
        }
    }
}

[ApiController, Route("api")]
public abstract class EndpointBase : ControllerBase;