# 🌿 Sistema Silvestre: Gestão de Animais Selvagens em Reabilitação

## 💡 Sobre o Projeto

Aplicação desktop completa em C# (Windows Forms) para gestão de centros de reabilitação de fauna silvestre. Inclui funcionalidades CRUD, login seguro e integração com Power BI para análise de dados.

## ✨ Funcionalidades

* **Gestão de Cadastros:** Animais, Espécies, Recintos, Funcionários, Usuários, Locais de Soltura.
* **Manejo Clínico:** Registro de procedimentos e evolução dos animais.
* **Login Seguro:** Autenticação de usuário com senhas criptografadas.
* **Interface:** Design moderno com menu lateral intuitivo.
* **Análise de Dados:** Dashboard Power BI para insights gerenciais.

## 🚀 Tecnologias

* C# (.NET Framework)
* SQL Server (ADO.NET)
* BCrypt.Net-Next
* Microsoft Power BI

## ⚙️ Como Rodar

1.  Clone o repositório.
2.  No SSMS, execute o script `Database/DBSilvestre_SchemaAndData.sql` para criar o banco e carregar os dados.
3.  Abra `SistemaSilvestre.sln` no Visual Studio e restaure pacotes NuGet.
4.  Atualize a string de conexão em `Controller/Conexao.cs` se seu servidor SQL for diferente de `.\SQLEXPRESS`.
5.  Execute a aplicação. Login: **Usuário:** `admin`, **Senha:** `abc`.
6.  Abra o dashboard Power BI em `PowerBI/SistemaSilvestre_Dashboard.pbix` e atualize a conexão com o banco.

---
