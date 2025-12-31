using comaagora.Data;
using comaagora.Repositories;
using comaagora.Services.Categoria;
using comaagora.Services.Endereco;
using comaagora.Services.Estabelecimento;
using comaagora.Services.MetodoPagamento;
using comaagora.Services.Pedido;
using comaagora.Services.Produto;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader(); 
    });
});


builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IProdutoPedidoService, ProdutoPedidoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
builder.Services.AddScoped<IMetodoPagamentoService, MetodoPagamentoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<MetodoPagamentoRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<EstabelecimentoRepository>();
builder.Services.AddScoped<ProdutoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
