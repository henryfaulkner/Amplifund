using Amplifund.Assignment.API.Core;
using Amplifund.Assignment.BL.Common;
using Amplifund.Assignment.BL.Grants;

var builder = Starter.CreateAPIBuilder(args);

builder.ConfigureAPIService();

builder.Services.AddCommonBusiness();

builder.Services.AddGrantsBusiness();

builder.RunApp();
