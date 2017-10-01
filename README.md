# sonda
<h1>Projeto sonda. </h1>

Abre um arquivo de texto para entrada das informações sobre as sondas para movimentação. O arquivo deve estar no seguinte formato:

5;5             | Altura e largura da área (grid) para movimentação das sondas.
1;2;N           | Posição inicial da primeira sonda sendo 1 a posição em X, 2 a posição em Y e N a direção para a qual a sonda está virada utilizando os pontos cardeais em inglês: N, S, E, W.
LMLMLMLMM       | Comandos para a sonda seguir, sendo: L - Left, rotaciona a sonda para a esquerda. R - Right, rotaciona a sonda para a direita. M - Move, move a sonda uma posição para frente na direção para a qual a sonda estiver virada.
3;3;E           | Informações da segunda sonda.
MMRMMRMRRM      | Comandos para a segunda sonda.
                | etc...

O arquivo de saída conterá a posição final de cada sonda de acordo com os comandos passados no arquivo de entrada. Por exemplo:

X;Y;Cardinal
1;3;N
5;1;E

Sendo X para a posição da sonda no eixo X, Y para a posição da sonda no eixo Y e Cardinal para a direção para a qual a sonda está virada,
utilizando como referência os pontos cardeais em inflês: N, S, E, W.

Para execução, abra o projeto com o Visual Studio 2017, compile, abra um prompt de comando no destino do executável (normalmente a pasta \bin dentro da pasta do projeto), e execute:

MarsProbeConsole.exe [-help | /help | /?] [-file file]
[-help | /help | /?]    Exibe ajuda
[-file file]            Define o local do arquivo de entrada (obrigatorio). Ex: C:\temp\input.txt
