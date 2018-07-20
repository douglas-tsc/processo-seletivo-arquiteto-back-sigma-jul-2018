# **Processo Seletivo Arquiteto de Software Back-End da Sigma/TJMT**

### **Bem-vindo ao processo seletivo para arquiteto de software da Sigma/TJMT!**

## **O desafio**

### **Crie serviços REST com Web API para o gerenciamento de patrimônios de uma empresa.**

## **Requisitos**

### **Patrimônio**

* **Campos:**

    * Nome - obrigatório

    * MarcaId - obrigatório

    * ModeloId - obrigatório

    * DataCriacao - obrigatório

    * Descrição

    * Nº do tombo - obrigatório

* **Acessos:**

É preciso disponibilizar meios para que sejam acessadas as informações de todos os patrimônios, os patrimônios de uma determinada marca, os de um determinado modelo, patrimônios por identificador único. Também deverá conter procedimentos para inserir, atualizar e excluir um patrimônio.

* **Regras:**

    * O nº do tombo deve ser gerado automaticamente pelo sistema, e não pode ser alterado pelos usuários.

### **Marca**

* **Campos:**

    * Nome - obrigatório

    * DataCriacao - obrigatório

* **Acessos:**

É preciso disponibilizar meios para que sejam acessadas as informações de todas os marcas, marcas por identificador único. Também deverá conter procedimentos para inserir, atualizar e excluir uma marca.

* **Regras:**

    * Não deve permitir a existência de duas marcas com o mesmo nome.

### **Modelo**

* **Campos:**

    * Nome - obrigatório

    * DataCriacao - obrigatório

* **Acessos:**

É preciso disponibilizar meios para que sejam acessadas as informações de todos os modelos, os modelos de uma determinada marca, modelos por identificador único. Também deverá conter procedimentos para inserir, atualizar e excluir um modelo.

* **Regras:**

    * Não deve permitir a existência de dois modelos com o mesmo nome para uma marca.

### **Requisitos técnicos**

* Deve-se utilizar C#;

* Deve-se utilizar ASP.NET Core Web Api;

* É necessário criar testes unitários;

* Os dados devem ser salvos em banco;

* Deve-se utilizar o Swagger;

* É necessário ter um Dockerfile para criação de imagem;

* É necessário ter um arquivo de configuração YAML para execução da aplicação através do Docker Compose (deve conter todos os serviços necessários);

* A sua aplicação deve conter um arquivo README explicando o funcionamento e a solução adotada na sua implementação do desafio.

### **Requisitos não funcionais**

* Quanto à segurança, sua solução será, inicialmente pública, você está construindo um MVP, não se preocupe com isso;

* Apesar do seu objetivo ser construir um MVP, sua arquitetura, bem como seu código será continuado pelos times de desenvolvimento, onde serão alocados para o projeto 2 times, ambos com 1 desenvolvedor sênior e dois devs plenos, um responsável pelo domínio do Patrimônio e o outro para o restante da solução, pois os gestores desse Produto têm muita coisa para acrescentar a nível de funcionalidades (principalmente no que diz respeito ao Patrimônio) e consequentemente, de complexidade, você, como arquiteto deve pensar nesse fatores, para o quesito manutenabilidade;

* O time de desenvolvimento como um todo (analistas, QA, devs e você, arquiteto) estão todos alocados no TJ e a sua API será utilizada por todos os outros Tribunais de Justiça do Brasil e o time não poderá se deslocar, nem manter muito contato com os outros órgãos, e, ainda assim, deve ser fácil consumir sua solução (API e outras coisas que achar necessário).

### **Observações/Dicas**

* Não limite-se às funcionalidades acima. Qualquer feature extra é bem-vinda;

* A arquitetura é por sua conta;

* Iremos usar o docker-compose para testar sua aplicação;

* Não é necessária a criação de telas.

## **Critérios de avaliação**

* Organização do código

* Organização da estrutura

* Arquitetura desenvolvida

* Documentação do projeto (readme)

## **Procedimento**

* **Faça um fork do projeto:**

    * https://github.com/kutzr/processo-seletivo-arquiteto-back-sigma-jul-2018

* **Ao finalizar a sua aplicação, crie um pull request no projeto de origem.**

## **Prazo**

* **O prazo para criar pull requests é até o dia 27/07/2018, às 12h.**

### **Dê o seu melhor!**

### **Boa prova! ;)**
