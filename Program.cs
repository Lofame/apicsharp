using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World 2 !");
app.MapGet("/user", () => new {nome="Luando",idade=40});
app.MapGet("/addheader",(HttpResponse response) => response.Headers.Add("Teste","Luando"));
// app.MapPost("/saveproduct",(Product product) => {
//     return product.Code + " - " + product.Name; 
// });

app.MapPost("/saveproduct",(Product product) => {

      ProductRepository.Add(product);

 });

//https://localhost:3001/getproducts?datestart=20220119&dateend=20220819
//api.app.com/users?datastart={date}&dataend{date}
app.MapGet("/getproduct",([FromQuery] string dateStart,[FromQuery] string dateEnd) => {
    return dateStart + " - " + dateEnd;
});


//https://localhost:3001/getproduct/1
//api.app.com/user/{code}
// app.MapGet("/getproduct/{code}",([FromRoute] string code) => {
//     return code ;
// });

app.MapGet("/getproduct/{code}",([FromRoute] string code) => {
    var product = ProductRepository.GetBy(code);
    return product;
});



app.MapGet("/getproductbyheader",(HttpRequest request) => {
    return request.Headers["product-code"].ToString();
});



app.MapPut("/editproduct",(Product product) => {
    var productSaved = ProductRepository.GetBy(product.Code);

    //atribui a referencia de memoria ao novo nome
    productSaved.Name = product.Name;
});

app.MapDelete("/deleteproduct/{code}",([FromRoute] string code) =>{

    var productDelete = ProductRepository.GetBy(code);

    ProductRepository.Remove(productDelete);
});

app.Run();


//Se a classe não for estatica ela morre apos a requisição
//Ao colocar ela estatica ela fica disponivel na memoria
public static class ProductRepository{

    public static List<Product> Products {get;set;}

    public static void Add(Product product){
        if(Products == null)
           Products = new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code){
    return Products.FirstOrDefault(p => p.Code == code);
}

    public static void Remove(Product product){
          Products.Remove(product);  
    }
}





public class Product{

    public string Code { get; set; }
    public string Name { get; set; }

}