
//Se a classe não for estatica ela morre apos a requisição
//Ao colocar ela estatica ela fica disponivel na memoria
public static class ProductRepository{

    public static List<Product> Products {get;set;} = new List<Product>();


    public static void Init(IConfiguration configuration){
        var products = configuration.GetSection("Products").Get<List<Product>>();
        Products = products;
    }
    
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

