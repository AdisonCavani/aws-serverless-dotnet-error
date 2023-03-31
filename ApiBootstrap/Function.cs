using Amazon.Lambda.Serialization.SystemTextJson;
using ApiBootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => { options.SerializerOptions.AddContext<ApiSerializerContext>(); });

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi,
    options => { options.Serializer = new SourceGeneratorLambdaJsonSerializer<ApiSerializerContext>(); });

var app = builder.Build();

app.MapGet("/", () => "Native AOT!");

app.Run();