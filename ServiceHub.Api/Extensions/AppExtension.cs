namespace ServiceHub.Api.Extensions;

public static class AppExtension
{

    public static WebApplication UseResources(this WebApplication app)
    {
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        
        return app;
    }
    
}