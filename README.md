# sonda
<h1>Projeto sonda. </h1>

<h2>Cenário:</h2>

<h2>Explorando Marte</h2>

<p>Um conjunto de sondas foi enviado pela NASA à Marte e irá pousar num planalto. Esse planalto, que curiosamente é retangular, deve ser explorado pelas sondas para que suas câmeras embutidas consigam ter uma visão completa da área e enviar as imagens de volta para a Terra.</p>

<p>A posição e direção de uma sonda são representadas por uma combinação de coordenadas x-y e uma letra representando a direção cardinal para qual a sonda aponta, seguindo a rosa dos ventos em inglês.</p>

<img src="https://camo.githubusercontent.com/d3a3ea854beba9f8982123ca10600781c0f72da3/687474703a2f2f692e696d6775722e636f6d2f6c69384165354c2e706e67"/>

<p>O planalto é divido numa malha para simplificar a navegação. Um exemplo de posição seria (0, 0, N), que indica que a sonda está no canto inferior esquerdo e apontando para o Norte.</p>

<p>Para controlar as sondas, a NASA envia uma simples sequência de letras. As letras possíveis são "L", "R" e "M". Destas, "L" e "R" fazem a sonda virar 90 graus para a esquerda ou direita, respectivamente, sem mover a sonda. "M" faz com que a sonda mova-se para a frente um ponto da malha, mantendo a mesma direção.</p>

<h2>Solução</h2>

<p>Neste cenário o projeto abre um arquivo de texto para entrada das informações sobre as sondas para movimentação. O arquivo deve estar no seguinte formato:</p>

<table>
    <tr>
        <td>
            5;5
        </td>
         <td>
             Altura e largura da área (grid) para movimentação das sondas.
        </td>
    </tr>
    <tr>
        <td>
            1;2;N 
        </td>
        <td>
            Posição inicial da primeira sonda sendo 1 a posição em X, 2 a posição em Y e N a direção para a qual a sonda está virada utilizando os pontos cardeais em inglês: N, S, E, W.
        </td>                
    </tr>
    <tr>
        <td>
            LMLMLMLMM
        </td>
        <td>
            Comandos para a sonda seguir, sendo: L - Left, rotaciona a sonda para a esquerda. R - Right, rotaciona a sonda para a direita. M - Move, move a sonda uma posição para frente na direção para a qual a sonda estiver virada.
        </td>               
    </tr>
    <tr>
        <td>
            3;3;E
        </td>
        <td>
            Informações da segunda sonda.
        </td>  
    </tr>
    <tr>
        <td>
            MMRMMRMRRM
        </td>
        <td>
            Comandos para a segunda sonda. etc...
        </td>              
    </tr>                            
</table>

<p>O arquivo de saída conterá a posição final de cada sonda de acordo com os comandos passados no arquivo de entrada. Por exemplo:</p>

<p>
X;Y;Cardinal
<br/>1;3;N
<br/>5;1;E</p>

<p>Sendo X para a posição da sonda no eixo X, Y para a posição da sonda no eixo Y e Cardinal para a direção para a qual a sonda está virada,
utilizando como referência os pontos cardeais em inflês: N, S, E, W.</p>

<p>Para execução, abra o projeto com o Visual Studio 2017, compile, abra um prompt de comando no destino do executável (normalmente a pasta \bin dentro da pasta do projeto), e execute:

MarsProbeConsole.exe [-help | /help | /?] [-file file]
<br/><br/>[-help | /help | /?]    Exibe ajuda
<br/>[-file file]            Define o local do arquivo de entrada (obrigatorio). Ex: C:\temp\input.txt</p>
