# 🐾 Sistema Silvestre: Gestão de Animais Selvagens em Reabilitação

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![Power BI](https://img.shields.io/badge/Power_BI-F2C811?style=for-the-badge&logo=power-bi&logoColor=black)

---

## 💡 Sobre o Projeto

O **Sistema Silvestre** é uma aplicação desktop desenvolvida em C# com Windows Forms e .NET Framework, projetada para a gestão de centros de reabilitação e cuidados com a fauna silvestre. Ele oferece funcionalidades completas de CRUD (Create, Read, Update, Delete) para o manejo de animais, espécies, recintos, funcionários e manejos clínicos, garantindo o controle e a organização dos dados essenciais para o bem-estar animal e a administração do centro.

Além das funcionalidades operacionais, o sistema integra um Dashboard de Business Intelligence (BI) desenvolvido no Power BI, que permite a análise em tempo real dos dados do banco de dados, fornecendo insights valiosos sobre a população animal, status de saúde e evolução dos tratamentos.

## ✨ Funcionalidades Principais

* **Gestão de Cadastros:**
    * **Animais:** Registro detalhado de cada animal, incluindo identificação, espécie, recinto atual, status de saúde, datas de entrada/saída, motivo de entrada e origem.
    * **Espécies:** Cadastro de diferentes espécies, com nome popular, científico e dieta padrão.
    * **Recintos:** Gerenciamento dos locais de acolhimento, com tipo, tamanho e capacidade máxima.
    * **Funcionários:** Registro de colaboradores, seus cargos e credenciais (CRMV/CRBio).
    * **Usuários:** Controle de acesso com sistema de login seguro e níveis de acesso.
    * **Locais de Soltura:** Cadastro de áreas designadas para soltura e reintegração de animais à natureza.
* **Manejo Clínico:** Registro de procedimentos, pesagens e observações clínicas para cada animal, com histórico de tratamento.
* **Interface Moderna:** Tela de menu principal com design estilo Dashboard Lateral, ícones e navegação intuitiva.
* **Segurança:** Sistema de Login com autenticação de usuário e criptografia (hashing) de senhas.
* **Relatórios e BI:** Integração com Power BI para dashboards analíticos em tempo real, oferecendo uma visão gerencial do centro.

## 🚀 Tecnologias Utilizadas

* **Linguagem:** C#
* **Framework:** .NET Framework (Windows Forms)
* **Banco de Dados:** SQL Server (com ADO.NET para acesso a dados)
* **Criptografia:** BCrypt.Net-Next (para hashing de senhas)
* **Business Intelligence:** Microsoft Power BI (para análise e visualização de dados)
* **IDE:** Visual Studio

## 🖼️ Screenshots / Demonstração

*(Nesta seção, você vai inserir as imagens que me enviou e talvez alguns GIFs do sistema rodando. Use o recurso de "drag and drop" do GitHub para colocar as imagens aqui ou use links.)*

### Tela de Login
![Tela de Login](caminho/para/sua/imagem_login.png) 

### Menu Principal (Dashboard Lateral)
![Menu Principal](caminho/para/sua/imagem_menu_principal.png)

### Dashboard Power BI
![Dashboard Power BI](caminho/para/sua/imagem_power_bi.png)

### Tela de Cadastro de Animal
![Cadastro de Animal](caminho/para/sua/imagem_cadastro_animal.png)

*(Você pode adicionar mais telas aqui, como a lista de animais, manejo clínico, etc.)*

## ⚙️ Como Rodar o Projeto

### Pré-requisitos

* Visual Studio (2019 ou superior)
* SQL Server (Express ou Developer Edition)
* SQL Server Management Studio (SSMS)
* Microsoft Power BI Desktop (opcional, para visualização do dashboard)

### Passos para Configuração

1.  **Clone o Repositório:**
    ```bash
    git clone [https://github.com/SeuUsuario/SistemaSilvestre.git](https://github.com/SeuUsuario/SistemaSilvestre.git)
    cd SistemaSilvestre
    ```

2.  **Configurar o Banco de Dados SQL Server:**
    * Abra o **SQL Server Management Studio (SSMS)**.
    * Crie um novo banco de dados chamado `DBSilvestre`.
    * Execute o script SQL que contém a criação das tabelas e a carga inicial de dados (o arquivo `DBSilvestre_SchemaAndData.sql` que você gerou no Power BI). Este script deve ser gerado pelo próprio SSMS, incluindo esquema e dados.

        **(Instrução para gerar o script do banco):**
        * No SSMS, clique com o botão direito no `DBSilvestre` > Tarefas > Gerar Scripts...
        * Avance até "Opções de Script" > Avançado.
        * Em "Tipos de dados para incluir no script", selecione "Esquema e dados".
        * Salve como `DBSilvestre_SchemaAndData.sql` na pasta `Database` do seu projeto.
    * **Ajustar a Conexão:** No arquivo `Conexao.cs` do projeto (pasta `Controller`), atualize a string de conexão se o nome do seu servidor SQL for diferente de `.\SQLEXPRESS`.

3.  **Abrir e Compilar no Visual Studio:**
    * Abra o arquivo `SistemaSilvestre.sln` no Visual Studio.
    * Restaure os pacotes NuGet (se solicitado, clique com o botão direito na solução > Restaurar Pacotes NuGet). O pacote `BCrypt.Net-Next` é essencial para o login.
    * Compile a solução (`Ctrl + Shift + B`).

4.  **Executar a Aplicação:**
    * Pressione `F5` para iniciar a aplicação.
    * A tela de login será exibida. Use o usuário `admin` e a senha `abc`.

5.  **Configurar o Dashboard Power BI (Opcional):**
    * Abra o arquivo `SistemaSilvestre_Dashboard.pbix` (você o criará depois de montar no Power BI).
    * Ao abrir, o Power BI pode pedir para atualizar as credenciais. Conecte ao seu SQL Server (`.\SQLEXPRESS` ou seu nome de servidor) usando autenticação Windows.

## 🤝 Contribuições

Este projeto foi desenvolvido por [Seu Nome Completo] como parte de [Nome da Disciplina/Projeto Acadêmico]. Sugestões e melhorias são bem-vindas!

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE.md](LICENSE.md) para detalhes. *(Você pode criar um arquivo LICENSE.md simples no GitHub)*

---