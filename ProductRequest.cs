
//payload, classe que representa do payload para nao usar a classes em si
//Colocar como request para representacao do payload de requisicao para salvar o produto

//public record ProductDto, Dto = Data transfer object
//public record ProductCommand
public record ProductRequest(
    string Code,
    string Name,
    string Description, 
    int CategoryId,
    List<string> Tags
    );