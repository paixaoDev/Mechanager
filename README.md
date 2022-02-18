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

### Dialog System
O dialogo e adiministrado por duas classes **DialogUIItem** e **DialogController**  
utilizando uma classe do tipo ScriptedObject que carrega os valores de cada dialog  
Os dialogs sao usados no jogo como uma forma de criar eventos para o jogador realizar  

- **DialogUIItem** e responsavel por apresentar dialogos em tela
- **DialogController** e responsavel por gerenciar e enviar os dialogos para o **DialogUIItem** alem de executar os eventos

### Como criar um novo Dialog?
Para criar um novo Dialog voce precisa ir em Assets/Create/Dialog/**DialogItem**  
O que contem em um Dialog:

```c#
public string message;
public Sprite image;
public AudioClip sfx;
public bool show = true;

[HideInInspector] public GameObject dialogPrefab;
```

**eventToExecute** e a classe que tem a lista de eventos a serem executados ao inicio deste Dialog aparecer  
**show** diz se o evento vai ou nao ser exibido na UI **quando nao exibido os eventos serao executados assim que o Dialog for instanciado**

### Event System
O sistema de eventos e responsavel por adiministrar e desenvolver eventos do tipo **Unity Event** para serem utilizados dentro do projeto  
Temos uma classe de pai chamada **Comand** que cria um processo de entrada e finalizacao dos eventos com um callback

### Como criar um Comand
Para ter um event funcionando perfeitamente voce deve criar uma classe publica extendendo de **Comand** e fazer override dos metodos **StartCommad** e **FinishCommad** para adiministrar o tempo de vida do seu script


- **InitComand** Este metodo deve ser chamado pela classe que queira iniciar o Comand
- **StartComand** Este metodo e chamado depois do InitComand
- **FinishCommand** Este metodo deve ser chamado quando o Comand finalizar

```c#
public class Comand : MonoBehaviour
{
    //evento de listener que executa quanto este comando finaliza
    UnityEvent returnListener;

    //Metodo Para iniciar comando
    public void InitComand(UnityEvent returnListener){
        this.returnListener = returnListener;
        StartComand();
    }

    //Metodo virtual utilizado por classe filha para customizar comando - inicio
    internal virtual void StartComand (){}

    //Metodo virtual utilizado por classe filha para customizar comando - fim
    internal virtual void FinishComand ()
    {
        this.returnListener?.Invoke();
    }
}
```

### Como Criar um Evento
O evento e a juncao de um **Comand** e de um **Dialog** ele serve para armazenar de forma inteligente quais eventos teremos para serem executados em nosso jogo.

```c#
public class EventData : ScriptableObject 
{
    public Object comand;
    public DialogData dialog;
}
```

O **Comand** dentro de um evento e puxado e instanciado no **EventController**, isso impede que se possa passar um parametro para este evento, isso apesar de tudo ajuda com que os **Comands** contruidos sejam mais precisos em seu comportamento

```c#
//Exemplo de como um comand e adicionado e executado
public void ExecuteEvent (){
    gameObject.AddComponent(Type.GetType(eventData.comand.name));
    var comand = gameObject.GetComponent(Type.GetType(events[0].comand.name)) as Comand;
    comand.InitComand();
}
```
