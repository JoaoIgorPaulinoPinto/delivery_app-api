using comaagora.Data;
using comaagora.Repositories;
using comaagora.Services.Categoria;
using comaagora.Services.Endereco;
using comaagora.Services.Estabelecimento;
using comaagora.Services.Localizacao;
using comaagora.Services.MetodoPagamento;
using comaagora.Services.Pedido;
using comaagora.Services.Produto;
using comaagora.Services.ProdutoPedido;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var conn = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(conn, ServerVersion.AutoDetect(conn));
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IProdutoPedidoService, ProdutoPedidoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
builder.Services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ILocalizacaoService, LocalizacaoService>();

builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<MetodoPagamentoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<EstabelecimentoRepository>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<LocalizacaoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
