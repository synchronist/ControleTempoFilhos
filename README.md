# ⏱️ Controle de Tempo dos Filhos
A rotina com as crianças tá puxada? Criei um windows forms simples pra ter controle das telas das crianças, por aqui é puxado, são 3 meninos, 2 gamers e 1 neném aspirante a gamer, e por aqui essa solução ajudou muito, então nada mais justo que compartilhar né?
Aqui vai:
Aplicação **Windows Forms moderna (.NET 8)** para controle de tempo de uso de **jogos e telas** de crianças, com contagem regressiva, alerta sonoro e visual moderno.

Projeto pensado para uso **doméstico**, simples e direto, sem dependências externas.

---

## 🎯 Funcionalidades

- 🎮 **Leonardo — Jogo:** 1h30
- 📺 **Leonardo — Assistir:** 2h30
- 🎮 **Bernardo — Jogo:** 2h30

### Recursos
- Contagem regressiva em tempo real
- Botões de **Iniciar / Pausar / Resetar**
- **Som de alerta** ao finalizar o tempo
- Cores diferentes por criança/atividade
- Interface dark, limpa e moderna
- Geração de `.exe` único (standalone)

---

## 🖥️ Tecnologias

- **C#**
- **Windows Forms**
- **.NET 8**
- Visual Studio 2026+

---

## 🚀 Como rodar o projeto (desenvolvimento)

### Pré-requisitos
- Windows 10 ou superior
- Visual Studio 2026 (ou 2022)
- .NET SDK 8+

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/SEU_USUARIO/ControleTempoFilhos.git
Abra o arquivo:

Copiar código
ControleTempoFilhos.sln
Pressione F5 no Visual Studio

📦 Gerar o executável (.exe)
No terminal do projeto (PowerShell):

powershell
Copiar código
dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:SelfContained=true
O executável será gerado em:

bash
Copiar código
bin/Release/net8.0/win-x64/publish/ControleTempoFilhos.exe
Esse arquivo roda em qualquer PC Windows, sem precisar instalar .NET.

🔔 Alertas
O aplicativo emite um som de alerta do Windows quando o tempo termina

Exibe também um aviso visual na tela

