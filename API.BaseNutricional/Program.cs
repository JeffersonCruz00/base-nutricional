using WebApi.BaseNutricional.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapPost("/TaxaMetabolicaBasal", (Pessoa pessoa) =>
{
    double calorias = 0;
    if (char.ToUpper(pessoa.genero) == 'M')
    {
        calorias = 88.362 + (13.397 * Convert.ToDouble(pessoa.peso))
                        + (4.799 * Convert.ToDouble(pessoa.altura)) - (5.677 * pessoa.idade);
    }
    else
    {
        calorias = 447.593 + (9.247 * Convert.ToDouble(pessoa.peso))
                            + (3.098 * Convert.ToDouble(pessoa.altura)) - (4.330 * pessoa.idade);
    }

    var dadosRetorno = new DadosRetorno(Math.Round(calorias, 2));

    return Results.Json(dadosRetorno);
});

app.Run();

