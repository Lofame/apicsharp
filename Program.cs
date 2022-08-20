using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);
// builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

var configuration = app.Configuration;
ProductRepository.Init(configuration);

app.MapPost("/products",(ProductRequest productRequest, ApplicationDbContext context) => {
    var category = context.Categories.Where(c => c.Id == productRequest.CategoryId).First();
    var product = new Product
    {
        Code = productRequest.Code,
        Name = productRequest.Name,
        Description = productRequest.Description,
        Category = category

    };
      context.Products.Add(product);
      context.SaveChanges();
      return Results.Created($"/produtcs/{product.Code}",product);
 });

app.MapGet("/products/{code}",([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);

    if(product != null)
    {
        return Results.Ok(product);
    }
    return Results.NotFound(null);
});


app.MapPut("/products",(Product product) => {
    var productSaved = ProductRepository.GetBy(product.Code);

    //atribui a referencia de memoria ao novo nome
    productSaved.Name = product.Name;

   return Results.Ok();
});

app.MapDelete("/products/{code}",([FromRoute] string code) =>{

    var productDelete = ProductRepository.GetBy(code);
    ProductRepository.Remove(productDelete);

    return Results.Ok();
});
                         
if(app.Environment.IsStaging()){
app.MapGet("/configuration/database",(IConfiguration configuration) =>{
   return Results.Ok(configuration["Database:Connection"]);
});
}


app.Run();
