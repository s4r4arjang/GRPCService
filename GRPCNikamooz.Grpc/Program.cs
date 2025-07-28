using GRPCNikamooz.BLL.Services;
using GRPCNikamooz.DAL;
using GRPCNikamooz.DAL.Repositories;
using GRPCNikamooz.Domain.Repositories;
using GRPCNikamooz.Domain.Services;
using GRPCNikamooz.Grpc.Infrastructures;
using GRPCNikamooz.Grpc.Interceptors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentService , StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddDbContext<StudentContext>();
builder.Services.AddSingleton<ProtoFileProvider>();
builder.Services.AddGrpcReflection();
// Add services to the container.
builder.Services.AddGrpc(c =>
{
    c.EnableDetailedErrors = true;
    c.Interceptors.Add<ExceptionInterceptor>();
}
);

var app = builder.Build();
app.MapGet("/protos", (ProtoFileProvider protoFileProvider) =>
{
    return Results.Ok(protoFileProvider.GetAll());
});
app.MapGet("/protos/v{version:int}/{protoName}", (ProtoFileProvider protoFileProvider, int version, string protoName) =>
{
    string filePath = protoFileProvider.GetPath(version, protoName);
    if (string.IsNullOrEmpty(filePath))
        return Results.NotFound();
    return Results.File(filePath);
});

app.MapGet("/protos/v{version:int}/{protoName}/view", async (ProtoFileProvider protoFileProvider, int version, string protoName) =>
{
    string fileContent = await protoFileProvider.GetContent(version, protoName);
    if (string.IsNullOrEmpty(fileContent))
        return Results.NotFound();
    return Results.Text(fileContent);
});
app.MapGrpcReflectionService();
// Configure the HTTP request pipeline.
app.MapGrpcService<GRPCNikamooz.Grpc.Services.StudentService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
