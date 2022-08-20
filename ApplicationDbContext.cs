using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext{

    public DbSet<Product> Products {get;set;}

 public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

 }
    // protected override void OnConfiguring(DbContextOptionsBuilder options) => 
    // options.UseSqlServer();

protected override void OnModelCreating(ModelBuilder builder){
    builder.Entity<Product>().Property(p => p.Description).HasMaxLength(500).IsRequired(false);
    builder.Entity<Product>().Property(p => p.Name).HasMaxLength(120).IsRequired();
    builder.Entity<Product>().Property(p => p.Code).HasMaxLength(20).IsRequired();
}

}

//"Server=localhost;Database=Products;Use Id=sa;Password=3data;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES"
// app.MapGet("/", () => "Hello World 2 !");
// app.MapGet("/user", () => new {nome="Luando",idade=40});
// app.MapGet("/addheader",(HttpResponse response) => response.Headers.Add("Teste","Luando"));
// app.MapPost("/saveproduct",(Product product) => {
//     return product.Code + " - " + product.Name; 
// });
//https://localhost:3001/getproducts?datestart=20220119&dateend=20220819
//api.app.com/users?datastart={date}&dataend{date}
// app.MapGet("/getproduct",([FromQuery] string dateStart,[FromQuery] string dateEnd) => {
//     return dateStart + " - " + dateEnd;
// });

//https://localhost:3001/getproduct/1
//api.app.com/user/{code}
// app.MapGet("/getproduct/{code}",([FromRoute] string code) => {
//     return code ;
// });


// app.MapGet("/getproductbyheader",(HttpRequest request) => {
//     return request.Headers["product-code"].ToString();
// });