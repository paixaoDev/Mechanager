# Mechanager
A Unity Game

### Como trabalhar nessa Repo?
É importante seguir esse fluxo para evitar perda de trabalho:   
- Criar branch nova a partir da **develop**
- Fazer push para sua branch
- Criar Pull Request para develop 

### Como clonar?
Voce pode usar qualquer programa ou puxar via terminal com o codigo:  
`git clone git@github.com:paixaoDev/Mechanager.git`

### Como nomear as branchs?
- `fix/branch_name` **[Fix]** quando for resolver um bug
- `feat/branch_name` **[Feat]** quando esta criando algo 

Se sentir necessidade pode colocar outro indicador antes do nome da branch

### Commits devem ser simples e objetivos
Deixar bem claro o que voce fez, mas de forma simples para nao ser chato  
exemplos: `adicionei movimento`, `fiz arte da nave`, `resolvi bug #fff`

### O que fazer com bugs?
Avise a equipe ou crie uma **issue** dizendo o que aconteceu  
depois uma branch de fix para resolver

## Doc

### Dialog
O dialogo e adiministrado por dua classes **DialogUIItem** e **DialogController** 
utilizando uma classe do tipo ScriptedObject que carrega os valores de cada dialog  
Os dialogs sao usados no jogo como uma forma de criar eventos para o jogador realizar

### Como criar um novo Dialog?
Para criar um novo Dialog voce precisa ir em Assets/Create/Dialog/**DialogItem**
O que contem em um Dialog:

```c#
public string message;
public Sprite image;
public AudioClip sfx;
public EventData eventToExecute;

[HideInInspector] public GameObject dialogPrefab;
```

**eventToExecute** e a classe que tem a lista de eventos a serem executados ao inicio deste Dialog aparecer
