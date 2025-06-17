# Trabalho AVL – Engenharia da Computação

Este projeto foi desenvolvido para a disciplina de **Análise e Projeto Orientado a Objetos I**, com foco na implementação de uma **Árvore AVL** em C#.

---

## 📁 Estrutura de Arquivos

- `Program.cs` → ponto de entrada do programa
- `ArvoreAVL.cs` → implementação da lógica da árvore AVL
- `NodoAVL.cs` → definição da estrutura de um nó da árvore
- `entrada.txt` → comandos de teste da árvore

---

## ⚙️ Funcionalidades
- Inserção, remoção e busca de elementos
- Impressão em pré-ordem
- Cálculo de altura e fatores de balanceamento da árvore
- Execução automática a partir de arquivo de texto

---

## ▶️ Como executar

### ✅ Requisitos:
- [.NET SDK 6.0+](https://dotnet.microsoft.com/en-us/download)

### 🔧 Passos:

1. Abra o terminal e vá até a pasta do projeto:
   ```bash
   cd TrabalhoAVL
   ```

2. Caso ainda não tenha criado o projeto:
   ```bash
   dotnet new console
   ```

3. Remova o `Program.cs` padrão gerado:
   ```bash
   del Program.cs
   ```

4. Adicione os arquivos fornecidos: `Program.cs`, `ArvoreAVL.cs`, `NodoAVL.cs`, e `entrada.txt`

5. Execute o projeto:
   ```bash
   dotnet run
   ```

6. Quando solicitado, digite:
   ```
   entrada.txt
   ```

---

## 📥 Exemplo de arquivo de entrada (`entrada.txt`)
```
I 10
I 20
I 30
P
I 15
P
R 20
P
B 15
B 25
F
H
```

---

## 📌 Comandos disponíveis
- `I <valor>` → Inserir valor
- `R <valor>` → Remover valor
- `B <valor>` → Buscar valor
- `P` → Imprimir árvore em pré-ordem
- `F` → Mostrar fatores de balanceamento
- `H` → Mostrar altura da árvore

---

## 👨‍💻 Autor
**Enzo Barbosa das Neves**  
Disciplina: Análise e Projeto Orientado a Objetos I – Engenharia da Computação  
Centro Universitário da Fundação Hermínio Ometto (FHO)
