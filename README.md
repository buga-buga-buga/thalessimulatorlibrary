# Thales Simulator

Simulador de comandos HSM Thales PayShield (former Racal), Hardware Security Module de pagamento especializado (EMV, PIN, valida��o de transa��es financeiras)

## Funcionalidades

- Simula��o de comandos de HSM Thales (ex: gera��o de chaves, ZPK, ZMK, PIN, etc)
- Suporte a comandos customizados via VB/C#
- Testes automatizados e integra��o com sistemas legados
- Protocolos de comunica��o TCP e console
- Gera��o e valida��o de LMK, ZMK, ZPK, PIN block, etc
- Log detalhado e configura��o flex�vel via XML

## Estrutura do Projeto

- **ThalesCore / ThalesSim.Core**: N�cleo do simulador, comandos, criptografia
- **ThalesWinSimulator**: Interface gr�fica completona
- **ThalesPVVClashingDemo**: Prova de conceito de uso de for�a bruta para calculo de PVV usando o simulador 
- **ThalesWinSimulatorSetup**: Projeto para gera��o de instalador do simulador para windows
- **ThalesKeyManager**: O nome j� diz tudo!
- **ThalesSim.Tests.Unit**: Testes unit�rios automatizados
- **XMLDefs**: Defini��es de comandos em XML
- **ThalesParameters.xml**: Arquivo de configura��o principal

## Como usar

1. **Configura��o**  
   Edite o arquivo `ThalesParameters.xml` para ajustar portas, caminhos e par�metros do simulador.

2. **Compila��o**  
   Abra a solu��o no Visual Studio e compile em modo Release ou Debug (.NET Framework 4.8).

3. **Execu��o**  
   Execute o simulador (`ThalesWinSimulator.exe` ou via console) e conecte seu sistema de testes na porta configurada.

4. **Testes**  
   Execute os testes unit�rios pelo Visual Studio para validar comandos e integra��es.

## Exemplos de comandos suportados

- Gera��o de ZPK: comando `IA`
- Gera��o de componentes: comando `A2`
- Echo test: comando `B2`
- Cancelamento de estado autorizado: comando `RA`
- Montagem de ZMK a partir de componentes: comando `GY`
- E outros (veja XMLDefs/HostCommands)

## Requisitos

- .NET Framework 4.8
- Visual Studio 2019/2022
- Windows 7 ou superior

## Observa��es

- O simulador nem de longe **substitui um HSM real** !
- Ideal para desenvolvimento, treinamento e teste.
- Suporte a comandos customizados via scripts VB/C# em tempo de execu��o.

## Refer�ncias do Projeto Original

- O projeto original pode ser consultado em:  
  [https://codeplexarchive.org/codeplex/project/thalessim](https://codeplexarchive.org/codeplex/project/thalessim)

- Tamb�m existe um reposit�rio no GitHub, mantido pelo pr�prio autor, com uma branch nova que ainda nao estudei:  
  [https://github.com/nickntg/thalessimulatorlibrary](https://github.com/nickntg/thalessimulatorlibrary)
