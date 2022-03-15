# Projeto Serviços
```console
dotnet new webapi -o servicos
```

```console
cd academico
```

```console
dotnet add package Microsoft.EntityFrameworkCore.InMemory --prerelease
```

```console
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --prerelease
```

```console
dotnet add package Microsoft.EntityFrameworkCore.Design --prerelease
```

```console
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --prerelease
```

```console
dotnet tool install -g dotnet-aspnet-codegenerator --version 6.0.1
```

```console
dotnet tool install -g dotnet-ef
```

```console
code -r ../academico
```

```console
dotnet dev-certs https --trust
```

```console
dotnet ef dbcontext scaffold "Server=localhost;Database=academico;Trusted_Connection=True;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rd;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

```console
dotnet aspnet-codegenerator controller -name TbAlunoController -async -api -m TbAluno -dc academicoContext -outDir Controllers
```

```console
dotnet aspnet-codegenerator controller -name TbAvaliacaoController -async -api -m TbAvaliacao -dc academicoContext -outDir Controllers
```

```console
dotnet aspnet-codegenerator controller -name TbDisciplinaController -async -api -m TbDisciplina -dc academicoContext -outDir Controllers
```

```console
dotnet aspnet-codegenerator controller -name TbProfessorController -async -api -m TbProfessor -dc academicoContext -outDir Controllers
```

```console
dotnet aspnet-codegenerator controller -name TbrAlunoTurmaController -async -api -m TbrAlunoTurma -dc academicoContext -outDir Controllers
```

```console
dotnet aspnet-codegenerator controller -name TbTurmaController -async -api -m TbTurma -dc academicoContext -outDir Controllers
```

```console
dotnet new gitignore
```
