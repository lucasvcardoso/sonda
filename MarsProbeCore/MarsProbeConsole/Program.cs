using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace MarsProbeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("\nFormato de entrada inválido. Argumento -file obrigatório. Tente MarsProbeConsole.exe -help para ajuda.\n");
                Environment.Exit(0);
            }

            bool hasHelpArg = Array.IndexOf(args, "-help") > -1 || Array.IndexOf(args, "/help") > -1 || Array.IndexOf(args, "/?") > -1;

            if (hasHelpArg)
            {
                WriteLine("\nMarsProbeConsole.exe [-help | /help | /?] [-file file]");
                WriteLine("\nAbre um arquivo de texto para entrada das informações sobre as sondas para movimentação. O arquivo deve estar no seguinte formato:\n");
                WriteLine("5;5       \t| Altura e largura da área (grid) para movimentação das sondas.");
                WriteLine("1;2;N     \t| Posição inicial da primeira sonda sendo 1 a posição em X, 2 a posição em Y e N a direção para a qual a sonda está virada utilizando os pontos cardeais em inglês: N, S, E, W.");
                WriteLine("LMLMLMLMM \t| Comandos para a sonda seguir, sendo: L - Left, rotaciona a sonda para a esquerda. R - Right, rotaciona a sonda para a direita. M - Move, move a sonda uma posição para frente na direção para a qual a sonda estiver virada.");
                WriteLine("3;3;E     \t| Informações da segunda sonda.");
                WriteLine("MMRMMRMRRM\t| Comandos para a segunda sonda.");
                WriteLine("          \t| etc...");
                WriteLine("\nO arquivo de saída conterá a posição final de cada sonda de acordo com os comandos passados no arquivo de entrada. Por exemplo:\n");
                WriteLine("X;Y;Cardinal");
                WriteLine("1;3;N");
                WriteLine("5;1;E");
                WriteLine("\nSendo X para a posição da sonda no eixo X, Y para a posição da sonda no eixo Y e Cardinal para a direção para a qual a sonda está virada,");
                WriteLine("utilizando como referência os pontos cardeais em inflês: N, S, E, W.");
                WriteLine("\n[-help | /help | /?]\tExibe ajuda");
                WriteLine("\n[-file file]\t\tDefine o local do arquivo de entrada (obrigatorio). Ex: C:\\temp\\input.txt \n");
                Environment.Exit(0);
            }

            bool argsHasMoreThanOneIndex = args.Length > 1;

            int argFilePosition = Array.IndexOf(args, "-file");
            bool hasArgFile = argFilePosition > -1;
            
            if (!hasArgFile || !argsHasMoreThanOneIndex)
            {
                WriteLine("\nFormato de entrada invalido. Argumento -file obrigatorio. Valor do argumento -file obrigatório. Tente MarsProbeConsole.exe -help para ajuda. \n");
                Environment.Exit(0);
            }
            
            Regex rgxFileAddr = new Regex(@"[:|\\]");
            int valueArgFilePosition = argFilePosition + 1;
            bool isValueArgFileAddr = rgxFileAddr.IsMatch(args[valueArgFilePosition]);
            bool hasFileValue = hasArgFile && argsHasMoreThanOneIndex ? isValueArgFileAddr : false;

            if (hasArgFile && !hasFileValue)
            {
                WriteLine("\nFormato de entrada invalido. Digite o caminho para o arquivo. \n");
                Environment.Exit(0);
            }

            string _valorFileUrl = args[valueArgFilePosition];

            if (!File.Exists(args[valueArgFilePosition]))
            {
                WriteLine("\nArquivo de entrada invalido. Digite o caminho para um arquivo de entrada válido. \n");
                Environment.Exit(0);
            }

            try
            {
                WriteLine($"Horário de início da execução: " + DateTime.Now.ToString());
                MarsProbeCore.Orchestrator orch = new MarsProbeCore.Orchestrator(args[valueArgFilePosition]);
                string outputFile = orch.RunOrchestrator();
                WriteLine("\nProcessamento encerrado. Resultados:\n");
                foreach (string line in File.ReadAllLines(outputFile))
                {
                    WriteLine(line);
                    Thread.Sleep(500);
                }
                WriteLine($"\nHorário de fim da execução: " + DateTime.Now.ToString());
                WriteLine($"\nArquivo de saída pode ser lido em: {outputFile}");
            }
            catch (Exception ex)
            {
                WriteLine(@"ERRO DURANTE A EXECUÇÃO. FAVOR VERIFICAR ARQUIVO DE LOGS EM C:\tmp\logs\.");
                Logger.Log(ex.Message + ": " + ex.StackTrace, Logger.LogType.ERROR.ToString(), "MarsProbeConsole");
                Environment.Exit(-1);
            }            
        }
    }
}
