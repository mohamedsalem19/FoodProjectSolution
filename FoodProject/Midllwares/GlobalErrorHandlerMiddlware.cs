

using FoodProject.Models.Enums;
using FoodProject.ViewModels;

namespace FoodProject.Midllwares
{
    public class GlobalErrorHandlerMiddlware
    {
        RequestDelegate _nextAction;
        ILogger<GlobalErrorHandlerMiddlware> _logger;
        public GlobalErrorHandlerMiddlware(RequestDelegate nextAction, ILogger<GlobalErrorHandlerMiddlware> logger)
        {
            _nextAction = nextAction;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _nextAction(context);
            }
            catch (Exception ex)
            {

                File.WriteAllText("D:\\Logs.Txt", $"Error Ocuerd {ex.Message}");
                _logger.LogError(ex.Message);
                var response = new FailureResponseViewModel<bool>(ErrorCode.None);
                context.Response.WriteAsJsonAsync(response);
            }
        }

    }
}
