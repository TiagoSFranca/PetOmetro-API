using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetOmetro.Application.Exceptions;
using System;
using System.Net;

namespace PetOmetro.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private void MontarResponse(ref ExceptionContext context, int status, ResponseErrorViewModel objeto)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = status;

            context.Result = new JsonResult(objeto);
        }

        private void MontarNotFound(ref ExceptionContext context)
        {
            var objeto = new ResponseNotFoundViewModel(context.Exception);
            MontarResponse(ref context, (int)HttpStatusCode.NotFound, objeto);
        }

        private void MontarBadRequest(ref ExceptionContext context)
        {
            var objeto = new ResponseBadRequestViewModel(context.Exception);
            MontarResponse(ref context, (int)HttpStatusCode.BadRequest, objeto);
        }

        private void MontarInternalServerError(ref ExceptionContext context)
        {
            var objeto = new ResponseInternalServerErrorViewModel(context.Exception);
            MontarResponse(ref context, (int)HttpStatusCode.InternalServerError, objeto);
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ValidationException || context.Exception is BusinessException)
            {
                MontarBadRequest(ref context);
            }
            else if (context.Exception is NotFoundException)
            {
                MontarNotFound(ref context);
            }
            else if (context.Exception is PersistenceException)
            {
                MontarInternalServerError(ref context);
            }
            else
            {
                MontarInternalServerError(ref context);
            }

        }
    }
}
