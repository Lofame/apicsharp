public class Product{

    public string Id {get;set;}
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description {get;set;}
    public int CategoryId{get;set;}    //serve para criar uma chave estrangeira para não conter valores nulo
    public Category Category { get; set; }
    public List<Tag> Tag{get;set;}


}

