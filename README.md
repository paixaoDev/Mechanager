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
public EventData eventToExecute;

[HideInInspector] public GameObject dialogPrefab;
```

**eventToExecute** e a classe que tem a lista de eventos a serem executados ao inicio deste Dialog aparecer  
**show** diz se o evento vai ou nao ser exibido na UI **quando nao exibido os eventos serao executados assim que o Dialog for instanciado**

### Event System
O sistema de eventos e responsavel por adiministrar e desenvolver eventos do tipo **Unity Event** para serem utilizados dentro do projeto  
Temos uma classe de pai chamada **Comand** que cria um processo de entrada e finalizacao dos eventos com um callback

### Como criar um Comand
Para ter um event funcionando perfeitamente voce deve criar uma classe publica extendendo de **Comand** e fazer override dos metodos **StartCommad** e **FinishCommad** para adiministrar o tempo de vida do seu script

- **StartComand** seria o Start da Unity, mas para o padrao Comand
- **FinishCommand** este evento deve ser executado ao fim do seu evento criado, nele eh executado um callback para outro script ou sistema 
- **InitComand** este metodo inicia o evento em si, dentro dele deve ser passado um metodo que sera executado ao evento finalizar

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
