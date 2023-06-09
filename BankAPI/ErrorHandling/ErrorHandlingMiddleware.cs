﻿using Microsoft.AspNetCore.Http.HttpResults;

namespace BankAPI.ErrorHandling
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NullReferenceException ex)
            {
                _logger.LogInformation(ex.Message.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
            }
        }
    }
}
