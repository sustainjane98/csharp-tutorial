using ExampleWebApplication.Dtos;
using ExampleWebApplication.Models.Dtos;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace ExampleWebApplication.Configs;

public static class ODataConfigurator
{

    public static void AddOData(this WebApplicationBuilder webApplicationBuilder, string route = "api")
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Pokemon>(nameof(Pokemon));
        builder.EntitySet<Category>(nameof(Category));
        builder.EntitySet<Owner>(nameof(Owner));
        builder.EntitySet<Review>(nameof(Review));
        builder.EntitySet<Reviewer>(nameof(Reviewer));

        webApplicationBuilder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents(route, builder.GetEdmModel()));
    }

    
    
}