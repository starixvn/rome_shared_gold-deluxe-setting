namespace Fanex.GoldDeluxe.CoreSetting.Services
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IGoldDeluxeAuthorizationService
    {
        bool IsAuthorizedRead(AuthorizationContext authorizationContext, int custId, string username);

        bool IsAuthorizedHost(AuthorizationContext authorizationContext, int custId, string username);

        bool IsAuthorizedReadMultiple(AuthorizationContext authorizationContext, IEnumerable<string> usernames);

        bool IsAuthorizedHostMultiple(AuthorizationContext authorizationContext, IEnumerable<string> usernames);
    }
}
