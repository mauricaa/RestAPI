var builder = WebApplication.CreateBuilder(args); //erstellt eine neue Webanwendung

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy => 
    {
        policy.WithOrigins("http://127.0.0.1:5500")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers(); //fügt Controller-Unterstützung hinzu
builder.Services.AddEndpointsApiExplorer(); //ermöglicht das erkunden von API Endpunkten (für swagger)
builder.Services.AddSwaggerGen(); //aktiviert swagger

var app = builder.Build(); //erstellt anwendung aus der konfiguration im builder 

app.UseCors("AllowLocalhost"); //aktivert die zuvor definierte CORS-Regel (AllowLocalhost)

if (app.Environment.IsDevelopment()) 
{                                       //nur im entwicklungsmodus wird swagger aktiviert
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();      //leitet HTTP auf HTTPS um
app.UseAuthorization();

app.MapControllers();

app.Run();          //startet den webserver