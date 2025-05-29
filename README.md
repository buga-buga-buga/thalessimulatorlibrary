# Thales Simulator

Simulador de comandos HSM Thales PayShield (former Racal), Hardware Security Module de pagamento especializado (EMV, PIN, validação de transações financeiras)

## Funcionalidades

- Simulação de comandos de HSM Thales (ex: geração de chaves, ZPK, ZMK, PIN, etc)
- Suporte a comandos customizados via VB/C#
- Testes automatizados e integração com sistemas legados
- Protocolos de comunicação TCP e console
- Geração e validação de LMK, ZMK, ZPK, PIN block, etc
- Log detalhado e configuração flexível via XML

## Estrutura do Projeto

- **ThalesCore / ThalesSim.Core**: Núcleo do simulador, comandos, criptografia
- **ThalesWinSimulator**: Interface gráfica completona
- **ThalesPVVClashingDemo**: Prova de conceito de uso de força bruta para calculo de PVV usando o simulador 
- **ThalesWinSimulatorSetup**: Projeto para geração de instalador do simulador para windows
- **ThalesKeyManager**: O nome já diz tudo!
- **ThalesSim.Tests.Unit**: Testes unitários automatizados
- **XMLDefs**: Definições de comandos em XML
- **ThalesParameters.xml**: Arquivo de configuração principal

## Como usar

1. **Configuração**  
   Edite o arquivo `ThalesParameters.xml` para ajustar portas, caminhos e parâmetros do simulador.

2. **Compilação**  
   Abra a solução no Visual Studio e compile em modo Release ou Debug (.NET Framework 4.8).

3. **Execução**  
   Execute o simulador (`ThalesWinSimulator.exe` ou via console) e conecte seu sistema de testes na porta configurada.

4. **Testes**  
   Execute os testes unitários pelo Visual Studio para validar comandos e integrações.

## Exemplos de comandos suportados

- Geração de ZPK: comando `IA`
- Geração de componentes: comando `A2`
- Echo test: comando `B2`
- Cancelamento de estado autorizado: comando `RA`
- Montagem de ZMK a partir de componentes: comando `GY`
- E outros (veja XMLDefs/HostCommands)

## Requisitos

- .NET Framework 4.8
- Visual Studio 2019/2022
- Windows 7 ou superior

## Observações

- O simulador nem de longe **substitui um HSM real** !
- Ideal para desenvolvimento, treinamento e teste.
- Suporte a comandos customizados via scripts VB/C# em tempo de execução.

## Referências do Projeto Original

- O projeto original pode ser consultado em:  
  [https://codeplexarchive.org/codeplex/project/thalessim](https://codeplexarchive.org/codeplex/project/thalessim)

- Também existe um repositório no GitHub, mantido pelo próprio autor, com uma branch nova que ainda nao estudei:  
  [https://github.com/nickntg/thalessimulatorlibrary](https://github.com/nickntg/thalessimulatorlibrary)
