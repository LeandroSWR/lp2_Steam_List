# SteamList

## Autores

* Flávio Santos - 21702344

* Leandro Brás - 21801026

## Repositório Remoto Usado

### [SteamList](https://github.com/xShadoWalkeR/lp2_Steam_List)

## Repartição do Projeto

É de salientar que o objetivo neste projeto foi sempre tentar dividir o trabalho pelos dois o mais possível.
Partes do código foram feitas em conjunto, embora apenas uma pessoa tenha dado os *commits* necessários.

#### Flávio
* Critério de Ordenação
* Pesquisa (repartido)
* Otimizações de código e comentários
* UML (repartido)
* Documentação (repartido)

#### Leandro
* Pesquisa por ID
* Pesquisa (repartido)
* Otimizações de código e comentários
* Fluxograma
* UML (repartido)
* Documentação (repartido)

## Descrição da Solução

### Explicação

O projeto é composto por apenas 6 classes.

Na classe `Program` é inicializada a variável `myDisplay` to tipo `Display`. O construtor da classe desta variável há de aceitar como um dos argumentos a chave que será utilizada pelo dicionário criado posteriormente. A chave inicial é dada como a primeira variável do programa (`DefaultKey`).

A classe `Display` é responsável pela maior parte dos desenhos na consola presentes no programa. Para tal, esta acede a todas as outras classes (excetuando a classe `Game`) das quais são criadas instâncias no seu construtor.
Esta classe contém ainda todos os *menus* disponíveis no programa, incluindo a sua navegação por parte de diferentes métodos (normalmente contendo `'Selection'` no seu nome).
Por fim, esta classe imprime ainda no ecrã toda a informação do jogo selecionado (ao aceder a cada valor inserido no *dicionário* que contém os jogos e chamando o método `ToString()` que sofreu um `override` na classe `Game`) e faz *download* e abre a imagem *header* do jogo (nos métodos `DisplayInformation()` e `DisplayImage()`, respetivamente).

A classe `GameList` é o local efetivo onde é criado o dicionário. Para tal, existe o método `FillDictionary()` que usa um `try-catch` de modo verificar se o ficheiro `.csv` está ou não presente na pasta `Debug` e um `using` (dentro do `try`) onde esse ficheiro é lido e cada parte separada por vírgulas é dada como uma chave do dicionário. É também dado um *skip* à primeira linha do ficheiro, pois esta define a organização de cada outra linha do ficheiro.
O construtor desta classe aceita duas `strings`: uma `key` (do dicionário) que é atribuída à `key` da própria classe e um `arg` (caminho do ficheiro `.csv`), cujo valor é atribuído à variável global `path` também pertencente a esta classe.

A classe `Filters` serve apenas para atribuir cada `string` entre vírgulas a uma dada variável do tipo que melhor lhe corresponde. Será usada na pesquisa filtrada de modo a conseguir "ler" cada `string` individual e organizá-las e/ou pesquisá-las (com *matches* parciais).
O seu construtor é vazio.

A classe `FilteredList` tem como objetivo servir de filtro e sistema de ordenação efetivamente. O construtor da classe inicializa uma lista temporária que é usada nos outros dois métodos presentes. Esta lista verifica qual a "chave" escolhida pelo utilizador do programa e ordena a pesquisa efetuada de acordo com o critério de ordenação.
Já no método `FilterGames` existe uma outra lista `temp` (outra lista temporária, da qual são extraídos os valores para a lista anterior). Esta lista usa os termos `Where` (dentro de um `IEnumerable<Game>` - `filteredGame`), `IndexOf` e `OrdinalIgnoreCase` de modo a pesquisar os nomes de cada jogo apenas se estes contiverem um *match* parcial do *filtro* que o utilizador dá. Em relação aos restantes parâmetros o programa simplesmente verifica se os do jogo e do filtro são iguais.

Já a função da classe `Game` é atribuir a cada espaço entre vírgulas presente no ficheiro uma variável do tipo correspondente (mas apenas se esse espaço estiver preenchido). O construtor da classe cria um `array` ao qual são atribuídas as variáveis anteriores, cada uma em sua casa. Mais abaixo encontra-se um `override` do método `ToString()` que imprime pega nas variáveis presentes na classe e as imprime com algum contexto.

### Diagrama UML
![Diagrama_UML](UML.png)

### Fluxograma
![Fluxograma](Fluxograma.png)

## Conclusões e Matéria Aprendida

A estruturação de classes é algo extremamente importante, muito realçado pela criação e desenvolvimento deste projeto. A divisão de tarefas pelas mesmas tem de ser algo que faça sentido, algo para o qual qualquer programador poderia olhar e imediatamente entender.

Algo também muito importante neste projeto foi o uso de um Dicionário de modo a pesquisar jogos por ID (ID como 'key'). Algo que mais tarde se revelou um obstáculo, mas que foi ultrapassado com o uso filtros específicos por parte de uma nova classe `Filters`.

Outra coisa que também ajudou na resolução do problema de como efetuar a pesquisa foi o uso de *queries* simples (parte do LINQ). O simples uso do método de extensão `Where` faz com a pesquisa seja feita com eficácia e rapidez, sem precisar de grande complexidade no código.

## Referências

Whitaker, RB. (2016). *C# Player's Guide*, Starbound Software

[.NET API Browser](https://docs.microsoft.com/en-us/dotnet/api/)
