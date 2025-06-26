using GitClock.Common.Interfaces;
using GitClock.Common.Translations.Resources;
using GitClock.Common.Utils;
using Microsoft.AspNetCore.Http;

namespace GitClock.Common.Exceptions
{
    public class InvalidParameterValueException(string parameter)
    : Exception(Translation.GetTranslatedMessage(nameof(Messages.IvalidParameterValueException_detail), Translation.GetTranslatedMessage(parameter))),
            IHttpStatusCodeReturnable
    {
        public int StatusCode => StatusCodes.Status400BadRequest;
        public string ErrorDescription => nameof(Messages.IvalidParameterValueException_error);
    }
}
